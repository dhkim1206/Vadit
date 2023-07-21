using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;
        public FormCamera _formCamera;

        public VdtManager _vdtManager;
        PictureBox _pictureBox;


        public FormMain()
        {

            InitializeComponent();

            _formManager = new AppBase.FormManager(mainPanel);
        }
        private void btn_poseForm_Click(object sender, EventArgs e)
        {
            _formManager.ChangeForm(typeof(FormCamera));
        }

        private void btn_ProgramExplain_Click(object sender, EventArgs e)
        {

        }

        private void btn_statisticsForm_Click(object sender, EventArgs e)
        {
            _formManager.ChangeForm(typeof(FormStatistics));
        }

        private void btn_FormSetting_Click(object sender, EventArgs e)
        {
            _formManager.ChangeForm(typeof(FormSetting));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vdtManager.Dispose();
        }
    }
}
