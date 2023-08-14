using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace Vadit
{
    public class Data
    {
        public delegate void DeleteOldDataDelegate();

        private readonly string _configFilePath = "data.xml";
        private readonly string _dbPath = "data_table.db";
        private readonly string _cs;
        private readonly string _imageDirectory;

        private SQLiteConnection _con;

        public Data()
        {
            _cs = $"URI=file:{Path.Combine(Application.StartupPath, _dbPath)}";
            _imageDirectory = Path.Combine(Application.StartupPath, "image_data");

            CreateDatabase();
        }

        private void CreateDatabase()
        {
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);

                _con = new SQLiteConnection(_cs);
                _con.Open();

                using (var cmd = new SQLiteCommand(_con))
                {
                    cmd.CommandText = "CREATE TABLE Score ( Date DATE PRIMARY KEY, GoodPoseCnt INT, BadPoseCnt INT)";
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("Create Score Table");

                    cmd.CommandText = "CREATE TABLE ImageData (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date DATE, Category TEXT, ImagePath TEXT)";
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("Create ImageData Table");

                    cmd.CommandText = "CREATE TABLE BadPose ( Date DATE PRIMARY KEY, TurtleNeck INT, Scoliosis INT, Herniations INT)";
                    Debug.WriteLine("Create BadPose Table");
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                _con = new SQLiteConnection(_cs);
                _con.Open();
                Debug.WriteLine("Database already exists.");
            }
        }

        public void SaveImageToFile(DateTime date, Image<Bgr, byte> image, string category)
        {
            CreateImageDirectory();

            try
            {
                string timestamp = date.ToString("yyyyMMddHHmmssff");
                string imageName = $"{timestamp}.jpg";
                string imagePath = Path.Combine(_imageDirectory, imageName);

                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                File.WriteAllBytes(imagePath, imageData);
                InsertImageToDatabase(date, category, imagePath);
                Debug.WriteLine("Image Save & Insert into DB");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving image: " + ex.Message);
            }
        }

        private void CreateImageDirectory()
        {
            if (!Directory.Exists(_imageDirectory)) Directory.CreateDirectory(_imageDirectory);
        }

        public int SelectPoseCount(string columnName, DateTime date)
        {
            string selectCountQuery = $"SELECT {columnName} FROM Score WHERE Date = @Date";
            using (var selectCmd = new SQLiteCommand(selectCountQuery, _con))
            {
                selectCmd.Parameters.AddWithValue("@Date", date);

                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        InsertZeroPoseCount(date);
                        return 0;
                    }
                    else
                    {
                        Debug.WriteLine("SelectPoseCount : " + reader.GetInt32(0));
                        return reader.GetInt32(0);
                    }
                }
            }
        }
        private void InsertZeroPoseCount(DateTime date)
        {
            using (var cmd = new SQLiteCommand(_con))
            {
                cmd.CommandText = "INSERT INTO Score (Date, GoodPoseCnt, BadPoseCnt) VALUES (@Date, @GoodPoseCount, @BadPoseCount)";
                cmd.Parameters.AddWithValue("@Date", date.Date);
                cmd.Parameters.AddWithValue("@GoodPoseCount", 0);
                cmd.Parameters.AddWithValue("@BadPoseCount", 0);
                Debug.WriteLine("Insert Zero Pose Count : ", date.Date + "," + 0 + "," + 0);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePoseCount(string columnName, DateTime date)
        {
            int updateValue = SelectPoseCount(columnName, date);

            string updateCountQuery = $"UPDATE Score SET {columnName} = @NewCount WHERE Date = @Date";
            using (var updateCmd = new SQLiteCommand(updateCountQuery, _con))
            {
                updateCmd.Parameters.AddWithValue("@NewCount", (updateValue + 1));
                updateCmd.Parameters.AddWithValue("@Date", date.Date);
                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Debug.WriteLine("PoseCount " + rowsAffected + " updated successfully.");
                else
                    Debug.WriteLine("Failed to update Count value.");
            }
        }

        public void InsertImageToDatabase(DateTime date, string category, string imagePath)
        {
            using (var cmd = new SQLiteCommand(_con))
            {
                cmd.CommandText = "INSERT INTO ImageData (Date, Category, ImagePath) VALUES (@Date, @Category, @ImagePath)";
                cmd.Parameters.AddWithValue("@Date", date.Date);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                cmd.ExecuteNonQuery();
                Debug.WriteLine("Insert Image To Database");
            }
        }


        public int GetDeleteThreshold()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_configFilePath);

                XmlNode saveingPeriodNode = doc.SelectSingleNode("//SaveingPeriod");
                if (saveingPeriodNode != null)
                {
                    int saveingPeriodValue = Convert.ToInt32(saveingPeriodNode.InnerText);
                    switch (saveingPeriodValue)
                    {
                        case 0:
                            return 15;
                        case 1:
                            return 30;
                        case 2:
                            return 90;
                        default:
                            return -1; // Invalid value
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle XML reading error
                Console.WriteLine("Error reading config file: " + ex.Message);
            }

            return -1; // Default value
        }
        public void DeleteOldData()
        {
            int deleteThreshold = GetDeleteThreshold();
            if (deleteThreshold < 0)
            {
                Debug.WriteLine("Invalid delete threshold value.");
                return;
            }

            DateTime deleteDate = DateTime.Today.AddDays(-deleteThreshold);

            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=data_table.db"))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SQLiteCommand(con))
                        {
                            cmd.CommandText = "DELETE FROM ImageData WHERE Date < @DeleteDate";
                            cmd.Parameters.AddWithValue("@DeleteDate", deleteDate);
                            int deletedImageCount = cmd.ExecuteNonQuery();
                            Debug.WriteLine($"Deleted {deletedImageCount} images.");

                            cmd.CommandText = "DELETE FROM BadPose WHERE Date < @DeleteDate";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DELETE FROM Score WHERE Date < @DeleteDate";
                            cmd.ExecuteNonQuery();

                            transaction.Commit(); // 커밋하여 트랜잭션 완료
                            Debug.WriteLine("Delete Old Data completed.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // 롤백하여 트랜잭션 취소
                        Debug.WriteLine("Error deleting old data: " + ex.Message);
                    }
                }
            }
        }



        public void UpdateGoodPoseCnt_Score(DateTime date)
        {
            UpdatePoseCount("GoodPoseCnt", date);
        }

        public void UpdateBadPoseCnt_Score(DateTime date)
        {
            UpdatePoseCount("BadPoseCnt", date);
        }

        public void InsertDB_BadPose(DateTime date, string category)
        {
            InsertBadPose(date, category);
        }

        public void InsertBadPose(DateTime date, string category)
        {
            int turtleNeck = 0;
            int scoliosis = 0;
            int herniations = 0;

            if (category.Contains("거북목"))
            {
                turtleNeck++;
            }
            if (category.Contains("척추 측만증"))
            {
                scoliosis++;
            }
            if (category.Contains("추간판 탈출"))
            {
                herniations++;
            }

            using (var cmd = new SQLiteCommand(_con))
            {
                cmd.CommandText = "INSERT INTO BadPose (Date, TurtleNeck, Scoliosis, Herniations) VALUES (@Date, @TurtleNeck, @Scoliosis, @Herniations)";

                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@TurtleNeck", turtleNeck);
                cmd.Parameters.AddWithValue("@Scoliosis", scoliosis);
                cmd.Parameters.AddWithValue("@Herniations", herniations);

                cmd.ExecuteNonQuery();

                Debug.WriteLine("InsertDB_BadPose");
            }
        }
    }
}
