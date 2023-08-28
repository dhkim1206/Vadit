using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static Vadit.AppBase;
namespace Vadit
{
    public class DashBoardManager
    {
        private PictureBox _selectedPictureBox; // 현재 선택된 PictureBox를 저장하는 변수

        private Panel _panel;
        private string path = "data_table.db";
        private FlowLayoutPanel _panel_imageFlowLayout;
        private Label _lb_BadPoseCnt;


        private List<(string ImagePath, string Category)> _imageinfoList;
        private List<(DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> _badPoseInfoList;

        int _current = 1;

        public DashBoardManager(Panel panel, FlowLayoutPanel imageFlowLayout, DateTime selectedDate, Label badPoseCnt)
        {
            _panel = panel;
            _panel_imageFlowLayout = imageFlowLayout;
            _lb_BadPoseCnt = badPoseCnt;
            _panel_imageFlowLayout.AutoScroll = true;

            // Initialize the lists
            _imageinfoList = new List<(string ImagePath, string Category)>();
            _badPoseInfoList = new List<(DateTime Date, int Turtleneck, int Scoliosis, int Herniations)>();

            LoadDataFromDB(selectedDate.Date);
            UpdateDashBoard();
        }

        private void ConfigurePictureBoxClickEvent(PictureBox pictureBox)
        {
            pictureBox.Click += (sender, e) =>
            {
                if (_selectedPictureBox != null) _selectedPictureBox.BackColor = Color.Transparent;

                _selectedPictureBox = (PictureBox)sender;
                _selectedPictureBox.BackColor = Color.Red;

                FormBigImage formBigImage = new FormBigImage(_selectedPictureBox.Image);
                formBigImage.ShowDialog();
            };
        }

        private void UpdateLabels(int sum, int turtleneckSum, int scoliosisSum, int herniationsSum)
        {
            _lb_BadPoseCnt.Text = " 검출된 자세 : " + sum.ToString() + " ,    거북목 : " + turtleneckSum.ToString() + " ,    척추 측만증 : " + scoliosisSum.ToString() + " ,    추간판 탈출 : " + herniationsSum.ToString();

            if ((turtleneckSum + scoliosisSum + herniationsSum) == 0)
            {
                _lb_BadPoseCnt.Text = "";
            }

        }
        private void ClearLabel()
        {
            _lb_BadPoseCnt.Text = "";
        }

        private void UpdateDashBoard()
        {
            _current = 1;
            _panel.Hide();
            ClearLabel();
            _panel_imageFlowLayout.Controls.Clear();

            int turtleneckSum = 0;
            int scoliosisSum = 0;
            int herniationsSum = 0;

            if (_badPoseInfoList.Count == 0)
            {
                Label noDataLabel = new Label();
                noDataLabel.Text = "데이터가 없음";
                noDataLabel.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
                noDataLabel.ForeColor = Color.White;
                noDataLabel.TextAlign = ContentAlignment.MiddleCenter;
                noDataLabel.Dock = DockStyle.Fill;

                _panel_imageFlowLayout.Controls.Add(noDataLabel);
                _panel.Show();
            }
            for (int i = 0; i < _badPoseInfoList.Count; i++)
            {
                var badposeInfo = _badPoseInfoList[i];
                var imageInfo = _imageinfoList[i];

                Debug.WriteLine(" 픽쳐 인포 : " + badposeInfo);
                PictureBox pictureBox = CreatePictureBox(imageInfo, badposeInfo, _badPoseInfoList.Count);
                ConfigurePictureBoxClickEvent(pictureBox);

                turtleneckSum += badposeInfo.Turtleneck;
                Debug.WriteLine(" 거북목 : " + turtleneckSum);

                scoliosisSum += badposeInfo.Scoliosis;
                Debug.WriteLine(" 척추 측만증 : " + scoliosisSum);

                herniationsSum += badposeInfo.Herniations;
                Debug.WriteLine(" 추가판 탈출 : " + herniationsSum);

                _panel_imageFlowLayout.Controls.Add(pictureBox);
            }

            UpdateLabels(_badPoseInfoList.Count, turtleneckSum, scoliosisSum, herniationsSum);

        }
        private PictureBox CreatePictureBox((string ImagePath, string Category) ImageInfo, (DateTime Date, int Turtleneck, int Scoliosis, int Herniations) badposeInfo, int count)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = _panel_imageFlowLayout.Height;
            pictureBox.Height = _panel_imageFlowLayout.Height;
            pictureBox.Padding = new Padding(5);
            pictureBox.Image = Image.FromFile(ImageInfo.ImagePath);

            string categoryText = ImageInfo.Category;
            if (categoryText.EndsWith(","))
            {
                categoryText = categoryText.Substring(0, categoryText.Length - 1);
            }
            string fullDateTimeText = badposeInfo.Date.ToString("yyyy-MM-dd HH:mm:ss");

            using (Font font = new Font(FontFamily.GenericSansSerif, 35, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                Bitmap imageWithText = new Bitmap(pictureBox.Image);

                using (Graphics g = Graphics.FromImage(imageWithText))
                {
                    using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(32, 33, 36)))
                    {
                        g.FillRectangle(backgroundBrush, 0, 0, 650, 60);
                    }
                    using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(32, 33, 36)))
                    {
                        g.FillRectangle(backgroundBrush, 0, 445, 350, 40);
                    }

