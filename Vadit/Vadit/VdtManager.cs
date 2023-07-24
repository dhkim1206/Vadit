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
    public class VdtManager
    {
        private VideoCapture _cap = null; // 카메라 설정을 위한 변수 선언
        private Mat _frame = null; // 프레임을 저장하기 위한 변수 선언
        private Dictionary<string, Image<Bgr, byte>> IMGDict; // 이미지를 저장하는 Dictionary 선언 (Key: string, Value: Image<Bgr, byte>)
        private Net _poseNet = null; // OpenPose 딥러닝 모델을 로드하는 변수 선언
        private List<Point> _points; // 각 랜드마크를 저장하는 리스트 선언
        private PictureBox _pictureBox; // 이미지를 출력하기 위한 PictureBox


        //BackgroundWorker _backgroundWorker; // 비동기 작업을 수행하기 위한 BackgroundWorker


        public VdtManager()
        {
            IMGDict = new Dictionary<string, Image<Bgr, byte>>(); // 이미지를 저장하기 위한 Dictionary 객체 생성
            _cap = new VideoCapture(0); // 카메라를 열고 설정하기 위한 VideoCapture 객체 생성 (0은 기본 카메라를 나타냄)
            _poseNet = ReadPoseNet(); // OpenPose 딥러닝 모델을 로드
            _points = new List<Point>(); // 랜드마크 좌표를 저장하기 위한 List 초기화
            _pictureBox = new PictureBox(); // 이미지를 출력하기 위한 PictureBox 객체 생성
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
                    Debug.Write("Call  DetectAndDrawSkeleton");
                    DetectAndDrawSkeleton(img, worker);

                }
            }
        }
        /*
        // 디렉토리에서 사진 불러오기 위한 메서드
        public void LoadImage(string filePath)
        {
            try
            {
                var img = new Image<Bgr, byte>(filePath); // 파일에서 이미지 로드
                if (IMGDict.ContainsKey("input"))
                {
                    IMGDict["input"]?.Dispose();
                    IMGDict.Remove("input"); // 기존 "input" 키에 저장된 이미지 제거
                }
                IMGDict.Add("input", img); // 로드한 이미지를 "input" 키로 Dictionary에 추가
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

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
        private void DetectAndDrawSkeleton(Image<Bgr, byte> img, BackgroundWorker backgroundWorker)
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
                Debug.Write("Draw Image");

                //
                _pictureBox.Image = img.ToBitmap(); // 이미지 출력
                if (_pictureBox.Image != null) backgroundWorker.ReportProgress(0, img);
                
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
