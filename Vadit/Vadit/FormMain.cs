
using Emgu.CV.Ocl;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using static Vadit.AppBase;
using Timer = System.Threading.Timer;
namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;

        FormPopUp _formPopUp;
        public VdtManager _vdtManager;

        //목표지점
        int Current_Y;
        //현재지점
        int Target_Y;
        //슬라이드 속도 조절
        int STEP_SLIDING;

        public FormMain()
        {
            InitializeComponent();
            _formManager = new AppBase.FormManager(mainPanel);
            AppBase.AppConf = new AppConfig("data.xml");
            _formPopUp = new FormPopUp();
            AppGlobal.StartTimer();

            AppBase.AppConf = new AppConfig("data.xml");

            _formPopUp = new FormPopUp();

        }

        private void timerSliding_Tick(object sender, EventArgs e)
        {
            if (Current_Y < Target_Y)
            {
                int y = Current_Y += STEP_SLIDING;
                pn_Scroll.Location = new Point(pn_Scroll.Location.X, y);
                if (y >= Target_Y)
                {
                    timerSliding.Stop();
                }
            }
            else
            {
                int y = Current_Y -= STEP_SLIDING;
                pn_Scroll.Location = new Point(pn_Scroll.Location.X, y);
                if (y <= Target_Y)
                {
                    timerSliding.Stop();
                }
            }
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


        private async void btn_statisticsForm_Click(object sender, EventArgs e)
        {
            Current_Y = pn_Scroll.Location.Y;
            Target_Y = btn_statisticsForm.Location.Y + 20;
            STEP_SLIDING = Math.Abs(Current_Y - Target_Y) / 64 * 20;
            Debug.WriteLine(Math.Abs(Current_Y - Target_Y));
            Debug.WriteLine(STEP_SLIDING);
            timerSliding.Start();

            _formManager.ChangeForm(typeof(FormStatistics));

        }

        private async void btn_FormSetting_Click(object sender, EventArgs e)
        {
            Current_Y = pn_Scroll.Location.Y;
            Target_Y = btn_FormSetting.Location.Y + 20;
            STEP_SLIDING = Math.Abs(Current_Y - Target_Y) / 64 * 20;
            timerSliding.Start();

            _formManager.ChangeForm(typeof(FormSetting));

        }

        private async void btn_ProgramExplain_Click_1(object sender, EventArgs e)
        {
            Current_Y = pn_Scroll.Location.Y;
            Target_Y = btn_ProgramExplain.Location.Y + 20;
            STEP_SLIDING = Math.Abs(Current_Y - Target_Y) / 64 * 20;
            timerSliding.Start();
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formManager.CloseCurrentForm();

            _vdtManager.Dispose();
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


        private void categoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pn_Scroll_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
