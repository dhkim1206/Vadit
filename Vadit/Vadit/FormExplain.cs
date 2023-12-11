using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Vadit
{
    public partial class FormExplain : Form
    {
        public FormExplain()
        {
            InitializeComponent();
        }

        private void tb_sourceLink_Click(object sender, EventArgs e)
        {
            FormSourceInfo newFormSourceInfo = new FormSourceInfo();
            newFormSourceInfo.ShowDialog();
        }
    }
}
