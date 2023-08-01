using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vadit
{
    public partial class FormStatistics : Form
    {
        private DataTable _chartData;

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            // 차트 데이터를 로드하고 바인딩합니다.
            LoadChartData();
            BindChartData();
        }

        private void LoadChartData()
        {
            // 새로운 DataTable을 생성하고 열(Column)들을 추가합니다.
            DataTable chartData = new DataTable();
            chartData.Columns.Add("Date", typeof(DateTime));
            chartData.Columns.Add("GoodPoseCount", typeof(int));
            chartData.Columns.Add("BadPoseCount", typeof(int));

            // SQLite 데이터베이스와 연결하여 "data_table.db"에서 데이터를 읽어옵니다.
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=data_table.db"))
            {
                con.Open();
                // "Score" 테이블에서 "Date", "GoodPoseCnt", "BadPoseCnt" 열을 선택하는 쿼리를 실행합니다.
                string query = "SELECT Date, GoodPoseCnt, BadPoseCnt FROM Score";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        // 데이터를 읽어와 DataTable에 추가합니다.
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(0);
                            int goodPoseCount = reader.GetInt32(1);
                            int badPoseCount = reader.GetInt32(2);


                            Debug.WriteLine($"Date: {date}, GoodPoseCount: {goodPoseCount}, BadPoseCount: {badPoseCount}");
                            chartData.Rows.Add(date, goodPoseCount, badPoseCount);
                        }
                    }
                }
            }

            // 새로운 열 "GoodPosePercentage"을 추가하고, 각 행의 "GoodPoseCount"와 "BadPoseCount"를 이용하여 "GoodPosePercentage"를 계산합니다.
            chartData.Columns.Add("GoodPosePercentage", typeof(double));
            foreach (DataRow row in chartData.Rows)
            {
                int goodPoseCount = Convert.ToInt32(row["GoodPoseCount"]) + 3; // 3을 더한 이유는 뒤에서 설명합니다.
                int badPoseCount = Convert.ToInt32(row["BadPoseCount"]);
                double totalPoseCount = goodPoseCount + badPoseCount;

                // 좋은 자세의 백분율을 계산합니다.
                double goodPosePercentage = (goodPoseCount / totalPoseCount) * 100.0;
                row["GoodPosePercentage"] = goodPosePercentage;
            }

            // 계산된 데이터를 _chartData에 저장합니다. 이후 차트에 바인딩하기 위해 클래스 레벨 변수에 저장합니다.
            _chartData = chartData;
        }

        private void BindChartData()
        {
            // 이전에 생성된 시리즈들을 모두 제거=
            chart1.Series.Clear();

            // 새로운 시리즈 "GoodPosePercentage"를 생성하고, 선형 차트로 설정
            Series series = new Series("GoodPosePercentage");
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Date;
            series.XValueMember = "Date"; // X 축 값 "Date"

            // 데이터를 시리즈에 추가
            foreach (DataRow row in _chartData.Rows)
            {
                DateTime date = (DateTime)row["Date"];
                double goodPosePercentage = Convert.ToDouble(row["GoodPosePercentage"]);
                series.Points.AddXY(date, goodPosePercentage);
            }

            // 시리즈를 차트에 추가합니다.
            chart1.Series.Add(series);

            // y축 스케일을 0부터 100까지로 설정
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
        }
    }
}
