
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using Vadit;

public class ChartManager
{
    private DataTable _chartData;
    private DashBoardManager _flowPanelManager;
    private DataPoint _selectedDataPoint;

    public ChartManager(DashBoardManager flowPanelManager)
    {
        _flowPanelManager = flowPanelManager;
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


                        _chartData.Rows.Add(date, goodPoseCount, badPoseCount);
                    }
                }
            }
        }

        foreach (DataRow row in _chartData.Rows)
        {
            int goodPoseCount = Convert.ToInt32(row["GoodPoseCount"]);
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
        series.IsXValueIndexed = false;
        series.XValueType = ChartValueType.Date;
        series.XValueMember = "Date";
        series.YValueMembers = "GoodPosePercentage";
        series.BorderWidth = 2;

        foreach (DataRow row in _chartData.Rows)
        {
            DateTime date = (DateTime)row["Date"];
            double goodPosePercentage = Convert.ToDouble(row["GoodPosePercentage"]);
            series.Points.AddXY(date, goodPosePercentage);
        }

        chart.Series.Add(series);
        chart.ChartAreas[0].AxisY.Minimum = 0;
        chart.ChartAreas[0].AxisY.Maximum = 100;
        chart.ChartAreas[0].AxisX.LineColor = Color.Gray;
        chart.ChartAreas[0].AxisY.LineColor = Color.Gray;
        chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
        chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
        chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
        chart.BackColor = Color.FromArgb(38, 45, 51);
        chart.ChartAreas[0].BackColor = Color.FromArgb(38, 45, 51);
        series.Color = Color.GreenYellow;

        foreach (DataPoint dataPoint in series.Points)
        {
            DateTime date = DateTime.FromOADate(dataPoint.XValue);
            if (date.Date == DateTime.Today.Date)
            {
                dataPoint.MarkerColor = Color.LightBlue;
            }
            else
            {
                dataPoint.MarkerColor = Color.GreenYellow;
            }

            dataPoint.ToolTip = "Click to view photo";
            dataPoint.MarkerStyle = MarkerStyle.Circle;
            dataPoint.MarkerSize = 10;
            dataPoint.MarkerBorderColor = Color.White;
            dataPoint.MarkerBorderWidth = 2;
        }

        chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
        chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
        chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;
        chart.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
        chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
        chart.ChartAreas[0].AxisY.LabelStyle.Format = "0'%'";
        chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
        chart.MouseClick += Chart_MouseClick;
    }
    private Color GetMarkerColor(DataPoint dataPoint)
    {
        DateTime date = DateTime.FromOADate(dataPoint.XValue);
        return (date.Date == DateTime.Today.Date) ? Color.Red : Color.GreenYellow;
    }
    private void Chart_MouseClick(object sender, MouseEventArgs e)
    {
        Chart chart = (Chart)sender;
        HitTestResult hitResult = chart.HitTest(e.X, e.Y);

        if (hitResult.ChartElementType == ChartElementType.DataPoint)
        {
            DataPoint dataPoint = hitResult.Series.Points[hitResult.PointIndex];
            if (_selectedDataPoint != null)
            {
                _selectedDataPoint.MarkerColor = GetMarkerColor(_selectedDataPoint);
            }

            _selectedDataPoint = dataPoint;
            _selectedDataPoint.MarkerColor = Color.Red;


            DateTime selectedDate = DateTime.FromOADate(dataPoint.XValue).Date;
            _flowPanelManager.ShowImagesForSelectedDate(selectedDate);
            
        }
    }

}