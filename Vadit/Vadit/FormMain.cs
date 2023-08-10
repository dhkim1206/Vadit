using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;

        public VdtManager _vdtManager;

        public FormMain()
        {

            InitializeComponent();

            _formManager = new AppBase.FormManager(mainPanel);

        }
        public void StartDetect()
        {
            AppGlobal.VM = new VdtManager(OnProgressing);
            AppGlobal.VM._bgw.RunWorkerAsync();
        }
        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
