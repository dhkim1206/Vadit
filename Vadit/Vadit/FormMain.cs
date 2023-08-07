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
        InfoInputCorrectPose _savedPoseInfo;            //금요일 여기까지했다. 지금까지 한것->쓰레드를 메인에서 시작.


        public FormMain()
        {
            InitializeComponent();
            _formManager = new AppBase.FormManager(mainPanel);
        }
        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
        }
        public void StartDetect()
        {
            AppGlobal.VM = new VdtManager(OnProgressing);
            AppGlobal.VM._bgw.RunWorkerAsync();
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
            AppGlobal.VM.Dispose();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("메인 로드");
        }
    }
}
