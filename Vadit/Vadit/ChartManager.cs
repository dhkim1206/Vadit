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
            // 차트 데이터를 저장하기 위한 DataTable 생성
            _chartData = new DataTable();
            _chartData.Columns.Add("Date", typeof(DateTime));              // 날짜
            _chartData.Columns.Add("GoodPoseCount", typeof(int));          // 좋은 자세 개수
            _chartData.Columns.Add("BadPoseCount", typeof(int));           // 나쁜 자세 개수
            _chartData.Columns.Add("GoodPosePercentage", typeof(double));  // 좋은 자세 비율(%)
        }

        public void LoadChartData()
        {
            // SQLite 데이터베이스에서 데이터 불러오기
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

                            // DataTable에 데이터 추가
                            _chartData.Rows.Add(date, goodPoseCount, badPoseCount);
                        }
                    }
                }
            }

            // 좋은 자세 비율 계산 후 DataTable에 추가
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
            // 기존의 Series를 지우고 새로운 Series 생성
            chart.Series.Clear();
            Series series = new Series("GoodPosePercentage");

            // 차트 유형 설정 (Line 차트)
            series.ChartType = SeriesChartType.Line;
            // X축 값이 실제 날짜이므로 인덱스를 사용하지 않도록 설정
            series.IsXValueIndexed = false;

            // X축 값 형식 설정 (날짜)
            series.XValueType = ChartValueType.Date;

            // 데이터 바인딩
            series.XValueMember = "Date";
            series.YValueMembers = "GoodPosePercentage";

            // 선 두께 설정
            series.BorderWidth = 2;

            // 데이터 포인트 생성 및 추가
            foreach (DataRow row in _chartData.Rows)
            {
                DateTime date = (DateTime)row["Date"];
                double goodPosePercentage = Convert.ToDouble(row["GoodPosePercentage"]);
                series.Points.AddXY(date, goodPosePercentage);
            }

            // Series를 차트에 추가
            chart.Series.Add(series);

            // Y축 범위 설정 (0 ~ 100)
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 100;

            // 차트 배경색 설정
            chart.BackColor = Color.Navy;
            chart.ChartAreas[0].BackColor = Color.Navy;

            // 축 색상 설정
            chart.ChartAreas[0].AxisX.LineColor = Color.White;
            chart.ChartAreas[0].AxisY.LineColor = Color.White;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;

            // 차트 배경색 어둡게 설정 (RGB 값 조정)
            chart.BackColor = Color.FromArgb(30, 30, 60);
            chart.ChartAreas[0].BackColor = Color.FromArgb(30, 30, 60);

            // 데이터 포인트 색상 변경
            series.Color = Color.GreenYellow;

            foreach (DataPoint dataPoint in series.Points)
            {
                // 데이터 포인트의 날짜와 오늘 날짜 비교
                DateTime date = DateTime.FromOADate(dataPoint.XValue);
                if (date.Date == DateTime.Today.Date)
                {
                    // 일치하면 다른 색상(예: 연한 파랑색)으로 설정
                    dataPoint.MarkerColor = Color.Red;
                }
                else
                {
                    // 일치하지 않으면 기본 색상(빨강)으로 설정
                    dataPoint.MarkerColor = Color.LightBlue;
                }

                // 나머지 설정은 이전 코드와 동일
                dataPoint.ToolTip = "Click to view photo";  // 데이터 포인트 툴팁 설정
                dataPoint.MarkerStyle = MarkerStyle.Circle;  // 데이터 포인트 마커 스타일 설정
                dataPoint.MarkerSize = 10;  // 데이터 포인트 마커 크기 설정
                dataPoint.MarkerBorderColor = Color.White;  // 데이터 포인트 마커 테두리 색상 설정
                dataPoint.MarkerBorderWidth = 2;  // 데이터 포인트 마커 테두리 두께 설정
            }

            // Y축 메이저 그리드 비활성화
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // Y축 마이너 그리드 비활성화
            chart.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            // X축 메이저 그리드 스타일 설정
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            // X축 마이너 그리드 스타일 설정
            chart.ChartAreas[0].AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot;

            // X축 레이블 형식 설정
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";

            // X축 레이블 색상 설정
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;

            // 차트 클릭 이벤트 핸들러 등록
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
