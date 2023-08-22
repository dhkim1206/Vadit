using Emgu.CV.Ocl;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Vadit.Properties;
using static Vadit.AppBase;
using Timer = System.Threading.Timer;
namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;
        private NotifyIcon notifyIcon;

        public FormMain()
        { 
            InitializeComponent();

            // 트레이 아이콘 초기화
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.Vadit_Icon;
            notifyIcon.Text = "Vadit";
            notifyIcon.Visible = true;
            // 트레이 아이콘을 클릭하면 폼을 보이게 함
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            if (AppGlobal.CorrectPose._img != null)
                StartDetect();
            _formManager = new AppBase.FormManager(mainPanel);
            AppBase.AppConf = new AppConfig("data.xml");
        }
        public void StartDetect()
        {
            AppGlobal.VM = new VdtManager(OnProgressing);
            AppGlobal.VM._bgw.RunWorkerAsync();
         //   AppGlobal.TM = new TimerManager(AppGlobal.Timer); 스플래쉬로 이동
        }
        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
        }
        private async void btn_statisticsForm_Click(object sender, EventArgs e)
        {
            await AnimatePanel(pn_Scroll, btn_statisticsForm, typeof(FormStatistics));
        }

        private async void btn_FormSetting_Click(object sender, EventArgs e)
        {
            await AnimatePanel(pn_Scroll, btn_FormSetting, typeof(FormSetting));
        }

        private async void btn_ProgramExplain_Click_1(object sender, EventArgs e)
        {
            await AnimatePanel(pn_Scroll, btn_ProgramExplain, typeof(FormSetting) /* No form change for this button */);
        }
        private async void btn_producer_Click(object sender, EventArgs e)
        {
            await AnimatePanel(pn_Scroll, btn_producer, typeof(FormSetting) /* No form change for this button */);

        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formManager.CloseCurrentForm();
        }
        private void btn_end_Click(object sender, EventArgs e)
        {
            // 종료 메뉴 아이템 클릭 시 프로그램 종료
            notifyIcon.Dispose();
            this.Dispose();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // 사용자가 닫을 때 폼 숨기고 트레이 아이콘 표시
            this.Hide();
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 트레이 아이콘 클릭 시 폼을 보이게 함
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private async Task AnimatePanel(Control panel, Control button, Type formType)
        {
            panel.Location = new Point(panel.Location.X, button.Location.Y + 20);
            panel.Height = 30;
            await Task.Delay(40);

            panel.Location = new Point(panel.Location.X, button.Location.Y + 17);
            panel.Height = 39;
            await Task.Delay(40);

            panel.Location = new Point(panel.Location.X, button.Location.Y + 15);
            panel.Height = 45;

            _formManager.ChangeForm(formType);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}