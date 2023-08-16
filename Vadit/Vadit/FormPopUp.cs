using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vadit.AppBase;

namespace Vadit
{
    public partial class FormPopUp : Form
    {
        int _DefaultSecond;
        SoundPlayer _DefaultSound;
        SoundPlayer _LongplaySound;
        string _Path = Path.Combine(Application.StartupPath, "sound_data");

        Data _Data;
        string _FileName;

        public FormPopUp()
        {
            InitializeComponent();
            _Data = new Data();
        }
        private void LoadImage(string[] ImagePath)
        {
        }
        private void FormPopUp_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (AppBase.AppConf.ConfigSet.AlarmSound)
            {
                _DefaultSound = new SoundPlayer(Path.Combine(_Path, "DefaultSound.wav"));
                
                _LongplaySound = new SoundPlayer(Path.Combine(_Path, "LongPalySound.wav"));
            }
            else
            {
                _DefaultSound = new SoundPlayer(Path.Combine(_Path, "NoneSound.wav"));
                _LongplaySound = new SoundPlayer(Path.Combine(_Path, "NoneSound.wav"));

            }
            SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
            DefaultTimer.Start();

        }
        private void DefaultTimer_Tick(object sender, EventArgs e)
        {
            // 초시계
            _DefaultSecond++;

            Execution_UserSettingValue();
        }

        private void SetLayout(EnumNotificationLayout layout) // 팝업 생성시 자동 
        {

            //팝업 생성시 레이아웃 상관없이 자동 설정 및 실행
            CommentButton.FlatAppearance.BorderSize = 0;
            _DefaultSound.Play();

            if (layout == EnumNotificationLayout.Standard)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = true;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 440);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 440);
                UserPosePicBox.Load(Path.Combine(_Path, "ExamplePose.png"));
                UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ExamplePosePicBox.Load(Path.Combine(_Path, "ExamplePose.png"));
                ExamplePosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }
            else if (layout == EnumNotificationLayout.OnlyUser)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 265);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 265);
                UserPosePicBox.Load(Application.StartupPath + "ExamplePose.png");
                UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }
            else if (layout == EnumNotificationLayout.Text)
            {
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }
        }

        public void Execution_UserSettingValue()
        {
            // 틀린자세 감지시 팝업 자동 종료 
            if (_DefaultSecond == 10)
            {
                DefaultTimer.Stop();
                _DefaultSecond = 0;
                this.Hide();
            }

            // 장시간 이용 여부
            else if (_DefaultSecond == 5 && AppConf.ConfigSet.LongPlay)// 장시간 이용 여부 확인 조건문 추가
            {
                _LongplaySound.Play();
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
                CommentButton.Text = "현재 N시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";
            }
        }
        public void ClosePupup()
        {
            if (_DefaultSecond == 10)
            {
                DefaultTimer.Stop();
                _DefaultSecond = 0;
                this.Hide();
            }
        }
        public void LongUseWarning()
        {
            _LongplaySound.Play();
            UserPanel.Visible = false;
            ExamplePosePanel.Visible = false;
            CommentPanel.Visible = true;
            this.Size = new Size(350, 90);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
            CommentButton.Text = "현재 1시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";
        }
    }
}
