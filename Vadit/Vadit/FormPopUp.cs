using System;
using Emgu.CV;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Vadit.AppBase;
using Timer = System.Windows.Forms.Timer;

namespace Vadit
{
    public partial class FormPopUp : Form
    {
        int _DefaultSecond;
        private Timer _timer;
        string _Path = Path.Combine(Application.StartupPath, "sound_data");
        SoundPlayer _DefaultSound;
        SoundPlayer _LongplaySound;
        Data _Data;
        string _FileName;

        public FormPopUp()
        {
            InitializeComponent();
            _Data = new Data();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);

        }
        // 폼이 실행될때
        /*        private void FormPopUp_Shown(object sender, EventArgs e)//나쁜자세 알림 팝업
                {
                    SetAudio(AppBase.AppConf.ConfigSet.AlarmSound);

                    if (false)// 안좋은 자세 감지시
                    {
                        SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                        OpenUserImage(AppBase.AppConf.ConfigSet.NotificationLayout);
                    }
                    if (false) // 장시간 이용시
                    {
                        LongPalyPopUp();
                    }
                }
        */
        private void SetAudio(bool soundon)
        {
            if (soundon == true)
            {
                _DefaultSound = new SoundPlayer(Path.Combine(_Path, "DefaultSound.wav"));
                _LongplaySound = new SoundPlayer(Path.Combine(_Path, "LongPalySound.wav"));
            }
            else
            {
                _DefaultSound = new SoundPlayer(Path.Combine(_Path, "NoneSound.wav"));
                _LongplaySound = new SoundPlayer(Path.Combine(_Path, "NoneSound.wav"));
            }
        }
        /*        private void FormPopUp_VisibleChanged(object sender, EventArgs e)//폼이 화면에서 감지될때
                {
                    if (!this.Visible) return;
                    DefaultTimer.Start();
                }*/
        private void DefaultTimer_Tick(object sender, EventArgs e)
        {
            // 초시계
            _DefaultSecond++;
            Execution_UserSettingValue();
        }
        public void LongPalyPopUp()
        {
            SoundPlayer _DefaultSound = new SoundPlayer(Path.Combine(_Path, "DefaultSound.wav"));
            SoundPlayer _LongplaySound = new SoundPlayer(Path.Combine(_Path, "LongPalySound.wav"));
            UserPanel.Visible = false;
            ExamplePosePanel.Visible = false;
            CommentPanel.Visible = true;

            this.Size = new Size(350, 90);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
            LbLongTime.Text = "현재 1시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";

            _LongplaySound.Play();
            Application.DoEvents();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            _timer.Stop(); // 타이머 중지
            _timer.Dispose(); // 타이머 해제
            CloseForm();
        }
        public void CloseForm()
        {
            this.Close();
            Close();
        }
        public void OpenUserImage(EnumNotificationLayout layout)
        {
            if (Directory.Exists(_Data.imageDirectory))

            {
                string filenameExtension = "*.JPG"; // 파일 확장자에 따라 변경
                string[] files = Directory.GetFiles(_Data.imageDirectory, filenameExtension);

                double highestName = -1;
                string highestNumberFileName = "";

                foreach (string filesName in files) // 파일의 요소 전체 반복
                {
                    string filename = Path.GetFileNameWithoutExtension(filesName);

                    if (double.TryParse(filename, out double compareName)) // 이름을 실수형으로 변환
                    {
                        if (compareName > highestName) // 파일이름이 0보다 클경우
                        {
                            // foreach가 돌고있는동안 현재낮은 파일을 기본으로 계속비교
                            highestName = compareName;
                            highestNumberFileName = filesName;
                            // 최종적으로 제일 높은 숫자의 파일 저장후 반환
                        }
                    }
                }
                // 레이아웃이 스탠다드 일시 예시 사진 출력하기
                if (layout == EnumNotificationLayout.Standard)
                {
                    UserPosePicBox.Image = AppGlobal.BPI._img.ToBitmap();
                    LbBadPoseName.Text = AppGlobal.BPI._badPoseName;
                    UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (AppGlobal.BPI._badPoseName == " 거북목," || AppGlobal.BPI._badPoseName == "척추 측만증, 거북목,")
                        ExamplePosePicBox.Image = Properties.Resources.KakaoTalk_20230825_102950435;
                    else if (AppGlobal.BPI._badPoseName == "추간판 탈출," || AppGlobal.BPI._badPoseName == "척추 측만증,추간판 탈출,")
                        ExamplePosePicBox.Image = Properties.Resources.KakaoTalk_20230825_102950435_01;
                    else if (AppGlobal.BPI._badPoseName == "척추 측만증,")
                        ExamplePosePicBox.Image = Properties.Resources.KakaoTalk_20230825_102950435_02;
                }
                else if (layout == EnumNotificationLayout.OnlyUser)
                {
                    UserPosePicBox.Image = AppGlobal.BPI._img.ToBitmap();
                    LbBadPoseName.Text = AppGlobal.BPI._badPoseName;
                    UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (layout == EnumNotificationLayout.Text)
                {
                    //CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
                }
            }
        }
        public void ShowLayout(EnumNotificationLayout layout) // 팝업 생성시 자동 
        {
            SoundPlayer _DefaultSound = new SoundPlayer(Path.Combine(_Path, "DefaultSound.wav"));
            SoundPlayer _LongplaySound = new SoundPlayer(Path.Combine(_Path, "LongPalySound.wav"));
            //      CommentButton.FlatAppearance.BorderSize = 0;
            _DefaultSound.Play();

            if (layout == EnumNotificationLayout.Standard)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = true;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 440);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 440);
                Application.DoEvents();
            }
            else if (layout == EnumNotificationLayout.OnlyUser)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 265);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width
                    - 350, Screen.PrimaryScreen.WorkingArea.Height - 265);
                Application.DoEvents();
            }
            else if (layout == EnumNotificationLayout.Text)
            {
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                Application.DoEvents();
            }
        }
        public void Execution_UserSettingValue()
        {
            // 틀린자세 감지시 팝업 자동 종료 
            if (_DefaultSecond == 2)
            {
                DefaultTimer.Stop();
                _DefaultSecond = 0;
                this.Hide();
            }

        }
    }
}
