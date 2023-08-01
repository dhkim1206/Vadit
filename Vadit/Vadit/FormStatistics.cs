using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vadit
{
    public partial class FormStatistics : Form
    {
        private ChartManager _chartManager;

        public FormStatistics()
        {
            InitializeComponent();
            _chartManager = new ChartManager();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            _chartManager.LoadChartData();
            _chartManager.BindChartData(chart1);
        }
    }
}
