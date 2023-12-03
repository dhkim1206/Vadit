using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Channels;
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            if (AppGlobal.VM != null)
                AppGlobal.VM._bgw.CancelAsync();
            AppGlobal.isinputmode = true;
            delayTimer = new System.Windows.Forms.Timer();
            delayTimer.Interval = 500;
            delayTimer.Tick += new EventHandler(OnDelayTimerTick);
        }
        private void FormCamera_Load(object sender, EventArgs e)
        {
            delayTimer.Start();
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
        private async void btnResetPose_Click(object sender, EventArgs e)
        {
            btnResetPose.Enabled = false;
            Debug.WriteLine("눌림티비~");
            pnWait.Visible = true;
            await Task.Delay(300);
            pictureBox2.Image = await AppGlobal.VM.OnclikBtnResetPose();  // await 추가
            await Task.Delay(500);
            AppGlobal.VM.InputCorrectPose();
            pictureBox2.Image = AppGlobal.VM._infoInputCorrectPose._img.ToBitmap();
            if (AppGlobal.VM.AskSettingPose())    //여기 안에서 생성된 VM의 inputfo가 제대로된 값이면 트루.
            {
                AppGlobal.VM.HandleSettingMessage();
                this.Close();
            }
            else
            {
                pnWait.Visible = false;
                pictureBox2.Image = AppGlobal.VM._infoInputCorrectPose._img.ToBitmap();
                btnResetPose.Enabled = true;
            }
        }
        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppGlobal.VM._bgw.IsBusy)
            {
                AppGlobal.VM._bgw.CancelAsync();
                Thread.Sleep(1000);
                AppGlobal.PN.Hide();

            }
            AppGlobal.isinputmode = false;
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AppGlobal.CorrectPose._isPointNotNull)
            {
                if (!AppGlobal.VM._bgw.IsBusy)
                {
                    AppGlobal.VM._bgw.RunWorkerAsync();

                }
            }
        }
    }
}
