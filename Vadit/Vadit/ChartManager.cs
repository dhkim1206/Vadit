using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
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
            series.ChartType = SeriesChartType.Line; // 선형 차트로 변경
            series.XValueType = ChartValueType.Date;
            series.XValueMember = "Date";
            series.BorderWidth = 2; // 선의 굵기 조정

            foreach (DataRow row in _chartData.Rows)
            {
                DateTime date = (DateTime)row["Date"];
                double goodPosePercentage = Convert.ToDouble(row["GoodPosePercentage"]);
                series.Points.AddXY(date, goodPosePercentage);
            }

            chart.Series.Add(series);

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 100;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            // 세로 줄을 점선으로 변경
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;

            // X 축 날짜 형식 지정
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";

            // 데이터 포인트 클릭 이벤트 추가
            foreach (DataPoint dataPoint in series.Points)
            {
                dataPoint.ToolTip = "Click to view photo";
                dataPoint.MarkerStyle = MarkerStyle.Circle;
                dataPoint.MarkerSize = 10;
                dataPoint.MarkerColor = Color.Red;
                dataPoint.MarkerBorderColor = Color.Black;
                dataPoint.MarkerBorderWidth = 2;
            }

            chart.MouseClick += Chart_MouseClick;
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            Chart chart = (Chart)sender;
            HitTestResult hitResult = chart.HitTest(e.X, e.Y);

            if (hitResult.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = hitResult.Series.Points[hitResult.PointIndex];
                DateTime selectedDate = DateTime.FromOADate(dataPoint.XValue).Date;
                ShowPhotoGridView(selectedDate);
            }
        }

        private void ShowPhotoGridView(DateTime selectedDate)
        {
            FormPictures formPictures = new FormPictures(selectedDate);
            formPictures.ShowDialog();
            // 여기에 해당 날짜에 해당하는 DB테이블의 사진을 불러와서 새로운 창에 그리드로 보여주는 로직을 구현합니다.
            // 예를 들면 다이얼로그 또는 폼을 만들고, 거기에 그리드를 추가하고 사진을 로드하여 표시합니다.
        }
    }
}
