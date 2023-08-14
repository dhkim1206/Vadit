using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            _panel_imageFlowLayout.AutoScroll = true; // AutoScroll 속성을 False로 설정
            _pictureInfoList = LoadDataFromDatabase(selectedDate);
            UpdateDashBoard();
        }

        private void ConfigurePictureBoxClickEvent(PictureBox pictureBox)
        {
            pictureBox.Click += (sender, e) =>
            {
                if (_selectedPictureBox != null)
                {
                    _selectedPictureBox.BackColor = Color.Transparent;
                }

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
                    g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(95, 5));
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
            List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> pictureInfoList = new List<(string, string, DateTime, int, int, int)>();

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                con.Open();

                string query = @"SELECT ImageData.ImagePath, ImageData.Category, BadPose.Date, BadPose.TurtleNeck, BadPose.Scoliosis, BadPose.Herniations
                                FROM ImageData
                                LEFT JOIN BadPose ON strftime('%Y-%m-%d', ImageData.Date) = strftime('%Y-%m-%d', BadPose.Date)
                                WHERE strftime('%Y-%m-%d', BadPose.Date) = strftime('%Y-%m-%d', @SelectedDate)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imagePath = reader.GetString(0);
                            string category = reader.GetString(1);
                            DateTime date = reader.GetDateTime(2);
                            int turtleneck = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            int scoliosis = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            int herniations = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            pictureInfoList.Add((imagePath, category, date, turtleneck, scoliosis, herniations));
                        }
                    }
                }
            }

            return pictureInfoList;
        }

        public void ShowImagesForSelectedDate(DateTime selectedDate)
        {
            _pictureInfoList = LoadDataFromDatabase(selectedDate);
            UpdateDashBoard();
        }
    }
}
