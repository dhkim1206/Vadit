using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormPopUp : Form
    {
        int _second; // 경과 시간을 저장하는 변수
        string _soundPath = Path.Combine(Application.StartupPath, "sound_data"); // 사운드 파일 경로를 저장할 변수

        public FormPopUp()
        {
            InitializeComponent();
        }

        private void FormPopUp_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout); // 팝업 표시 시 레이아웃 설정
            FloatingTimer.Start(); // 경과 시간을 세기 위한 타이머 시작
        }

        private void SetLayout(EnumNotificationLayout layout)
        {
            CommentButton.FlatAppearance.BorderSize = 0;
            SoundPlayer defaultsound = new SoundPlayer(Path.Combine(_soundPath, "DefaultSound.wav")); // 기본 사운드 파일 로드

            defaultsound.Play(); // 기본 사운드 재생

            if (layout == EnumNotificationLayout.Standard)
            {
                // 표준 레이아웃 설정
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = true;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 440);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 440);
                UserPosePicBox.Load(Path.Combine(_soundPath, "LongPaly.png")); // 사용자 자세 이미지 로드
                UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                ExamplePosePicBox.Load(Path.Combine(_soundPath, "LongPaly.png")); // 예시 자세 이미지 로드
                ExamplePosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }

            else if (layout == EnumNotificationLayout.OnlyUser)
            {
                // 사용자 레이아웃 설정
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 265);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 265);
                UserPosePicBox.Load(Path.Combine(_soundPath, "ExamplePose.png")); // 사용자 자세 이미지 로드
                UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }

            else if (layout == EnumNotificationLayout.Text)
            {
                // 텍스트 레이아웃 설정
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
                CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
            }
        }

        private void FloatingTimer_Tick(object sender, EventArgs e)
        {
            _second++; // 경과 시간 증가
            label1.Text = _second.ToString(); // 경과 시간을 레이블에 표시

            if (_second == 10)
            {
                FloatingTimer.Stop(); // 경과 시간 타이머 중지
                _second = 0; // 경과 시간 초기화
                this.Hide(); // 팝업 숨기기
            }

            else if (_second == 5) // 장시간 이용 조건 필요
            {
                // 장시간 사용시 레이아웃 설정 및 사운드 재생
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
                CommentButton.Text = "현재 N시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";
                SoundPlayer longplaysound = new SoundPlayer(Path.Combine(_soundPath, "LongPalySound.wav")); // 장시간 사용 사운드 로드
                longplaysound.Play(); // 장시간 사용 사운드 재생
            }

        }
    }
}
