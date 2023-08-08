using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Vadit
{
    public partial class FormCamera : Form
    {
        AnalyzeData _analyzeData;
        InfoInputCorrectPose _infoPose = null;
        private System.Windows.Forms.Timer delayTimer;
        public FormCamera()
        {
            InitializeComponent();
            if (AppGlobal.VM != null)
                AppGlobal.VM._bgw.CancelAsync();
            AppGlobal.isinputmode = true;
            delayTimer = new System.Windows.Forms.Timer();
            delayTimer.Interval = 1000;
            delayTimer.Tick += new EventHandler(OnDelayTimerTick);
        }
        private void OnDelayTimerTick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            AppGlobal.VM = new VdtManager(OnProgressing);
            AppGlobal.VM.StartSettingCorrectPose();
        }
        // 전달 받을 것들
        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
            pictureBox1.Image = obj.AnalyzedImage;
            tbtesttext.Text = obj.Result.ToString();
        }
        private void FormCamera_Load(object sender, EventArgs e)
        {
            delayTimer.Start();

        }
        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppGlobal.isinputmode = false;
            FormMain fm = new FormMain();
            fm.StartDetect();
        }
        private async void btnResetPose_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = AppGlobal.VM.OnclikBtnResetPose();  //여기 안에서 생성된 VM의 inputfo 지금사진 넣음.
            pnWait.Visible = true;

            await Task.Delay(500);/*
            pictureBox2.Image = AppGlobal.VM._infoInputCorrectPose._img.ToBitmap();
            await Task.Delay(500);*/
            if (AppGlobal.VM.InputCorrectPose())    //여기 안에서 생성된 VM의 inputfo가 제대로된 값이면 트루.
            {

                AppGlobal.CorrectPose.setInfo(AppGlobal.VM._infoInputCorrectPose._img,
                AppGlobal.VM._infoInputCorrectPose._point); //전역으로 선언된 바른 자세에 지금 값 넣기.

                AppGlobal.CorrectPose.IsPointNotNull();     //전연으로 선언된 바른자세에 잘못된값 없는지 확인.
                AppGlobal.VM._isInputCorrrctPose = false;
                AppGlobal.VM._bgw.CancelAsync();
                //AppGlobal.VM.Dispose();
                this.Close();
            }
            else
            {
                pnWait.Visible = false;
                pictureBox2.Image = AppGlobal.VM._infoInputCorrectPose._img.ToBitmap();
            }

        }


    }
}
