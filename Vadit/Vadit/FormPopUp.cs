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
        int _second;

        public FormPopUp()
        {
            InitializeComponent();
        }

        private void FormPopUp_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            SetLayout(AppBase.AppConf.ConfigSet.NotificationLayout);
            FloatingTimer.Start();
        }
        private void SetLayout(EnumNotificationLayout layout) // 팝업 생성시 자동 
        {
            CommentButton.FlatAppearance.BorderSize = 0;
            SoundPlayer defaultsound = new SoundPlayer("/Users/Uesr/Documents/GitHub/Vadit/Vadit/Vadit/bin/Debug/net6.0-windows/sound_data/DefaultSound.wav");
            defaultsound.Play();

            if (layout == EnumNotificationLayout.Standard)
            {
                UserPanel.Visible = true;
                ExamplePosePanel.Visible = true;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 440);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 440);
                UserPosePicBox.Load("C:/Users/Uesr/Documents/GitHub/Vadit/Vadit/Vadit/bin/Debug/net6.0-windows/sound_data/LongPaly.png");
                UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                ExamplePosePicBox.Load("/Users/Uesr/Documents/GitHub/Vadit/Vadit/Vadit/bin/Debug/net6.0-windows/sound_data/LongPaly.png");
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
                UserPosePicBox.Load("/Users/Uesr/Documents/GitHub/Vadit/Vadit/Vadit/bin/Debug/net6.0-windows/sound_data/ExamplePose.png");
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

        private void FloatingTimer_Tick(object sender, EventArgs e)
        {
            _second++;
            label1.Text = _second.ToString();
            if (_second == 10)
            {
                FloatingTimer.Stop();
                _second = 0;
                this.Hide();
            }
            else if (_second == 5) // 장시간 이용 조건 필요
            {
                UserPanel.Visible = false;
                ExamplePosePanel.Visible = false;
                CommentPanel.Visible = true;
                this.Size = new Size(350, 90);
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 350, Screen.PrimaryScreen.WorkingArea.Height - 90);
                CommentButton.Text = "현재 N시간 동안 앉아 있었습니다.\n잠시 의자에서 일어나 휴식을 취해 주십시오.";
                SoundPlayer longplaysound = new SoundPlayer("/Users/Uesr/Documents/GitHub/Vadit/Vadit/Vadit/bin/Debug/net6.0-windows/sound_data/LongPalySound.wav");
                longplaysound.Play();
            }
        }
    }
}
