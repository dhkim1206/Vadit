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
        string path = "data_table.db";
        private FlowLayoutPanel _panel_imageFlowLayout;
        private Label _lb_TrutleNeck;
        private Label _lb_scoliosis;
        private Label _lb_herniations;
        private List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> _pictureInfoList;

        public DashBoardManager(FlowLayoutPanel imageFlowLayout, DateTime selectedDate, Label trutleNeck, Label scoliosis, Label herniations)
        {
            _panel_imageFlowLayout = imageFlowLayout;
            _lb_TrutleNeck = trutleNeck;
            _lb_scoliosis = scoliosis;
            _lb_herniations = herniations;
            _panel_imageFlowLayout.AutoScroll = true; // AutoScroll 속성을 False로 설정
            _pictureInfoList = LoadDataFromDatabase(selectedDate);
            Update_DashBoard();
        }
        public void ScrollUp()
        {
            // FlowLayoutPanel의 수직 스크롤을 위로 이동시킵니다.
            int scrollAmount = SystemInformation.VerticalScrollBarThumbHeight / 1000000; // 스크롤 양 조절
            SendMessage(_panel_imageFlowLayout.Handle, WM_VSCROLL, -(SB_LINEUP), 0);
        }

        public void ScrollDown()
        {
            // FlowLayoutPanel의 수직 스크롤을 아래로 이동시킵니다.
            int scrollAmount = SystemInformation.VerticalScrollBarThumbHeight / 1000000; // 스크롤 양 조절
            SendMessage(_panel_imageFlowLayout.Handle, WM_VSCROLL, SB_LINEDOWN, 0);
        }

        // Win32 API 메서드 사용을 위한 상수 정의
        private const int WM_VSCROLL = 0x0115;
        private const int SB_LINEUP = 0;
        private const int SB_LINEDOWN = 1;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void Update_DashBoard()
        {
            _panel_imageFlowLayout.Controls.Clear();
            int turtleneckSum = 0; // Turtleneck 값들의 총합을 저장할 변수 선언
            int scoliosisSum = 0; // Turtleneck 값들의 총합을 저장할 변수 선언
            int herniationsSum = 0; // Turtleneck 값들의 총합을 저장할 변수 선언

            foreach (var pictureInfo in _pictureInfoList)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = _panel_imageFlowLayout.Height;
                pictureBox.Height = _panel_imageFlowLayout.Height;
                pictureBox.Padding = new Padding(5); // 여백 추가
                pictureBox.Image = Image.FromFile(pictureInfo.ImagePath);


                int turtleneckValue = pictureInfo.Turtleneck; // 현재 pictureInfo의 Turtleneck 값
                turtleneckSum += turtleneckValue; // Turtleneck 값을 더하여 총합 갱신

                int scoliosisValue = pictureInfo.Scoliosis; // 현재 pictureInfo의 Scoliosis 값
                scoliosisSum += scoliosisValue; // Scoliosis 값을 더하여 총합 갱신

                int herniationsValue = pictureInfo.Herniations; // 현재 pictureInfo의 Herniations 값
                herniationsSum += herniationsValue; // Herniations 값을 더하여 총합 갱신

                string categoryText = pictureInfo.Category;
                string fullDateTimeText = pictureInfo.Date.ToString("yyyy-MM-dd HH:mm:ss");

                using (Font font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    Bitmap imageWithText = new Bitmap(pictureBox.Image);

                    using (Graphics g = Graphics.FromImage(imageWithText))
                    {
                        using (Brush backgroundBrush = new SolidBrush(Color.Black))
                        {
                            g.FillRectangle(backgroundBrush, 0, 0, 650, 60);
                        }

                        SizeF textSize = g.MeasureString(categoryText, font);
                        float textX = (pictureBox.Width - textSize.Width) / 2 + 280;
                        float textY = pictureBox.Height - textSize.Height + 350;
                        g.DrawString(categoryText, font, Brushes.Yellow, new PointF(textX, textY));
                        g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(75, 0));
                    }
                    pictureBox.Image = imageWithText;

                    // 클릭 이벤트 핸들러 등록
                    pictureBox.Click += (sender, e) =>
                    {
                        // 배경색 변경
                        pictureBox.BackColor = Color.Red;

                        FormBigImage formBigImage = new FormBigImage(pictureBox.Image);
                        formBigImage.ShowDialog();
                    };
                }
                _lb_TrutleNeck.Text = "거북목 : " + turtleneckSum.ToString();
                _lb_scoliosis.Text = "척추 측만증 : "+scoliosisSum.ToString();
                _lb_herniations.Text = "추간판 탈출 : " + herniationsSum.ToString();

                if ((turtleneckSum + scoliosisSum + herniationsSum) == 0) { _lb_TrutleNeck.Text = ""; _lb_scoliosis.Text = ""; _lb_herniations.Text = ""; }


                _panel_imageFlowLayout.Controls.Add(pictureBox);
            }
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
            Update_DashBoard();
        }
    }
}
