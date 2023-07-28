using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using static Vadit.Data;

namespace Vadit
{
    public class Data
    {
        string path = "data_table.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\data_table.db";
        string imageDirectory = Path.Combine(Application.StartupPath, "image_data");

        public SQLiteConnection _con;
        public SQLiteCommand _cmd;
        public SQLiteDataReader _dr;

        public class BadPoseData
        {
            public DateTime Date { get; private set; }
            public int TurtleNeck { get; private set; }
            public int Scoliosis { get; private set; }
            public int TurtleNeck_Scoliosis { get; private set; }

            public BadPoseData(DateTime date, int turtleNeck, int scoliosis, int turtleNeck_Scoliosis)
            {
                Date = date;
                TurtleNeck = turtleNeck;
                Scoliosis = scoliosis;
                TurtleNeck_Scoliosis = turtleNeck_Scoliosis;
            }
        }

        public Data()
        {
            Create_db();

        }

        //분류된 이미지 파일 저장
        public void SaveImageToFile(DateTime date, Image<Bgr, byte> image, string category)
        {
            Create_ImageFile();

            try {
                string timestamp = date.ToString("yyyyMMddHHmmssff");
                string randomId = Guid.NewGuid().ToString("N").Substring(0, 2); // 랜덤 식별자 (2 자리)

                // 이미지 이름
                string imageName = $"{timestamp}_{randomId}.jpg";

                string imagePath = Path.Combine(imageDirectory, imageName);

                // EMGY.CV.Image -> 바이트 배열 변환
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    image.ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                File.WriteAllBytes(imagePath, imageData);
                InsertDB_Image(date, category, imagePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving image: " + ex.Message);
            }

        }
        // 이미지 파일 생성
        public void Create_ImageFile()
        {
            if (!Directory.Exists(imageDirectory)) Directory.CreateDirectory(imageDirectory);
        }

        // 데이터베이스 생성
        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);

                _con = new SQLiteConnection(@"Data Source=" + path);
                _con.Open();

                // Create ImageData table
                string imageDataTableSql = "CREATE TABLE ImageData (Date DATE PRIMARY KEY, Category TEXT, ImagePath TEXT)";
                using (var imageDataCmd = new SQLiteCommand(imageDataTableSql, _con))
                {
                    imageDataCmd.ExecuteNonQuery();
                }


                // Create BadPose table
                string BadPoseTableSql = "CREATE TABLE BadPose ( Date DATE PRIMARY KEY, TurtleNeck INT, Scoliosis INT, TurtleNeckScoliosis INT)";
                using (var BadPoseCmd = new SQLiteCommand(BadPoseTableSql, _con))
                {
                    BadPoseCmd.ExecuteNonQuery();
                }

