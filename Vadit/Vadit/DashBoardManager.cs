using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vadit
{
    public class DashBoardManager
    {
        private PictureBox _selectedPictureBox; // 현재 선택된 PictureBox를 저장하는 변수


        private Panel _panel;
        private string path = "data_table.db";
        private FlowLayoutPanel _panel_imageFlowLayout;
        private Label _lb_BadPoseCnt;
        private Label _lb_TrutleNeck;
        private Label _lb_scoliosis;
        private Label _lb_herniations;
        private List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> _pictureInfoList;

        int _current = 1;

        public DashBoardManager(Panel panel, FlowLayoutPanel imageFlowLayout, DateTime selectedDate,Label badPoseCnt, Label trutleNeck, Label scoliosis, Label herniations)
        {
            _panel = panel;
            _panel_imageFlowLayout = imageFlowLayout;
            _lb_BadPoseCnt = badPoseCnt;
            _lb_TrutleNeck = trutleNeck;
            _lb_scoliosis = scoliosis;
            _lb_herniations = herniations;
            _panel_imageFlowLayout.AutoScroll = true; 
            _pictureInfoList = LoadDataFromDatabase(selectedDate.Date);
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
            _lb_BadPoseCnt.Text = "안 좋은 자세 : " + sum.ToString();
            _lb_TrutleNeck.Text = "거북목 : " + turtleneckSum.ToString();
            _lb_scoliosis.Text = "척추 측만증 : " + scoliosisSum.ToString();
            _lb_herniations.Text = "추간판 탈출 : " + herniationsSum.ToString();

            if ((turtleneckSum + scoliosisSum + herniationsSum) == 0)
            {
                _lb_BadPoseCnt.Text = "";
                _lb_TrutleNeck.Text = "";
                _lb_scoliosis.Text = "";
                _lb_herniations.Text = "";
            }

        }
        private void ClearLabel()
        {
            _lb_BadPoseCnt.Text = "";
            _lb_herniations.Text = "";
            _lb_TrutleNeck.Text = "";
            _lb_scoliosis.Text = "";
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

            if (_pictureInfoList.Count == 0)
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
            foreach (var pictureInfo in _pictureInfoList)
            {
                //Debug.WriteLine(pictureInfo);
                PictureBox pictureBox = CreatePictureBox(pictureInfo, _pictureInfoList.Count);
                ConfigurePictureBoxClickEvent(pictureBox);

                turtleneckSum += pictureInfo.Turtleneck;
                scoliosisSum += pictureInfo.Scoliosis;
                herniationsSum += pictureInfo.Herniations;

                _panel_imageFlowLayout.Controls.Add(pictureBox);
            }

            UpdateLabels(_pictureInfoList.Count, turtleneckSum, scoliosisSum, herniationsSum);

        }

        private PictureBox CreatePictureBox((string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations) pictureInfo, int count)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Width = _panel_imageFlowLayout.Height;
            pictureBox.Height = _panel_imageFlowLayout.Height;
            pictureBox.Padding = new Padding(5);
            pictureBox.Image = Image.FromFile(pictureInfo.ImagePath);

            string categoryText = pictureInfo.Category;
            string fullDateTimeText = pictureInfo.Date.ToString("yyyy-MM-dd HH:mm:ss");

            using (Font font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular, GraphicsUnit.Pixel))
            {
                Bitmap imageWithText = new Bitmap(pictureBox.Image);

                using (Graphics g = Graphics.FromImage(imageWithText))
                {
                    using (Brush backgroundBrush = new SolidBrush(Color.Black))
                    {
                        g.FillRectangle(backgroundBrush, 0, 0, 650, 70);
                    }

                    SizeF textSize = g.MeasureString(categoryText, font);
                    float textX = (pictureBox.Width - textSize.Width) / 2 + 280;
                    float textY = pictureBox.Height - textSize.Height + 350;
                    g.DrawString(categoryText, font, Brushes.Yellow, new PointF(textX, textY));
                    g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(140, 5));

                    using (Font font1 = new Font(FontFamily.GenericSansSerif, 70, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (_current < count+1)
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

        private List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> LoadDataFromDatabase(DateTime selectedDate)
        {
            // 이전 데이터를 제거
            if (_pictureInfoList != null)
                _pictureInfoList.Clear();

            // 데이터를 저장할 리스트를 생성
            List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> pictureInfoList = new List<(string, string, DateTime, int, int, int)>();

            // SQLite 데이터베이스 연결을 생성
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                // 데이터베이스 연결
                con.Open();

                // 이미지와 관련 정보 조회하는 쿼리
                string imageQuery = @"SELECT ImagePath, Category FROM ImageData WHERE strftime('%Y-%m-%d', Date) = strftime('%Y-%m-%d', @SelectedDate)";

                // BadPose 정보 조회하는 쿼리
                string badPoseQuery = @"SELECT Date, TurtleNeck, Scoliosis, Herniations FROM BadPose WHERE strftime('%Y-%m-%d', Date) = strftime('%Y-%m-%d', @SelectedDate)";

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
                            DateTime date = DateTime.MinValue;
                            int turtleneck = 0;
                            int scoliosis = 0;
                            int herniations = 0;

                            // BadPose 정보 조회
                            using (SQLiteCommand badPoseCmd = new SQLiteCommand(badPoseQuery, con))
                            {
                                badPoseCmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                                using (SQLiteDataReader badPoseReader = badPoseCmd.ExecuteReader())
                                {
                                    if (badPoseReader.Read())
                                    {
                                        date = badPoseReader.GetDateTime(0);
                                        turtleneck = badPoseReader.GetInt32(1);
                                        scoliosis = badPoseReader.GetInt32(2);
                                        herniations = badPoseReader.GetInt32(3);
                                    }
                                }
                            }

                            // 추출한 데이터를 pictureInfoList에 추가
                            pictureInfoList.Add((imagePath, category, date, turtleneck, scoliosis, herniations));

                            //Debug.WriteLine(imagePath);
                        }
                    }

                    // 와일 루프가 끝난 후에 이미지 데이터 개수를 출력
                    //Debug.WriteLine("Total image count: " + pictureInfoList.Count);
                }
            }

            // 로드한 데이터가 담긴 리스트를 반환합니다.
            return pictureInfoList;
        }



        public void ShowImagesForSelectedDate(DateTime selectedDate)
        {
            _pictureInfoList.Clear();
            _pictureInfoList = LoadDataFromDatabase(selectedDate.Date);
            //Debug.WriteLine(_pictureInfoList.Count);
            UpdateDashBoard();
        }
    }
}
