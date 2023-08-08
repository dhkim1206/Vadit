using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vadit
{
    public class FlowPanelManager
    {
        string path = "data_table.db";
        private FlowLayoutPanel _imageFlowLayout;
        private List<(string ImagePath, string Category, DateTime Date, int Turtleneck, int Scoliosis, int Herniations)> _pictureInfoList;

        public FlowPanelManager(FlowLayoutPanel imageFlowLayout, DateTime selectedDate)
        {
            _imageFlowLayout = imageFlowLayout;
            _pictureInfoList = LoadDataFromDatabase(selectedDate);
            AddImagesToFlowLayout();
        }

        private void AddImagesToFlowLayout()
        {
            _imageFlowLayout.Controls.Clear();

            foreach (var pictureInfo in _pictureInfoList)
            {
                Debug.WriteLine("플로우판넬 업데이트 할 때 픽쳐박스 인포에 있는 베드포즈의 날짜 " + pictureInfo.Date);
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = _imageFlowLayout.Height;
                pictureBox.Height = _imageFlowLayout.Height;
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
                            g.FillRectangle(backgroundBrush, 0, 0, 650, 60);
                        }

                        SizeF textSize = g.MeasureString(categoryText, font);
                        float textX = (pictureBox.Width - textSize.Width) / 2 + 280;
                        float textY = pictureBox.Height - textSize.Height + 350;
                        g.DrawString(categoryText, font, Brushes.Yellow, new PointF(textX, textY));
                        g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(75, 0));
                    }

                    pictureBox.Image = imageWithText;
                }

                _imageFlowLayout.Controls.Add(pictureBox);
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
                            Debug.WriteLine(imagePath, category, date, turtleneck, scoliosis, herniations);
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
            AddImagesToFlowLayout();
        }
    }
}
