using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormPictures : Form
    {
        string path = "data_table.db";

        public FormPictures(DateTime selectedDate)
        {
            InitializeComponent();
            PictureGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Debug.WriteLine(selectedDate);

            // 데이터베이스에서 해당 날짜에 해당하는 사진 정보를 불러온다.
            List<(string ImagePath, string Category)> pictureInfoList = LoadPicturesFromDatabase(selectedDate.Date);
            Debug.WriteLine(pictureInfoList);

            // DataGridView에 사진 정보를 표시한다.
            BindPicturesToDataGridView(pictureInfoList);
        }
        private void BindPicturesToDataGridView(List<(string ImagePath, string Category)> pictureInfoList)
        {
            PictureGridView.Rows.Clear();

            foreach ((string imagePath, string category) in pictureInfoList)
            {
                // Load the original image
                Image originalImage = Image.FromFile(imagePath);

                // Calculate the desired thumbnail size (e.g., 200x200 pixels)
                int thumbnailWidth = 200;
                int thumbnailHeight = 200;

                // Create a thumbnail with the desired size
                Image thumbnail = ResizeImage(originalImage, thumbnailWidth, thumbnailHeight);

                int rowIndex = PictureGridView.Rows.Add();

                // Set the thumbnail as the value for the "Picture" column
                PictureGridView.Rows[rowIndex].Cells["Picture"].Value = thumbnail;

                // Extract the date part from the filename and convert it to DateTime
                string filename = Path.GetFileNameWithoutExtension(imagePath);
                if (DateTime.TryParseExact(filename, "yyyyMMddHHmmssff", null, System.Globalization.DateTimeStyles.None, out DateTime imageDate))
                {
                    // Set the formatted date as the value for the "Date" column
                    PictureGridView.Rows[rowIndex].Cells["Date"].Value = imageDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    // Display an error message or a default value for invalid dates
                    PictureGridView.Rows[rowIndex].Cells["Date"].Value = "Invalid Date";
                }

                // Set the category as the value for the "Category" column
                PictureGridView.Rows[rowIndex].Cells["Category"].Value = category;

                // Resize the row height to fit the thumbnail
                PictureGridView.AutoResizeRow(rowIndex, DataGridViewAutoSizeRowMode.AllCells);
            }

            // Resize the column width to fit the thumbnails, date, and category
            PictureGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }




        private List<(string ImagePath, string Category)> LoadPicturesFromDatabase(DateTime selectedDate)
        {
            List<(string ImagePath, string Category)> pictureInfoList = new List<(string, string)>();

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                con.Open();
                string query = "SELECT ImagePath, Category FROM ImageData WHERE `Date` = @SelectedDate";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imagePath = reader.GetString(0);
                            string category = reader.GetString(1);
                            pictureInfoList.Add((imagePath, category));
                        }
                    }
                }
            }

            return pictureInfoList;
        }

        private Image ResizeImage(Image originalImage, int width, int height)
        {
            // Create a new bitmap with the desired size
            Bitmap resizedImage = new Bitmap(width, height);

            // Create a Graphics object to draw the resized image
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                // Set the interpolation mode to high quality to get better results
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the resized bitmap with the desired size
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedImage;
        }
    }
}
