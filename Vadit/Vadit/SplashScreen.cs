using Emgu.CV;
using Emgu.CV.ImgHash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Vadit
{
    public partial class SplashScreen : Form
    {
        
        private Timer _timer;
        string _Path = Path.Combine(Application.StartupPath, "sound_data");
        public SplashScreen()
        {
            InitializeComponent();
            PbSplash.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadSplashImage();

            AppGlobal.Cap = new VideoCapture(0);
            AppGlobal.TM = new TimerManager(AppGlobal.Timer);

            _timer = new Timer();
            _timer.Interval = 7000; 
            _timer.Tick += Timer_Tick;
            _timer.Start();

        }
        private void LoadSplashImage()
        {
            Image splashImage = Properties.Resources.SplashImage;
            PbSplash.Image = splashImage;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop(); // 타이머 중지
            _timer.Dispose(); // 타이머 해제

            this.Close(); // 폼 닫기
        }
    }
}
