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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Vadit
{
    public class InfoInputCorrectPose   //입력받은 자세의 좌푯값
    {
        public Image<Bgr, byte> _img;
        public List<Point> _point;
        public double _ratio;
        int[] _indexes;
        public bool _isPointNotNull = false;


        public void setInfo(Image<Bgr, byte> img, List<Point> points)
        {
            _img = img;
            _point = points;
            if (Math.Abs(points[0].X - points[1].X) != 0)
                _ratio = Math.Abs(points[2].X - points[5].X) / Math.Abs(points[0].X - points[1].X);
        }

        public void IsPointNotNull()
        {
            _indexes = new int[] { 0, 1, 2, 5, 15, 16, 17, 18 };
            foreach (int i in _indexes)
            { 
                if (_point[i].X == 0 || _point[i].Y == 0)
                    _isPointNotNull = false;
                else 
                    _isPointNotNull = true;
            }
        }
    }
    public class AnalyzeData
    {
        public Bitmap AnalyzedImage;
        public string Result;
        public Mat Frame = null;
    }

    public class VdtManager
    {
        BackgroundWorker _backgroundWorker;

        private VideoCapture _cap = null; // 카메라 설정을 위한 변수 선언
        private Mat _frame = null; // 프레임을 저장하기 위한 변수 선언
        private Dictionary<string, Image<Bgr, byte>> IMGDict; // 이미지를 저장하는 Dictionary 선언 (Key: string, Value: Image<Bgr, byte>)
        private InfoInputCorrectPose _infoInputCorrectPose = new InfoInputCorrectPose();

        private bool _isInputCorrrctPose = false;//드로우 스켈레톤에서 이게 올바른자세 입력한 이미지인지 아닌지 판별하기위해
        private bool _isPressbtnResetPose = false; //사진 입력버튼과 완료버튼 중복클릭 방지

        private Net _poseNet = null; // OpenPose 딥러닝 모델을 로드하는 변수 선언
        private List<Point> _points; // 각 랜드마크를 저장하는 리스트 선


        Data _data;

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
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.RunWorkerAsync();

        }
        //쓰레드로 돌릴 것들
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Debug.WriteLine("무한루프 시작");
                if (_backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    Debug.WriteLine("쓰레드 중단");
                    return;
                }
                ProcessFrameAndDrawSkeleton(_backgroundWorker);
                Debug.WriteLine("드로우 끝");
                Thread.Sleep(800);
            }
        }

        public void OnClikbtnReset()
        {
            if (_backgroundWorker.IsBusy)
            {
                MessageBox.Show("자세 입력모드를 실행하겠습니다. 잠시만기다려주세요");
            }
           
        }


        public AnalyzeData ReceiveCorrectPosture()
        {
                    OnClikbtnReset();
                    _isPressbtnResetPose = true;
                    Debug.WriteLine("사진 입력받는중");
                    _frame = new Mat();
                    _cap.Read(_frame);
                    AnalyzeData _analyzeData = new AnalyzeData();

                    _analyzeData.Frame = _frame;
                    _analyzeData.Result = "바른 자세를 입력하고있습니다.";
                    return _analyzeData;
        }


        public void CompletePoseInput() //올바른 자세 입력 완료 버튼을 누르면 실행
        {
            if (_isPressbtnResetPose == false)
                MessageBox.Show("먼저 자세입력을 눌러주세요");
            else if 
                (_backgroundWorker.IsBusy)
                MessageBox.Show("처리중입니다. 잠시만 기다려주세요!");
            else
            {
                Mat correctPose = ReceiveCorrectPosture().Frame;
                var img = correctPose.ToImage<Bgr, byte>();
                _isInputCorrrctPose = true;
                Debug.WriteLine("입력한 사진 AI처리중");
                DrawSkeleton(img, _backgroundWorker);
                _infoInputCorrectPose.IsPointNotNull();

                if (!_infoInputCorrectPose._isPointNotNull)
                { 
                    MessageBox.Show("자세가 제대로 인식되지 않았습니다. 바른자세를 다시 입력해주세요.");
                    return; 
                }
                
                _isInputCorrrctPose = false;
                Debug.WriteLine("사진 정보 저장 완료.");
                if (!_backgroundWorker.IsBusy)
                {
                    _backgroundWorker.RunWorkerAsync();
                    _isPressbtnResetPose = false;
                }
            }
        }

        // Caffe 형식의 OpenPose 딥러닝 모델을 로드하여 반환
        private Net ReadPoseNet()
        {
            string prototxt = Path.Combine(Application.StartupPath, "pose_deploy.prototxt");
            string modelPath = Path.Combine(Application.StartupPath, "pose_iter_584000.caffemodel");
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

                    DrawSkeleton(img, worker);
                }
            }
        }


        // "input" 키에 저장된 이미지를 반환하는 메서드
        public Image<Bgr, byte> GetImage()
        {
            if (IMGDict.ContainsKey("input"))
            {
                return IMGDict["input"]?.Clone(); // "input" 키에 저장된 이미지를 복사하여 반환
            }
            return null;
        }


        // 스켈레톤 탐지하고 그리기 위한 메서드
        private void DrawSkeleton(Image<Bgr, byte> img, BackgroundWorker backgroundWorker)
        {
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
                var output = net.Forward(); // 예측 실행-> 개오래 걸리는 코드
                Thread.Sleep(100);//쓰레드 캔슬을 위해 존재
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
                    if (targetLandmarks.Contains(i) && p != Point.Empty && p.X != 0 && p.Y != 0)
                    {
                        CvInvoke.Circle(img, p, 5, new MCvScalar(0, 255, 0), -1); // 포인트를 원으로 표시
                        CvInvoke.PutText(img, i.ToString(), p, FontFace.HersheySimplex, 0.8, new MCvScalar(0, 0, 255), 1, LineType.AntiAlias); // 포인트 번호 텍스트 추가
                    }
                }


                //double length25 = CalculateSkeletonLength(_points, 2, 5);
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



                if (_isInputCorrrctPose)  //만약 이게 입력한 바른자세 이미지라면~
                {
                    _infoInputCorrectPose.setInfo(img, _points);
                    Debug.WriteLine("17번:[" + _infoInputCorrectPose._point[17].X + "," + _infoInputCorrectPose._point[17].Y + "]");
                    Debug.WriteLine("15번:[" + _infoInputCorrectPose._point[15].X + "," + _infoInputCorrectPose._point[15].Y + "]");
                    Debug.WriteLine("0번:[" + _infoInputCorrectPose._point[0].X + "," + _infoInputCorrectPose._point[0].Y + "]");
                    Debug.WriteLine("16번:[" + _infoInputCorrectPose._point[16].X + "," + _infoInputCorrectPose._point[16].Y + "]");
                    Debug.WriteLine("18번:[" + _infoInputCorrectPose._point[18].X + "," + _infoInputCorrectPose._point[18].Y + "]");
                    Debug.WriteLine("2번:[" + _infoInputCorrectPose._point[2].X + "," + _infoInputCorrectPose._point[2].Y + "]");
                    Debug.WriteLine("5번:[" + _infoInputCorrectPose._point[5].X + "," + _infoInputCorrectPose._point[5].Y + "]");
                    Debug.WriteLine("1번:[" + _infoInputCorrectPose._point[1].X + "," + _infoInputCorrectPose._point[1].Y + "]");
                }
                else if (_infoInputCorrectPose._isPointNotNull)
                {
                    DetectPoseByRatio(img, _points, backgroundWorker);
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        // DrawSkeleton메서드 끝
        public void DetectPoseByLength(Image<Bgr, byte> img, List<Point> points, BackgroundWorker backgroundWorker)
        {
            AnalyzeData _analyzeData = new AnalyzeData();
            var _img = img;
            var _points = points;
            var _backgroundWorker = backgroundWorker;
            int _dtCorrectPose17to18 = Math.Abs(_infoInputCorrectPose._point[18].Y - _infoInputCorrectPose._point[17].Y);
            bool conditionMet = false;
            if (_infoInputCorrectPose._isPointNotNull)
            {
                _analyzeData.AnalyzedImage = img.ToBitmap();
                _analyzeData.Result += "올바른 자세를 입력해주세요";
                backgroundWorker.ReportProgress(0, _analyzeData);
                return;
            }

            if (_dtCorrectPose17to18 < Math.Abs(_points[18].X - _points[17].X + 15))
            {
                _analyzeData.Result += "거북목";
                conditionMet = true;
            }

            if (Math.Abs(_points[2].Y - _points[5].Y) > 10)
            {
                _analyzeData.Result += "척추 측만증";
                conditionMet = true;
            }
            if (_dtCorrectPose17to18 > Math.Abs(_points[18].X - _points[17].X + 15))
            {
                _analyzeData.Result += "추간판 탈출";
                conditionMet = true;
            }
            if (!conditionMet)
            {
                _analyzeData.Result = "정상";
            }

            _analyzeData.AnalyzedImage = img.ToBitmap();
            backgroundWorker.ReportProgress(0, _analyzeData);
        }

        public void DetectPoseByRatio(Image<Bgr, byte> img, List<Point> points, BackgroundWorker backgroundWorker)
        {   //비율로 디텍트하는 메서드. 길이랑 비교하는 메서드랑 비교 후 삭제.
            AnalyzeData _analyzeData = new AnalyzeData();
            _analyzeData.Result = null;
            var _img = img;
            var _points = points;
            var _backgroundWorker = backgroundWorker;
            bool conditionMet = false;
            double _ratio = 0;

            DateTime time = DateTime.Now;
            DateTime date = time.Date;

            if (!_infoInputCorrectPose._isPointNotNull)
            {
                _analyzeData.AnalyzedImage = img.ToBitmap();
                _analyzeData.Result = "올바른 자세를 입력해주세요";
                backgroundWorker.ReportProgress(0, _analyzeData);
                return;
            }

            if (_infoInputCorrectPose._isPointNotNull && (Math.Abs(_points[0].X - _points[1].X)!=0))
                _ratio = (Math.Abs(_points[2].X - _points[5].X)) / (Math.Abs(_points[0].X - _points[1].X));
            

            if (Math.Abs(_points[2].Y - _points[5].Y) > 15)
            {
                _analyzeData.Result += "척추 측만증, ";
                conditionMet = true;
            }
            if (_ratio > _infoInputCorrectPose._ratio + 0.4)
            {
                _analyzeData.Result += "거북목, ";
                conditionMet = true;

            }
            if (_ratio < _infoInputCorrectPose._ratio + 0.5)
            {
                _analyzeData.Result += "추가판 탈출, ";
                conditionMet = true;
            }

            if (!conditionMet)
            {
                _analyzeData.Result = "정상";
                _data.UpdateGoodPoseCnt_Score(date);
            }
            else
            {
                _data.UpdateBadPoseCnt_Score(date);
                _data.SaveImageToFile(time, img, _analyzeData.Result);

            }
            _data.InsertDB_BadPose(time, _analyzeData.Result);
            //_data.UpdatePoseCnt_Score(analyzeData.Result);

            _analyzeData.AnalyzedImage = img.ToBitmap();
            backgroundWorker.ReportProgress(0, _analyzeData);
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
        public void CancelBackgruondWorker()
        {

            if (_backgroundWorker.IsBusy)
            {

                Debug.WriteLine("Worker So Busy");
                _backgroundWorker.CancelAsync();
                Debug.WriteLine("캔슬 실행");
            }
        }
    }
}
