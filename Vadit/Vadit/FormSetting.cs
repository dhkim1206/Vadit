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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AppGlobal.VM != null)
                if(AppGlobal.VM._bgw.IsBusy)
                    AppGlobal.VM._bgw.CancelAsync();
            FormCamera subForm1 = new FormCamera();
            subForm1.Show();
        }
    }
}
