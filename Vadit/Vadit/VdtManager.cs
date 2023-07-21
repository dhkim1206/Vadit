using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vadit
{
    public class VdtManager : IDisposable
    {
        private VideoCapture _cap = null; //카메라 설정 할 변수 선언
        private Mat _frame = null; // 프레임 받을 변수 선언
        private Dictionary<string, Image<Bgr, byte>> IMGDict; // string키 값과 이미지 형태의 Value를 저장
        private Net _poseNet = null;
        private List<Point> _points;
        private PictureBox _pictureBox; //

        BackgroundWorker _backgroundWorker;

        public VdtManager()
        {
            IMGDict = new Dictionary<string, Image<Bgr, byte>>(); // 객체 생성
            _cap = new VideoCapture(0); // 카메라 설정
            _poseNet = ReadPoseNet();
            _points = new List<Point>(); // 각 랜드마크 저장할 리스트 저장
            _pictureBox = new PictureBox(); // 


        }

        private Net ReadPoseNet()
        {
            string prototxt = @"C:\openpose-master\models\pose\body_25\pose_deploy.prototxt";
            string modelPath = @"C:\openpose-master\models\pose\body_25\pose_iter_584000.caffemodel";
            return DnnInvoke.ReadNetFromCaffe(prototxt, modelPath);
        }

        // 프레임 받아오고 스켈레톤 탐지 및 그리기 호출
        public void CaptureFrameAndDetectSkeleton(BackgroundWorker backgroundWorker)
        {

            if (_cap.IsOpened)
            {
                _frame = new Mat();
                _cap.Read(_frame);

                if (!_frame.IsEmpty)
                {
                    var img = _frame.ToImage<Bgr, byte>();
                    if (IMGDict.ContainsKey("input"))
                    {
                        IMGDict["input"]?.Dispose();
                        IMGDict.Remove("input");
                    }
                    IMGDict.Add("input", img);

                    // Detect and draw skeleton
                    DetectAndDrawSkeleton(img);
                }
            }
        }

        // 디셔너리에서 사진 불러오기
        public void LoadImage(string filePath)
        {
            try
            {
                var img = new Image<Bgr, byte>(filePath);
                if (IMGDict.ContainsKey("input"))
                {
                    IMGDict["input"]?.Dispose();
                    IMGDict.Remove("input");
                }
                IMGDict.Add("input", img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image<Bgr, byte> GetImage()
        {
            if (IMGDict.ContainsKey("input"))
            {
                return IMGDict["input"]?.Clone();
            }
            return null;
        }

        private void DetectAndDrawSkeleton(Image<Bgr, byte> img){
            try
            {
                if (!IMGDict.ContainsKey("input"))
                {
                    throw new Exception("Please read in an image first.");
                }

                // 이미지 처리를 위한 초기 설정
                int inWidth = 368;  // 이미지 사이즈 설정
                int inHeight = 368;
                float threshold = 0.1f;  // 쓰레쉬 홀드 값
                int nPoints = 25;  // 추출할 포인트 수

                var BODY_PARTS = new Dictionary<string, int>() {
                    { "Nose", 0 },
                    { "Neck", 1 },
                    { "RShoulder", 2 },
                    {"LShoulder",5},
                };


                int[,] point_pairs = new int[,] {
                    { 1, 0 }, { 1, 2 }, { 1, 5 },
                    { 15, 17 }, { 16, 18 }, { 0, 16 },
                    { 0, 15 }
                };

                var net = ReadPoseNet();
                var imgHeight = img.Height; // 이미지 높이
                var imgWidth = img.Width; // 이미지 너비

                // 이미지를 Blob 형식으로 변환
                var blob = DnnInvoke.BlobFromImage(img, 1.0 / 255.0, new Size(inWidth, inHeight), new MCvScalar(0, 0, 0)); // 이미지로부터 Blob 생성
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
                    if (targetLandmarks.Contains(i) && p != Point.Empty)
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
                        CvInvoke.Line(img, _points[startIndex], _points[endIndex], new MCvScalar(255, 0, 0), 2); // 선으로 스켈레톤 그리기
                    }
                }
                Debug.Write("CameraCapture~");
                _pictureBox.Image = img.ToBitmap(); // 이미지 출력
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Dispose()
        {
            _frame?.Dispose();
            _cap?.Dispose();
            _poseNet?.Dispose();
        }

    }
}
