using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vadit
{
    public class FlowPanelManager
    {
        string path = "data_table.db";
        private FlowLayoutPanel _imageFlowLayout;
        private List<(string ImagePath, string Category, DateTime Date)> _pictureInfoList;

        public FlowPanelManager(FlowLayoutPanel imageFlowLayout, DateTime selectedDate)
        {
            _imageFlowLayout = imageFlowLayout;
            _pictureInfoList = LoadPicturesFromDatabase(selectedDate.Date);
            AddImagesToFlowLayout();
        }

        private void AddImagesToFlowLayout()
        {
            _imageFlowLayout.Controls.Clear();

            foreach (var pictureInfo in _pictureInfoList)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Width = _imageFlowLayout.Height;
                pictureBox.Height = _imageFlowLayout.Height;
                pictureBox.Image = Image.FromFile(pictureInfo.ImagePath);

                // 그릴 텍스트 정보
                string dateText = pictureInfo.Date.ToString("yyyy-MM-dd");
                string categoryText = pictureInfo.Category;

                // 이미지 위에 텍스트 그리기
                using (Graphics g = Graphics.FromImage(pictureBox.Image))
                {
                    using (Font font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular, GraphicsUnit.Pixel))
                    {
                        // 날짜 텍스트 그리기 (검정)
                        g.DrawString(dateText, font, Brushes.Black, new PointF(5, 5));

                        // 카테고리 텍스트 그리기 (빨간색)
                        SizeF textSize = g.MeasureString(categoryText, font);
                        float textX = (pictureBox.Width - textSize.Width) / 2 + 280; // 10만큼 오른쪽으로 이동
                        float textY = pictureBox.Height - textSize.Height +350;
                        g.DrawString(categoryText, font, Brushes.Yellow, new PointF(textX, textY));

                    }
                }

                _imageFlowLayout.Controls.Add(pictureBox);
            }
        }



        private List<(string ImagePath, string Category, DateTime Date)> LoadPicturesFromDatabase(DateTime selectedDate)
        {
            List<(string ImagePath, string Category, DateTime Date)> pictureInfoList = new List<(string, string, DateTime)>();

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                con.Open();
                string query = "SELECT ImagePath, Category, Date FROM ImageData WHERE `Date` = @SelectedDate";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    Debug.WriteLine(selectedDate.Date);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imagePath = reader.GetString(0);
                            string category = reader.GetString(1);
                            DateTime date = reader.GetDateTime(2);
                            pictureInfoList.Add((imagePath, category, date));
                            Debug.WriteLine(imagePath);
                        }
                    }
                }
            }

            return pictureInfoList;
        }

        public void ShowImagesForSelectedDate(DateTime selectedDate)
        {
            _pictureInfoList = LoadPicturesFromDatabase(selectedDate);
            AddImagesToFlowLayout();
        }
    }
}
