using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormPictures : Form
    {
        string path = "data_table.db";

        public FormPictures(DateTime selectedDate)
        {
            InitializeComponent();
            // 데이터베이스에서 해당 날짜에 해당하는 사진 정보를 불러온다.
            List<string> pictureFilePaths = LoadPicturesFromDatabase(selectedDate.Date);

            // DataGridView에 사진 정보를 표시한다.
            BindPicturesToDataGridView(pictureFilePaths);
        }

        private void BindPicturesToDataGridView(List<string> pictureFilePaths)
        {
            dataGridView1.Columns.Clear();

            // DataGridView에 이미지를 표시하는 컬럼을 추가합니다.
            DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn();
            imageColumn.HeaderText = "Picture";
            dataGridView1.Columns.Add(imageColumn);

            // DataGridView에 이미지를 표시합니다.
            foreach (string filePath in pictureFilePaths)
            {
                Image image = Image.FromFile(filePath);
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                // 이미지를 셀에 직접 그리기 위해 CellPainting 이벤트를 추가합니다.
                dataGridView1.CellPainting += (sender, e) =>
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                    {
                        // 이미지를 셀에 그립니다.
                        e.PaintBackground(e.CellBounds, true);
                        e.Graphics.DrawImage(image, e.CellBounds.Left + 2, e.CellBounds.Top + 2, e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                        e.Handled = true;
                    }
                };

                dataGridView1.Rows.Add(row);
            }
        }

        private List<string> LoadPicturesFromDatabase(DateTime selectedDate)
        {
            List<string> pictureFilePaths = new List<string>();

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=" + path))
            {
                con.Open();
                string query = "SELECT ImagePath FROM ImageData WHERE Date(Date) = @SelectedDate";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Date);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string imagePath = reader.GetString(0);
                            pictureFilePaths.Add(imagePath);
                            Debug.WriteLine(imagePath + " Path is added");
                        }
                    }
                }
            }

            return pictureFilePaths;
        }
    }
}
