    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Dnn;
    using Emgu.CV.Structure;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    namespace Vadit
    {

        public class AnalyzeData
        {
            public Bitmap AnalyzedImage;
            public string Result;
        }

        public class VdtManager
        {
            Data _data;
            BackgroundWorker _backgroundWorker;

            private VideoCapture _cap = null; // 카메라 설정을 위한 변수 선언
            private Mat _frame = null; // 프레임을 저장하기 위한 변수 선언

            private Dictionary<string, Image<Bgr, byte>> IMGDict; // 이미지를 저장하는 Dictionary 선언 (Key: string, Value: Image<Bgr, byte>)

            private Net _poseNet = null; // OpenPose 딥러닝 모델을 로드하는 변수 선언
            private List<Point> _points; // 각 랜드마크를 저장하는 리스트 선언


            public VdtManager(ProgressChangedEventHandler OnProgressing)
            {
                IMGDict = new Dictionary<string, Image<Bgr, byte>>(); // 이미지를 저장하기 위한 Dictionary 객체 생성
                _cap = new VideoCapture(0); // 카메라를 열고 설정하기 위한 VideoCapture 객체 생성 (0은 기본 카메라를 나타냄)
                _poseNet = ReadPoseNet(); // OpenPose 딥러닝 모델을 로드
                _points = new List<Point>(); // 랜드마크 좌표를 저장하기 위한 List 초기화
            
                _data = new Data();

                // BackgroundWorker 초기화 및 설정
                _backgroundWorker = new BackgroundWorker(); // 백그라운드 워커 객체 생성
                _backgroundWorker.WorkerReportsProgress = true; // 중간 보고 할거냐, 이걸 해줘야 중간보고를 할 수 있음
                _backgroundWorker.DoWork += new DoWorkEventHandler(OnDoWork); // 엔트리 포인트, 실행 할 함수를 매개변수로 줌
                _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(OnProgressing); // 진행중인 진행 상활을 보고 받을거임

                _backgroundWorker.RunWorkerAsync();
            }
            //쓰레드로 돌릴 것들
            private void OnDoWork(object sender, DoWorkEventArgs e)
            {
                while (true)
                {
                    ProcessFrameAndDrawSkeleton(_backgroundWorker);
                }
            }

            // Caffe 형식의 OpenPose 딥러닝 모델을 로드하여 반환
            private Net ReadPoseNet()
            {
                string prototxt = @"C:\openpose-master\models\pose\body_25\pose_deploy.prototxt";
                string modelPath = @"C:\openpose-master\models\pose\body_25\pose_iter_584000.caffemodel";
                return DnnInvoke.ReadNetFromCaffe(prototxt, modelPath);
            }

            // 프레임 캡처하고 스켈레톤을 탐지하고 그리기 위한 메서드 (비동기 작업을 위해 BackgroundWorker를 매개변수로 받음)
            public void ProcessFrameAndDrawSkeleton(BackgroundWorker worker)
            {
                if (_cap.IsOpened)
                {
                    _frame = new Mat();
                    _cap.Read(_frame); // 카메라에서 프레임 캡처

                    if (!_frame.IsEmpty)
                    {
                        var img = _frame.ToImage<Bgr, byte>(); // 프레임을 Image<Bgr, byte> 형식으로 변환
                        if (IMGDict.ContainsKey("input"))
                        {
                            IMGDict["input"]?.Dispose();
                            IMGDict.Remove("input"); // 기존 "input" 키에 저장된 이미지 제거
                        }
                        IMGDict.Add("input", img); // 현재 캡처한 이미지를 "input" 키로 Dictionary에 추가

                        // 스켈레톤을 탐지하고 그리기 위한 메서드 호출
                        DetectAndDrawSkeleton(img, worker);

                    }
                }
            }

            // 스켈레톤 탐지하고 그리기 위한 메서드
            private void DetectAndDrawSkeleton(Image<Bgr, byte> img, BackgroundWorker backgroundWorker)
            {
                AnalyzeData analyzeData = new AnalyzeData();
                try
                {
                    if (!IMGDict.ContainsKey("input"))
                    {
                        throw new Exception("Please read in an image first.");
                    }

                    // 이미지 처리를 위한 초기 설정
                    int inWidth = 368; // 이미지 사이즈 설정
                    int inHeight = 368;
                    float threshold = 0.1f; // 임계값 설정
                    int nPoints = 25; // 추출할 포인트 수

                    // 몸체 부위를 나타내는 상수들의 딕셔너리
                    var BODY_PARTS = new Dictionary<string, int>()
                    {
                        { "Nose", 0 },
                        { "Neck", 1 },
                        { "RShoulder", 2 },
                        { "LShoulder", 5 },
                        { "REye", 15 },
                        { "LEye", 16 },
                        {"REar",17},
                        { "LEar", 18 }
                    };

                    // 연결할 포인트 쌍을 나타내는 배열
                    int[,] point_pairs = new int[,]
                    {
                        { 1, 0 }, { 1, 2 }, { 1, 5 },
                        { 15, 17 }, { 16, 18 }, { 0, 16 },
                        { 0, 15 }
                    };

                    var net = ReadPoseNet(); // OpenPose 딥러닝 모델 로드
                    var imgHeight = img.Height; // 이미지 높이
                    var imgWidth = img.Width; // 이미지 너비

                    // 이미지를 Blob 형식으로 변환
                    var blob = DnnInvoke.BlobFromImage(img, 1.0 / 255.0, new Size(inWidth, inHeight), new MCvScalar(0, 0, 0));
                    net.SetInput(blob);
                    net.SetPreferableBackend(Emgu.CV.Dnn.Backend.OpenCV);

                    var output = net.Forward(); // 예측 실행

                    var H = output.SizeOfDimension[2]; // 히트맵 높이
                    var W = output.SizeOfDimension[3]; // 히트맵 너비
                    var HeatMap = output.GetData(); // 히트맵 데이터 가져오기

                    _points.Clear(); // 좌표 포인트 초기화

                    for (int i = 0; i < nPoints; i++)
                    {
                        Matrix<float> matrix = new Matrix<float>(H, W); // 히트맵을 행렬로 변환

                        for (int row = 0; row < H; row++)
                        {
                            for (int col = 0; col < W; col++)
                            {
                                matrix[row, col] = (float)HeatMap.GetValue(0, i, row, col); // 히트맵 데이터 저장
                            }
                        }

                        double minVal = 0, maxVal = 0; // 최소값과 최대값 초기화
                        Point minLoc = default, maxLoc = default; // 최소값 좌표와 최대값 좌표 초기화

                        CvInvoke.MinMaxLoc(matrix, ref minVal, ref maxVal, ref minLoc, ref maxLoc); // 최소값과 최대값 계산

                        var x = (img.Width * maxLoc.X) / W; // x 좌표 계산
                        var y = (img.Height * maxLoc.Y) / H; // y 좌표 계산

                        if (maxVal > threshold) // 최대값이 임계값보다 크면 유효한 포인트로 간주
                        {
                            _points.Add(new Point(x, y)); // 좌표 포인트 추가
                        }
                        else
                        {
                            _points.Add(Point.Empty); // 유효하지 않은 포인트는 Empty로 추가
                        }
                    }

                    // 출력할 랜드마크 인덱스
                    var targetLandmarks = new List<int>() { 0, 1, 2, 5, 15, 16, 17, 18 };

                    // 이미지에 좌표 포인트 표시
                    for (int i = 0; i < _points.Count; i++)
                    {
                        var p = _points[i];
                        if (targetLandmarks.Contains(i) && p != Point.Empty && p.X != 0 && p.Y !=0)
                        {
                            CvInvoke.Circle(img, p, 5, new MCvScalar(0, 255, 0), -1); // 포인트를 원으로 표시
                            CvInvoke.PutText(img, i.ToString(), p, FontFace.HersheySimplex, 0.8, new MCvScalar(0, 0, 255), 1, LineType.AntiAlias); // 포인트 번호 텍스트 추가

                            // 좌표값 출력
                            var coordinates = $"[{p.X}, {p.Y}]";
                            //textBox1.AppendText($"Point {i}: {coordinates}\n\n");
                        }
                    }

                
                    // 스켈레톤 그리기
                    for (int i = 0; i < point_pairs.GetLength(0); i++)
                    {
                        var startIndex = point_pairs[i, 0]; // 시작 인덱스
                        var endIndex = point_pairs[i, 1]; // 종료 인덱스

                        if (_points.Contains(_points[startIndex]) && _points.Contains(_points[endIndex])) // 유효한 포인트가 있는 경우
                        {
                            if (_points[startIndex].X != 0 && _points[endIndex].X != 0) 
                                CvInvoke.Line(img, _points[startIndex], _points[endIndex], new MCvScalar(255, 0, 0), 2); // 선으로 스켈레톤 그리기
                        }
                    }

                    double length1718 = CalculateSkeletonLength(_points, 17, 18);
                    double imageWidth = img.Width;
                    double percentage = (length1718 / imageWidth) * 100;
                    Debug.Write("\n---------------------");
                    Debug.Write("\n화면 너비 : " + imageWidth);
                    Debug.Write("\n눈 길이: " + length1718);
                    Debug.Write("\n화면 대비 비율:" + percentage);

                    if (percentage > 28)
                    {
                        if (_points[2].Y > _points[5].Y + 10 || _points[5].Y > _points[2].Y + 10)
                        {
                            if (_points[17].X != 0 && _points[18].X != 0 && _points[2].Y != 0 && _points[5].Y != 0)
                            {
                                analyzeData.Result = "거북목, 척추 측만증";
                                _data.SaveImageToFile(img, analyzeData.Result);
                            }
                        }
                        else
                        {
                            analyzeData.Result = "거북목";
                            _data.SaveImageToFile(img, analyzeData.Result);
                        }
                    }
                    else if (percentage < 28)
                    {
                        if (_points[2].Y > _points[5].Y + 10 || _points[5].Y > _points[2].Y + 10)
                        {
                            if (_points[2].Y != 0 && _points[5].Y != 0) analyzeData.Result = "척추 측만증";
                            _data.SaveImageToFile(img, analyzeData.Result);
                        }

                        else
                        {
                            analyzeData.Result = "정상";
                        }
                    }



                    Debug.Write("\n왼쪽 어깨 : " + " X : " + _points[2].X + " Y : " + _points[2].Y);
                    Debug.Write("\n오른쪽 어깨 : " + " X : " + _points[5].X + " Y : " + _points[5].Y);
                    //if (_points[2].Y > _points[5].Y+15 || _points[2].Y > _points[5].Y -15) analyzeData.Result = "척추 측만증";
                    //else analyzeData.Result = "정상";

                    /*
                    // 스켈레톤 길이 계산
                    double length01 = CalculateSkeletonLength(_points, 0, 1);
                    double length02 = CalculateSkeletonLength(_points, 0, 2);
                    double length12 = CalculateSkeletonLength(_points, 1, 2);
                    double length15 = CalculateSkeletonLength(_points, 1, 5);
                    double length25 = CalculateSkeletonLength(_points, 2, 5);
                    */

                    //Debug.Write("\n**********0-1 :", length01.ToString());
                    //Debug.Write("2-5 :", length25.ToString());



                    // 0~1/2~5 스켈레톤 길이 비율 계산
                    //double ratio02_01 = length01 / length25;
                    //Debug.Write("\n\n목/어깨 :", ratio02_01.ToString());



                    analyzeData.AnalyzedImage = img.ToBitmap();
                    //이미지 파일 로컬에 저장

                    backgroundWorker.ReportProgress(0, analyzeData);
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private double CalculateSkeletonLength(List<Point> points, int startIndex, int endIndex)
            {
                var startPoint = points[startIndex];
                var endPoint = points[endIndex];

                double length = Math.Sqrt(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2));
                return length;
            }
            public void Dispose()
            {
                _frame?.Dispose();
                _cap?.Dispose();
                _poseNet?.Dispose();
                _backgroundWorker?.Dispose();
            }
        }
    }
