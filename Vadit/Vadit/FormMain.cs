using Emgu.CV.Ocl;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Vadit.Properties;
using static Vadit.AppBase;
using Timer = System.Threading.Timer;
namespace Vadit
{
    public partial class FormMain : Form
    {
        AppBase.FormManager _formManager;
        private Control selectedButton; // 선택된 버튼을 저장할 변수
        private NotifyIcon notifyIcon;

        public FormMain()
        {
            InitializeComponent();
            InitializeTrayIcon();
            InitializeAppComponents();
        }

        //트레이 아이콘 초기화
        private void InitializeTrayIcon()
        {
            
            pn_cursor.Hide();
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.Vadit_Icon;
            notifyIcon.Text = "Vadit";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
        }
        // 앱 설정 초기화
        private void InitializeAppComponents()
        {
            _formManager = new AppBase.FormManager(mainPanel);
            AppBase.AppConf = new AppConfig("data.xml");
            AppGlobal.PN = pn_warningMessage;
        }

        public void StartDetect()
        {
            pn_warningMessage.Hide();
            pn_processingMessage.BringToFront();

            AppGlobal.VM = new VdtManager(OnProgressing);
            AppGlobal.VM._bgw.RunWorkerAsync();
        }

        private void OnProgressing(object sender, ProgressChangedEventArgs e)
        {
            AnalyzeData obj = e.UserState as AnalyzeData;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formManager.CloseCurrentForm();
        }

        private async Task AnimatePanel(Control button, Type formType)
        {
            // 이전에 선택된 버튼이 있다면 원래 색으로 복원
            if (selectedButton != null) selectedButton.BackColor = Color.FromArgb(32, 33, 36);

            // 현재 선택된 버튼 배경 색 설정
            selectedButton = button;
            selectedButton.BackColor = Color.FromArgb(42, 43, 46); // 클릭된 배경 색

            _formManager.ChangeForm(formType);
        }

        private async Task AnimateCursorOnButton(Control panel, Control button)
        {
            panel.Location = new Point(panel.Location.X, button.Location.Y + 25);
            panel.Height = 10;
            await Task.Delay(60);

            panel.Location = new Point(panel.Location.X, button.Location.Y + 22);
            panel.Height = 15;
            await Task.Delay(60);

            panel.Location = new Point(panel.Location.X, button.Location.Y + 20);
            panel.Height = 20;
        }

        private async void btn_statisticsForm_Click(object sender, EventArgs e)
        {
            await AnimatePanel(btn_statisticsForm, typeof(FormStatistics));
        }

        private async void btn_FormSetting_Click(object sender, EventArgs e)
        {
            await AnimatePanel(btn_FormSetting, typeof(FormSetting));
        }

        private async void btn_ProgramExplain_Click_1(object sender, EventArgs e)
        {
            await AnimatePanel(btn_ProgramExplain, typeof(FormExplain));
        }
        private void btn_end_Click(object sender, EventArgs e)
        {
            // 종료 메뉴 아이템 클릭 시 프로그램 종료
            notifyIcon.Dispose();
            this.Dispose();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // 사용자가 닫을 때 폼 숨기고 트레이 아이콘 표시
            this.Hide();
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 트레이 아이콘 클릭 시 폼을 보이게 함
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btn_FormSetting_MouseEnter(object sender, EventArgs e)
        {
            pn_cursor.Show();
            AnimateCursorOnButton(pn_cursor, btn_FormSetting);
        }

        private void btn_FormSetting_MouseLeave(object sender, EventArgs e)
        {
            pn_cursor.Hide();
        }

        private void btn_ProgramExplain_MouseEnter(object sender, EventArgs e)
        {
            pn_cursor.Show();
            AnimateCursorOnButton(pn_cursor, btn_ProgramExplain);
        }

        private void btn_ProgramExplain_MouseLeave(object sender, EventArgs e)
        {
            pn_cursor.Hide();
        }

        private void btn_producer_MouseLeave(object sender, EventArgs e)
        {
            pn_cursor.Hide();
        }

        private void btn_statisticsForm_MouseEnter(object sender, EventArgs e)
        {
            pn_cursor.Show();
            AnimateCursorOnButton(pn_cursor, btn_statisticsForm);
        }

        private void btn_statisticsForm_MouseLeave(object sender, EventArgs e)
        {
            pn_cursor.Hide();
        }

        private void btn_end_MouseEnter(object sender, EventArgs e)
        {
            pn_cursor.Show();
            AnimateCursorOnButton(pn_cursor, btn_end);
        }

        private void btn_end_MouseLeave(object sender, EventArgs e)
        {
            pn_cursor.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (AppGlobal.CorrectPose._img != null)
                StartDetect();
        }
    }
}