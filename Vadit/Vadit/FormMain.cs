using Emgu.CV.Ocl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using static Vadit.AppBase;

namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;

        FormPopUp _formPopUp;

        public VdtManager _vdtManager;

        public FormMain()
        {

            InitializeComponent();
            _formManager = new AppBase.FormManager(mainPanel);

            AppBase.AppConf = new AppConfig("data.xml");

            _formPopUp = new FormPopUp();

            //메인 화면에 상시 등장하는 폼
            //_formManager.ChangeForm(typeof(DashForm));

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
            _formManager.CloseCurrentForm();

            // 오류 발생하므로 일단 빼둠
            //_vdtManager.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _formPopUp.Show();
        }
    }
}
