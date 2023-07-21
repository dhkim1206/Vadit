using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;
        public FormCamera _formCamera;

        public VdtManager _vdtManager;
        PictureBox _pictureBox;


        public FormMain()
        {

            InitializeComponent();

            _formManager = new AppBase.FormManager(mainPanel);

            /*
            _formCamera = new FormCamera();
            _formCamera.TopLevel = false;
            _formCamera.FormBorderStyle = FormBorderStyle.None;
            _formCamera.Parent = mainPanel;
            _formCamera.Dock = DockStyle.Fill; // 가득 찬 화면
            */
            //_formCameraThread.IsBackground = true; // 쓰레드를 백그라운드로 설정하여 프로그램 종료 시 함께 종료되도록 합니다.
            /*
            _isRunning = true;
            _cameraCapture = new VdtManager();
            */

            /*
            // 카메라 캡처 쓰레드 시작
            _captureThread = new Thread(CaptureThreadMethod);
            _captureThread.Start();
            */




            //_pictureBox = _formCamera.Controls.OfType<PictureBox>.FirstOrDefault();

        }
        private void btn_poseForm_Click(object sender, EventArgs e)
        {
            //기존에 실행한 쓰레드를 띄워줘야 함
            _formManager.ChangeForm(typeof(FormCamera));
        }

        private void btn_ProgramExplain_Click(object sender, EventArgs e)
        {

        }

        private void btn_statisticsForm_Click(object sender, EventArgs e)
        {
            _formManager.ChangeForm(typeof(FormStatistics));
        }

        private void btn_FormSetting_Click(object sender, EventArgs e)
        {
            _formManager.ChangeForm(typeof(FormSetting));
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vdtManager.Dispose();
        }
    }
}