                    if (categoryText.Length >= 13) g.DrawString(categoryText, font, Brushes.Yellow, new PointF(120, 13));
                    else if (10 <= categoryText.Length && categoryText.Length < 12) g.DrawString(categoryText, font, Brushes.Yellow, new PointF(135, 13));
                    else if (categoryText.Length < 5) g.DrawString(categoryText, font, Brushes.Yellow, new PointF(240, 13));
                    else
                    {
                        g.DrawString(categoryText, font, Brushes.Yellow, new PointF(210, 13));
                    }

                    g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(0, 445));

                    using (Font font1 = new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (_current < count + 1)
                        {
                            g.DrawString(_current.ToString() + ".", font1, Brushes.Yellow, new PointF(0, 0));
                            _current++;
                        }
                    }
                }

                pictureBox.Image = imageWithText;
            }

            return pictureBox;
        }

        //List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)>
        private void LoadDataFromDB(DateTime selectedDate)
        {
            // 이전 데이터를 제거
            _badPoseInfoList?.Clear();
            _imageinfoList?.Clear();

            // SQLite 데이터베이스 연결을 생성
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                // 데이터베이스 연결
                con.Open();

                // 이미지와 관련 정보 조회하는 쿼리
                string imageQuery = @"SELECT ImagePath, Category FROM ImageData WHERE strftime('%Y-%m-%d', Date) = strftime('%Y-%m-%d', @SelectedDate)";

                // SQLiteCommand 개체를 생성하고 쿼리와 데이터베이스 연결을 연결
                using (SQLiteCommand cmd = new SQLiteCommand(imageQuery, con))
                {
                    // 쿼리 매개변수를 설정합니다.
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // 결과를 한 줄씩 리드
                        while (reader.Read())
                        {
                            // 각 열의 데이터를 추출
                            string imagePath = reader.GetString(0);
                            string category = reader.GetString(1);

                            // 추출한 데이터를 pictureInfoList에 추가
                            _imageinfoList.Add((imagePath, category));
                        }
                    }
                }
                // BadPose 정보 조회하는 쿼리
                string badPoseQuery = @"SELECT Date, TurtleNeck, Scoliosis, Herniations FROM BadPose WHERE strftime('%Y-%m-%d', Date) = strftime('%Y-%m-%d', @SelectedDate)";

                // BadPose 정보 조회
                using (SQLiteCommand badPoseCmd = new SQLiteCommand(badPoseQuery, con))
                {
                    badPoseCmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    using (SQLiteDataReader badPoseReader = badPoseCmd.ExecuteReader())
                    {
                        while (badPoseReader.Read())
                        {
                            DateTime date = badPoseReader.GetDateTime(0);
                            int turtleneck = badPoseReader.GetInt32(1);
                            int scoliosis = badPoseReader.GetInt32(2);
                            int herniations = badPoseReader.GetInt32(3);

                            // 추출한 데이터를 badPoseInfoList에 추가
                            _badPoseInfoList.Add((date, turtleneck, scoliosis, herniations));
                        }
                    }
                }
            }
        }
        public void ShowImagesForSelectedDate(DateTime selectedDate)
        {
            _badPoseInfoList.Clear();
            LoadDataFromDB(selectedDate.Date);
            AppConf.ConfigSet.poseScore = 0;
            //Debug.WriteLine(_pictureInfoList.Count);
            UpdateDashBoard();
        }
    }
}
