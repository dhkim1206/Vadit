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
        VdtManager _VdtManager;
        string _FileName;


        public FormPopUp()
        {
            InitializeComponent();
            _Data = new Data();

        }

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

        private void FormPopUp_VisibleChanged(object sender, EventArgs e)//폼이 화면에서 감지될때
        {
            if (!this.Visible) return;
            DefaultTimer.Start();

            SetAudio(AppBase.AppConf.ConfigSet.AlarmSound);
            /*
            if (AppGlobal.LongPlayPopUp == true) // 장시간 이용시 실행 
            {
                AppGlobal.StartLongPlayPopUp();
                LongPalyPopUp();
            }
            */
            if(true)  // 나쁜 자세 감지 실행 
            {
                SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
                OpenBadPoseImage(AppBase.AppConf.ConfigSet.NotificationLayout);
            }

        }
        private void DefaultTimer_Tick(object sender, EventArgs e)
        {
            // 초시계
            _DefaultSecond++;
            Execution_UserSettingValue();
        }
        public void LongPalyPopUp()
        {
            _LongplaySound.Play();
            UserPanel.Visible = false;
            ExamplePosePanel.Visible = false;
            CommentPanel.Visible = true;
            this.Size = new Size(350, 90);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
            CommentButton.Text = "현재 N시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";
            AppGlobal.StopTimer();
            _LongplaySound.Stop();
        }

        private void OpenBadPoseImage(EnumNotificationLayout layout)
        {
            bool a = true;
            bool b = true;
            bool c = true;

            string ExampleImageName = "";
            string LocalPath = (Path.Combine(Application.StartupPath, "GuideImage_data"));
            string imagePath = "";
            if (a == true) // 받아온 bool이 true 일경우
            {
                ExampleImageName = "ExampleA.PNG";
            }
            else if (b == false)
            {
                ExampleImageName = "ExampleB.PNG";
            }
            else if (c == false)
            {
                ExampleImageName = "ExampleC.PNG";
            }
            /*
            if (_VdtManager.PainA == true) // 받아온 bool이 true 일경우
            {
                ExampleImageName = "ExampleA.PNG";
            }
            else if(_VdtManager.PainB == true)
            {
                ExampleImageName = "ExampleB.PNG";
            }
            else if(_VdtManager.PainC == true)
            {
                ExampleImageName = "ExampleC.PNG";
            }
            */
            imagePath = Path.Combine(LocalPath, ExampleImageName);
            

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
                    UserPosePicBox.Load(highestNumberFileName);
                    UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    ExamplePosePicBox.Load(imagePath);
                    ExamplePosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (layout == EnumNotificationLayout.OnlyUser)
                {
                    UserPosePicBox.Load(highestNumberFileName);
                    UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else if (layout == EnumNotificationLayout.Text)
                {
                    CommentButton.Text = "현재 자세가 바르지 않습니다.\n올바른 자세를 취해 주십시오.";
                }
            }
        }
        private void SetLayout(EnumNotificationLayout layout) // 팝업 생성시 자동 
        {
            CommentButton.FlatAppearance.BorderSize = 0;
            _DefaultSound.Play();

            if (layout == EnumNotificationLayout.Standard)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = true;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 440);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 440);
            }
            else if (layout == EnumNotificationLayout.OnlyUser)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 265);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 265);
            }
            else if (layout == EnumNotificationLayout.Text)
            {
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true; 
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
            }
            _DefaultSound.Stop();
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
