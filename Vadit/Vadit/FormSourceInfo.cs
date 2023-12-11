using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormSourceInfo : Form
    {
        public FormSourceInfo()
        {
            InitializeComponent();
        }

        private void lb_openposegit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", $"/c start https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/LICENSE");
        }

        private void lb_EMGUHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", $"/c start https://www.emgu.com/wiki/index.php/Main_Page");
        }

        private void lb_SqliteHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", $"/c start https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki");
        }

        private void lb_VisualizationHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", $"/c start https://www.nuget.org/packages/WinForms.DataVisualization/1.8.0?_src=template");
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
