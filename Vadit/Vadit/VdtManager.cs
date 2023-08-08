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
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Vadit
{
    public class InfoInputCorrectPose   //입력받은 자세의 좌푯값
    {
        public Image<Bgr, byte> _img = null;
        public List<Point> _point = null;
        public double _ratio = 0;
        int[] _indexes;
        public bool _isPointNotNull = false;
        public void setInfo(Image<Bgr, byte> img, List<Point> points)
        {
            this._img = img;
            this._point = points;
            if (Math.Abs(points[0].Y - points[1].Y) != 0)
                this._ratio = (double)Math.Abs(points[2].X - points[5].X) / (double)Math.Abs(points[0].Y - points[1].Y);

            this.IsPointNotNull();
            Debug.WriteLine($"설정된 자세: {_ratio:F3}");
            Debug.WriteLine($"어깨 길이: {Math.Abs(points[2].X - points[5].X):F3}");
            Debug.WriteLine($"목길이: {Math.Abs(points[0].X - points[1].X):F3}");

        }
        public void IsPointNotNull()
        {
            if (_point == null)
                this._isPointNotNull = false;
            else
            {
                int c = 0;
                _indexes = new int[] { 0, 1, 2, 5, 15, 16, 17, 18 };
                foreach (int i in _indexes)
                {
                    if (_point[i].X == 0 || _point[i].Y == 0)
                        c++;
                }
                if (c == 0)
                    this._isPointNotNull = true;
                else if (c > 0)
                    this._isPointNotNull = false;
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
        public BackgroundWorker _bgw = null;
        public InfoInputCorrectPose _infoInputCorrectPose = new InfoInputCorrectPose();
        private VideoCapture _cap = null;
        private Mat _frame = null;
        public bool _isInputCorrrctPose = false;//드로우 스켈레톤에서 이게 올바른자세 입력한 이미지인지 아닌지 판별하기위해
        private Net _poseNet = null; 
        private List<Point> _points;
        Data _data;

        public VdtManager(ProgressChangedEventHandler OnProgressing)
        {
            _poseNet = ReadPoseNet(); // OpenPose 딥러닝 모델을 로드
            _points = new List<Point>(); // 랜드마크 좌표를 저장하기 위한 List 초기화
            _data = new Data();

            _bgw = new BackgroundWorker(); // 백그라운드 워커 객체 생성
            _bgw.WorkerReportsProgress = true; // 중간 보고 할거냐, 이걸 해줘야 중간보고를 할 수 있음
            _bgw.DoWork += new DoWorkEventHandler(OnDoWork); // 엔트리 포인트, 실행 할 함수를 매개변수로 줌
            _bgw.ProgressChanged += new ProgressChangedEventHandler(OnProgressing); // 진행중인 진행 상활을 보고 받을거임
            _bgw.WorkerSupportsCancellation = true;
            // _backgroundWorker.RunWorkerAsync();

        }
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            _cap = new VideoCapture(0);
            while (true)
            {
                if (_cap != null)
                    {
                        Debug.WriteLine("무한루프 시작");
                        if (_bgw.CancellationPending)
                        {
                            e.Cancel = true;
                            Debug.WriteLine("쓰레드 중단");
                            return;
                        }
                        if (_isInputCorrrctPose == true)
                        {

                            Debug.WriteLine("사진 입력받는중");
                            _frame = new Mat();
                            AnalyzeData _analyzeData = new AnalyzeData();
                            _cap.Read(_frame);
                            _analyzeData.Frame = _frame;
                            _analyzeData.Result = "바른 자세를 입력하고있습니다.";
                            _analyzeData.AnalyzedImage = _frame.ToBitmap();
                            _bgw.ReportProgress(0, _analyzeData);

                        }
                        else
                            ProcessFrameAndDrawSkeleton(_bgw);
                    }
                
                Thread.Sleep(200);
            }
        }
        // 프레임 캡처하고 스켈레톤을 탐지하고 그리기 위한 메서드 (비동기 작업을 위해 BackgroundWorker를 매개변수로 받음)
        public void ProcessFrameAndDrawSkeleton(BackgroundWorker worker)
        {
            _cap = new VideoCapture(0);
            if (_cap != null)  
                
            {

                if (_cap.IsOpened)
                {
                    _frame = new Mat();
                    _cap.Read(_frame); // 카메라에서 프레임 캡처
                    if (!_frame.IsEmpty)
                    { //w중단점 해보고 화요일 여기서부터 해보기
                        var img = _frame.ToImage<Bgr, byte>(); // 프레임을 Image<Bgr, byte> 형식으로 변환

                        // 스켈레톤을 탐지하고 그리기 위한 메서드 호출
                        DrawSkeleton(img, worker); 
                    }
                }
            }

            return;
        }
        // 스켈레톤 탐지하고 그리기 위한 메서드
        private void DrawSkeleton(Image<Bgr, byte> img, BackgroundWorker backgroundWorker)
        {
            try
            {
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
                    AppGlobal.CorrectPose.setInfo(img, _points);
                    Debug.WriteLine("17번:[" + _infoInputCorrectPose._point[17].X + "," + _infoInputCorrectPose._point[17].Y + "]");
                    Debug.WriteLine("15번:[" + _infoInputCorrectPose._point[15].X + "," + _infoInputCorrectPose._point[15].Y + "]");
                    Debug.WriteLine("0번:[" + _infoInputCorrectPose._point[0].X + "," + _infoInputCorrectPose._point[0].Y + "]");
                    Debug.WriteLine("16번:[" + _infoInputCorrectPose._point[16].X + "," + _infoInputCorrectPose._point[16].Y + "]");
                    Debug.WriteLine("18번:[" + _infoInputCorrectPose._point[18].X + "," + _infoInputCorrectPose._point[18].Y + "]");
                    Debug.WriteLine("2번:[" + _infoInputCorrectPose._point[2].X + "," + _infoInputCorrectPose._point[2].Y + "]");
                    Debug.WriteLine("5번:[" + _infoInputCorrectPose._point[5].X + "," + _infoInputCorrectPose._point[5].Y + "]");
                    Debug.WriteLine("1번:[" + _infoInputCorrectPose._point[1].X + "," + _infoInputCorrectPose._point[1].Y + "]");
                }
                else if (!_isInputCorrrctPose)
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
        private Net ReadPoseNet()
        {
            string prototxt = @"C:\openpose\models\pose\body_25\pose_deploy.prototxt";
            string modelPath = @"C:\openpose\models\pose\body_25\pose_iter_584000.caffemodel";
            return DnnInvoke.ReadNetFromCaffe(prototxt, modelPath);
        }
        // Caffe 형식의 OpenPose 딥러닝 모델을 로드하여 반환
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
            int[] _indexes;
            int c = 0;

                _indexes = new int[] { 0, 1, 2, 5, 15, 16, 17, 18 };
                foreach (int i in _indexes)
                {
                    if (_points[i].X == 0 || _points[i].Y == 0)
                        c++;
                }
            if (c > 0)
                return;

            if (AppGlobal.CorrectPose._isPointNotNull && (Math.Abs(_points[0].X - _points[1].X) != 0))
                _ratio = ((double)Math.Abs(_points[2].X - _points[5].X)) / ((double)Math.Abs(_points[0].Y - _points[1].Y));
            if (_ratio == 0)
                return;

            Debug.WriteLine($"올바른 자세: {AppGlobal.CorrectPose._ratio:F3}");
            Debug.WriteLine($"현재측정: {_ratio:F3}");


            if (Math.Abs(_points[2].Y - _points[5].Y) > 20)
            {
                _analyzeData.Result += " <척추 측만증> ";
                conditionMet = true;
            }
            if (_ratio > AppGlobal.CorrectPose._ratio + 0.6)
            {
                _analyzeData.Result += " <거북목> ";
                conditionMet = true;

            }
            if (_ratio < AppGlobal.CorrectPose._ratio + 3)
            {
                _analyzeData.Result += " <추간판 탈출> ";
                conditionMet = true;
            }

            if (!conditionMet)
            {
                _analyzeData.Result = " <정상> ";
                _data.UpdateGoodPoseCnt_Score();
            }
            else
            {
                _data.UpdateBadPoseCnt_Score();

            }

            _data.SaveImageToFile(time, img, _analyzeData.Result);
            _data.InsertDB_BadPose(time, _analyzeData.Result);
            //_data.UpdatePoseCnt_Score(analyzeData.Result);

            _analyzeData.AnalyzedImage = img.ToBitmap();
            backgroundWorker.ReportProgress(0, _analyzeData);
        }


        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓바른 자세입력에 관한 코드↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        public void StartSettingCorrectPose() //formcamera 초기화와 함께 호출됨. 자세입력 트루 후 Run
        {
            if (_bgw.IsBusy)
                _bgw.CancelAsync();
            while (_bgw.IsBusy)
                Thread.Sleep(50);
            if (!_bgw.IsBusy)
            {
                Debug.WriteLine("자세 입력모드를 실행하겠습니다. 잠시만기다려주세요");

                _isInputCorrrctPose = true;
                _bgw.RunWorkerAsync();
            }
        }
        public Bitmap OnclikBtnResetPose() //사진을 찍어주는 메서드 이 객체 안에있는 올바른자세 정보에 사진을 넣음.
        {
            if (_cap.IsOpened)
            {
                _frame = new Mat();
                _cap.Read(_frame);
                var img = _frame.ToImage<Bgr, byte>();
                _infoInputCorrectPose._img = img;
                return _infoInputCorrectPose._img.ToBitmap();
            }
            else
                OnclikBtnResetPose();
                return _infoInputCorrectPose._img.ToBitmap();
        }



        public bool InputCorrectPose()  //자세 캡쳐 버튼 누르면 실행됨. 올바른 자세인지 아닌지 더불어 창닫기까지.
        {
            DrawSkeleton(_infoInputCorrectPose._img, _bgw);
            _infoInputCorrectPose.IsPointNotNull();
            if (!_infoInputCorrectPose._isPointNotNull)
            {
                MessageBox.Show("자세가 제대로 인식되지 않았습니다. 바른자세를 다시 입력해주세요.");
                return false;
            }
            else 
            {
                var confirmResult = MessageBox.Show("이 자세로 셋팅하시겠습니까?", "알림", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void EndPoseSetting()        //입력모드 끄고 백그라운드 종료
        {
            _isInputCorrrctPose = false;
            if (_bgw.IsBusy)
                _bgw.CancelAsync();
        }
        public void run()       //백그라운드 다시 실행
        {
            if (!_bgw.IsBusy)
                _bgw.RunWorkerAsync();
        }
        public void Dispose()   //할당해제
        {
            _frame?.Dispose();
            _cap?.Dispose();
            _poseNet?.Dispose();
            _bgw?.Dispose();
        }
        //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑바른 자세입력에 관한 코드↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


    }
}
