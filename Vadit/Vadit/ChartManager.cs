using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vadit
{
    public class ChartManager
    {
        private DataTable _chartData;

        public ChartManager()
        {
            _chartData = new DataTable();
            _chartData.Columns.Add("Date", typeof(DateTime));
            _chartData.Columns.Add("GoodPoseCount", typeof(int));
            _chartData.Columns.Add("BadPoseCount", typeof(int));
            _chartData.Columns.Add("GoodPosePercentage", typeof(double));
        }

        public void LoadChartData()
        {
            using (SQLiteConnection con = new SQLiteConnection(@"Data Source=data_table.db"))
            {
                con.Open();
                string query = "SELECT Date, GoodPoseCnt, BadPoseCnt FROM Score";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime date = reader.GetDateTime(0);
                            int goodPoseCount = reader.GetInt32(1);
                            int badPoseCount = reader.GetInt32(2);

                            Debug.WriteLine($"Date: {date}, GoodPoseCount: {goodPoseCount}, BadPoseCount: {badPoseCount}");
                            _chartData.Rows.Add(date, goodPoseCount, badPoseCount);
                        }
                    }
                }
            }

            foreach (DataRow row in _chartData.Rows)
            {
                int goodPoseCount = Convert.ToInt32(row["GoodPoseCount"]) + 3;
                int badPoseCount = Convert.ToInt32(row["BadPoseCount"]);
                double totalPoseCount = goodPoseCount + badPoseCount;
                double goodPosePercentage = (goodPoseCount / totalPoseCount) * 100.0;
                row["GoodPosePercentage"] = goodPosePercentage;
            }
        }

        public void BindChartData(Chart chart)
        {
            chart.Series.Clear();

            Series series = new Series("GoodPosePercentage");
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.Date;
            series.XValueMember = "Date";

            foreach (DataRow row in _chartData.Rows)
            {
                DateTime date = (DateTime)row["Date"];
                double goodPosePercentage = Convert.ToDouble(row["GoodPosePercentage"]);
                series.Points.AddXY(date, goodPosePercentage);
            }

            chart.Series.Add(series);

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 100;
        }
    }
}