                // Create Score table
                string totlaScore = "CREATE TABLE Score ( Rank TEXT PRIMARY KEY, GoodPoseCnt INT, BadPoseCnt INT)";
                using (var totlaScoretCmd = new SQLiteCommand(totlaScore, _con))
                {
                    totlaScoretCmd.ExecuteNonQuery();
                }
            }
            else
            {
                _con = new SQLiteConnection(@"Data Source=" + path);
                _con.Open();
                Debug.WriteLine("Database cannot be created because it already exists.");
                return;
            }
        }
        /*
        // 좋은 포즈 횟수 카운트 또는 나쁜 포즈 횟수 카운트 뽑아오기
        public int SelectPoseCnt_Score(string isGoodPose)
        {
            string columnName = isGoodPose ? "GoodPoseCnt" : "BadPoseCnt";
            string selectCountQuery = $"SELECT {columnName} FROM Score";

            using (var selectCmd = new SQLiteCommand(selectCountQuery, _con))
            {
                // Execute the query and read the result
                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        string insertZeroCountQuery = "INSERT INTO Score (Rank, GoodPoseCnt, BadPoseCnt) VALUES (@Rank, @GoodPoseCount, @BadPoseCount)";
                        using (var insertZeroCmd = new SQLiteCommand(insertZeroCountQuery, _con))
                        {
                            insertZeroCmd.Parameters.AddWithValue("@Rank", "B");
                            insertZeroCmd.Parameters.AddWithValue("@GoodPoseCount", 0);
                            insertZeroCmd.Parameters.AddWithValue("@BadPoseCount", 0);

                            insertZeroCmd.ExecuteNonQuery();
                        }
                        return 0;
                    }
                    else
                    {
                        int currentCount = reader.GetInt32(0); // Get the Count value from the first (and only) column
                        return currentCount;
                    }
                }
            }
        }

        // 좋은 포즈 카운트 업데이트 또는 나쁜 포즈 카운트 업데이트 (parameter 'isGoodPose' to differentiate)
        public void UpdatePoseCnt_Score(string isGoodPose)
        {
            int updateValue = SelectPoseCnt_Score(isGoodPose);

            string columnName = isGoodPose ? "GoodPoseCnt" : "BadPoseCnt";
            string updateCountQuery = $"UPDATE Score SET {columnName} = @NewCount";

            using (var updateCmd = new SQLiteCommand(updateCountQuery, _con))
            {
                updateCmd.Parameters.AddWithValue("@NewCount", (updateValue + 1));
                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Debug.WriteLine("Count value updated successfully.");
                else
                    Debug.WriteLine("Failed to update Count value.");
            }
        }
        */
        
        // 좋은 포즈 횟수 카운트
        public int SelectGoodPoseCnt_Score()
        {
            string selectCountQuery = "SELECT GoodPoseCnt FROM Score";
            using (var selectCmd = new SQLiteCommand(selectCountQuery, _con))
            {
                // Execute the query and read the result
                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        string insertZeroCountQuery = "INSERT INTO Score (Rank, GoodPoseCnt, BadPoseCnt) VALUES (@Rank, @GoodPoseCount, @BadPoseCount)";
                        using (var insertZeroCmd = new SQLiteCommand(insertZeroCountQuery, _con))
                        {
                            insertZeroCmd.Parameters.AddWithValue("@Rank", "B");
                            insertZeroCmd.Parameters.AddWithValue("@GoodPoseCount", 0);
                            insertZeroCmd.Parameters.AddWithValue("@BadPoseCount", 0);

                            insertZeroCmd.ExecuteNonQuery();
                        }
                        return 0;
                    }
                    else
                    {
                        int currentCount = reader.GetInt32(0); // Get the Count value from the first (and only) column
                        return currentCount;
                    }
                }
            }

        }


        // 좋은 포즈 카운트 업데이트
        public void UpdateGoodPoseCnt_Score()
        {
            int updateValue = SelectGoodPoseCnt_Score();

            string updateCountQuery = "UPDATE Score SET GoodPoseCnt = @NewCount";
            using (var updateCmd = new SQLiteCommand(updateCountQuery, _con))
            {
                updateCmd.Parameters.AddWithValue("@NewCount", (updateValue+1));
                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Debug.WriteLine("Count value updated successfully.");
                else
                    Debug.WriteLine("Failed to update Count value.");
            }
        }
        // 좋은 포즈 카운트 뽑아오기
        public int SelectBadPoseCnt_Score()
        {
            string selectCountQuery = "SELECT BadPoseCnt FROM Score";
            using (var selectCmd = new SQLiteCommand(selectCountQuery, _con))
            {
                // Execute the query and read the result
                using (SQLiteDataReader reader = selectCmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        string insertZeroCountQuery = "INSERT INTO Score (Rank, GoodPoseCnt, BadPoseCnt) VALUES (@Rank, @GoodPoseCount, @BadPoseCount)";
                        using (var insertZeroCmd = new SQLiteCommand(insertZeroCountQuery, _con))
                        {
                            insertZeroCmd.Parameters.AddWithValue("@Rank", "B");
                            insertZeroCmd.Parameters.AddWithValue("@GoodPoseCount", 0);
                            insertZeroCmd.Parameters.AddWithValue("@BadPoseCount", 0);

                            insertZeroCmd.ExecuteNonQuery();
                        }
                        return 0;
                    }
                    else
                    {
                        int currentCount = reader.GetInt32(0); // Get the Count value from the first (and only) column
                        return currentCount;
                    }
                }
            }

        }
        public void UpdateBadPoseCnt_Score()
        {
            int updateValue = SelectBadPoseCnt_Score();

            string updateCountQuery = "UPDATE Score SET BadPoseCnt = @NewCount";
            using (var updateCmd = new SQLiteCommand(updateCountQuery, _con))
            {
                updateCmd.Parameters.AddWithValue("@NewCount", (updateValue + 1));
                int rowsAffected = updateCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Debug.WriteLine("Count value updated successfully.");
                else
                    Debug.WriteLine("Failed to update Count value.");
            }
        }
        
        public List<BadPoseData> SelectDB_BadPose()
        {
            List<BadPoseData> badPoseDataList = new List<BadPoseData>();

            using (var cmd = new SQLiteCommand("SELECT * FROM BadPose", _con))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                        DateTime date = reader.GetDateTime(0);
                        int turtleNeck = reader.GetInt32(1);
                        int scoliosis = reader.GetInt32(2);
                        int turtleNeck_Scoliosis = reader.GetInt32(3);

                        BadPoseData badPoseData = new BadPoseData(date, turtleNeck, scoliosis, turtleNeck_Scoliosis);
                        badPoseDataList.Add(badPoseData);
                }
            }
            Debug.WriteLine("SelectDB_BadPose");
            return badPoseDataList;
        }
        
        // 이미지 테이블 Insert
        public void InsertDB_Image(DateTime date, string category, string imagePath)
        {
            using (var cmd = new SQLiteCommand(_con))
            {
                cmd.CommandText = "INSERT INTO ImageData (Date, Category, ImagePath) VALUES (@Date, @Category, @ImagePath)";
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                cmd.ExecuteNonQuery();
            }
        }



        public void InsertDB_BadPose(DateTime date, string category)
        {
            int turtleNeck = 0;
            int scoliosis = 0;
            int turtleNeck_Scoliosis = 0;

            if (category == "거북목")
            {
                turtleNeck++;
            }
            else if (category == "척추 측만증")
            {
                scoliosis++;
            }
            else if (category == "거북목, 척추 측만증")
            {
                turtleNeck_Scoliosis++;
            }

            using (var cmd = new SQLiteCommand(_con))
            {
                cmd.CommandText = "INSERT INTO BadPose (Date, TurtleNeck, Scoliosis, TurtleNeckScoliosis) VALUES (@Date, @TurtleNeck, @Scoliosis, @TurtleNeckScoliosis)";

                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@TurtleNeck", turtleNeck);
                cmd.Parameters.AddWithValue("@Scoliosis", scoliosis);
                cmd.Parameters.AddWithValue("@TurtleNeckScoliosis", turtleNeck_Scoliosis);

                cmd.ExecuteNonQuery();

                Debug.WriteLine("InsertDB_BadPose");
            }
        }

    }
}