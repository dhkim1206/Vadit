using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Reflection.Emit;

namespace Vadit
{
    public partial class FormStatistics : Form
    {
        private ChartManager _chartManager;
        private DashBoardManager _DashBoardManager;

        public FormStatistics()
        {
            InitializeComponent();
            _DashBoardManager = new DashBoardManager(pn_Nodata, PictureFlowLayout, DateTime.Now.Date, label4);
            _chartManager = new ChartManager(_DashBoardManager);
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            _chartManager.LoadChartData();
            _chartManager.BindChartData(chart1);
        }
    }
}
