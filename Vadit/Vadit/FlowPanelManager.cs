using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vadit
{
    public class ImageData
    {
        public string ImagePath { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public ImageData(string imagePath, string category, DateTime date)
        {
            ImagePath = imagePath;
            Category = category;
            Date = date;
        }
    }

    public class BadPoseData
    {
        public DateTime Date { get; set; }
        public int Turtleneck { get; set; }
        public int Scoliosis { get; set; }
        public int Herniations { get; set; }

        public BadPoseData(DateTime date, int turtleneck, int scoliosis, int herniations)
        {
            Date = date;
            Turtleneck = turtleneck;
            Scoliosis = scoliosis;
            Herniations = herniations;
        }
    }

    public class FlowPanelManager
    {
        string path = "data_table.db";
        private FlowLayoutPanel _imageFlowLayout;
        private List<(ImageData ImageData, BadPoseData BadPoseData)> _pictureInfoList;

        public FlowPanelManager(FlowLayoutPanel imageFlowLayout, DateTime selectedDate)
        {
            _imageFlowLayout = imageFlowLayout;
            _pictureInfoList = LoadDataFromDatabase(selectedDate.Date);
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
                pictureBox.Image = Image.FromFile(pictureInfo.ImageData.ImagePath);

                string categoryText = pictureInfo.ImageData.Category;
                string fullDateTimeText = pictureInfo.BadPoseData != null ? pictureInfo.BadPoseData.Date.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;

                using (Font font = new Font(FontFamily.GenericSansSerif, 50, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    Bitmap imageWithText = new Bitmap(pictureBox.Image);

                    using (Graphics g = Graphics.FromImage(imageWithText))
                    {
                        using (Brush backgroundBrush = new SolidBrush(Color.Black))
                        {
                            g.FillRectangle(backgroundBrush, 0, 0, 650, 60);
                        }

                        if (!string.IsNullOrEmpty(fullDateTimeText))
                        {
                            g.DrawString(fullDateTimeText, font, Brushes.Yellow, new PointF(75, 0));
                        }

                        SizeF textSize = g.MeasureString(categoryText, font);
                        float textX = (pictureBox.Width - textSize.Width) / 2 + 280;
                        float textY = pictureBox.Height - textSize.Height + 350;
                        g.DrawString(categoryText, font, Brushes.Yellow, new PointF(textX, textY));
                    }

                    pictureBox.Image = imageWithText;
                }

                _imageFlowLayout.Controls.Add(pictureBox);
            }
        }

        private List<(ImageData ImageData, BadPoseData BadPoseData)> LoadDataFromDatabase(DateTime selectedDate)
        {
            List<(ImageData ImageData, BadPoseData BadPoseData)> dataInfoList = new List<(ImageData, BadPoseData)>();

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                con.Open();

                string query = "SELECT ImagePath, Category, Date FROM ImageData WHERE strftime('%Y-%m-%d', `Date`) = strftime('%Y-%m-%d', @SelectedDate)";
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
                            var imageData = new ImageData(imagePath, category, date);
                            dataInfoList.Add((imageData, null)); // BadPoseData는 null로 설정
                        }
                    }
                }

                string badPoseQuery = "SELECT Date, TurtleNeck, Scoliosis, Herniations FROM BadPose WHERE strftime('%Y-%m-%d', `Date`) = strftime('%Y-%m-%d', @SelectedDate)";
                using (SQLiteCommand cmd = new SQLiteCommand(badPoseQuery, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime badPoseDate = reader.GetDateTime(0);
                            Debug.WriteLine(badPoseDate);
                            int turtleneck = reader.GetInt32(1);
                            int scoliosis = reader.GetInt32(2);
                            int herniations = reader.GetInt32(3);
                            var badPoseData = new BadPoseData(badPoseDate, turtleneck, scoliosis, herniations);

                            bool matched = false;
                            for (int i = 0; i < dataInfoList.Count; i++)
                            {
                                var dataInfo = dataInfoList[i];
                                if (dataInfo.ImageData.Date.Date == badPoseData.Date.Date)
                                {
                                    dataInfoList[i] = (dataInfo.ImageData, badPoseData);
                                    matched = true;
                                    break;
                                }
                            }

                            if (!matched)
                            {
                                // BadPose 데이터가 없는 경우 기본값으로 설정하여 추가
                                var imageData = new ImageData("", "", badPoseData.Date);
                                dataInfoList.Add((imageData, badPoseData));
                            }

                        }
                    }
                }
            }

            return dataInfoList;
        }

        public void ShowImagesForSelectedDate(DateTime selectedDate)
        {
            _pictureInfoList = LoadDataFromDatabase(selectedDate);
            AddImagesToFlowLayout();
        }
    }
}
