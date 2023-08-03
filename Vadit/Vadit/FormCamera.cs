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
        private VdtManager _vdtManager;
        AnalyzeData _analyzeData;
        public FormCamera()
        {
            InitializeComponent();
            _vdtManager = new VdtManager(OnProgressing);
            _vdtManager.StartSettingCorrectPose();
        }
        // 전달 받을 것들
        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
            pictureBox1.Image = obj.AnalyzedImage;
            tbtesttext.Text = obj.Result.ToString();
        }
        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vdtManager.Dispose();
        }
        private async void btnResetPose_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = _vdtManager.OnclikBtnResetPose();

            pnWait.Visible = true;
            await Task.Delay(500);
            if (_vdtManager.InputCorrectPose())
            {
                _vdtManager.EndPoseSetting();
                await Task.Delay(500);
                _vdtManager.Dispose();
                    this.Close();
                _vdtManager.run();
            }
            pnWait.Visible = false;
            pictureBox2.Image = _vdtManager._infoInputCorrectPose._img.ToBitmap();
        }
    }
}
