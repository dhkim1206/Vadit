using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vadit
{
    public class DataBase
    {

        string path = "data_table.db";
        string cs = @"URI=file:" + Application.StartupPath + "\\data_table.db";

        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public DataBase()
        {
            Create_db();
        }
        private void data_show()
        {
            // SQLiteConnection 객체 생성 및 연결
            var con = new SQLiteConnection(cs);
            con.Open();

            // 데이터 조회를 위한 SQL 문장
            string stm = "SELECT * FROM test";

            // SQLiteCommand 객체 생성 및 SQL 문장과 연결된 SQLiteConnection 설정
            var cmd = new SQLiteCommand(stm, con);

            // SQL 문장 실행 후 결과 데이터 읽기 위한 SQLiteDataReader 객체 생성
            dr = cmd.ExecuteReader();

            // 결과 데이터를 데이터 그리드뷰에 행 단위로 추가
            while (dr.Read())
            {
                // 데이터 그리드뷰의 첫 번째 열에 name 값, 두 번째 열에 id 값 추가
                //dgv.Rows.Insert(0, dr.GetString(0), dr.GetString(1));
            }
        }

        // 데이터베이스 생성
        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);

                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();

                    // Create ImageData table
                    string imageDataTableSql = "CREATE TABLE ImageData (ID INTEGER PRIMARY KEY, Date DATE, Category TEXT, ImagePath TEXT)";
                    using (var imageDataCmd = new SQLiteCommand(imageDataTableSql, sqlite))
                    {
                        imageDataCmd.ExecuteNonQuery();
                    }

                    // Create Statistics table
                    string statisticsTableSql = "CREATE TABLE Statistics (ID INTEGER PRIMARY KEY, AttitudeScore INT, TurtleNeck INT, Scoliosis INT, Other INT, Date DATE)";
                    using (var statisticsCmd = new SQLiteCommand(statisticsTableSql, sqlite))
                    {
                        statisticsCmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                Console.WriteLine("Database cannot be created because it already exists.");
                return;
            }
        }

        //Insert data
        private void btInsert_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            try
            {
                cmd.CommandText = "INSERT INTO test(name, id) VALUES(@name, @id)";



                // 매개변수 설정
                //cmd.Parameters.AddWithValue("@name", NAME);
                //cmd.Parameters.AddWithValue("@id", ID);



                // 스트링 배열 생성
                //string[] row = new string[] { NAME, ID };


                //추가
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("cannot insert data");
                return;
            }
        }


        // 수정
        private void btUpdate_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);

            cmd.CommandText = "UPDATE test Set id=@Id where name =@Name";
            cmd.Prepare();
            //cmd.Parameters.AddWithValue("@Name", edtName.Text);
            //cmd.Parameters.AddWithValue("Id", edtID.Text);

            cmd.ExecuteNonQuery();
            
            data_show();

        }


        // 데이터 삭제
        private void btDelete_Click(object sender, EventArgs e)
        {
            var con = new SQLiteConnection(cs);
            con.Open();

            var cmd = new SQLiteCommand(con);
            try
            {
                cmd.CommandText = "DELETE FROM test where name =@Name";

                //SQLiteCommand 객체에 대해 미리 준비 작업을 수행
                //cmd.Prepare();

                //위의 커맨드 텍스트에 매개변수 설정
                //cmd.Parameters.AddWithValue("@Name", edtName.Text);

                //쿼리 실행
                cmd.ExecuteNonQuery();

                //데이터그리드뷰 최신화
                //dgv.Rows.Clear();
                data_show();
            }
            catch (Exception)
            {
                Console.WriteLine("cannot delete data");
                return;
            }
        }
        /*
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgv.CurrentRow.Selected = true;
                edtName.Text = dgv.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                edtID.Text = dgv.Rows[e.RowIndex].Cells["Id"].FormattedValue.ToString();
            }
        }
        */
    }
}

