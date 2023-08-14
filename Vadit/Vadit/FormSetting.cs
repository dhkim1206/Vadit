using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vadit
{
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AppGlobal.VM != null)
                if (AppGlobal.VM._bgw.IsBusy)
                    AppGlobal.VM._bgw.CancelAsync();
            FormCamera subForm1 = new FormCamera();
            subForm1.Show();

        }
<<<<<<< Updated upstream
=======

        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConf.ConfigSet.Pose = checkPose.Checked;
            AppConf.ConfigSet.LongPlay = checkLongPlay.Checked;
            AppConf.ConfigSet.WindowSameExecute = checkWindows.Checked;
            AppConf.ConfigSet.AlarmSound = checkAlarm.Checked;
            AppConf.ConfigSet.CamFrame = trackBarFrame.Value;
            AppConf.ConfigSet.SaveingPeriod = cboPicterm.SelectedIndex;
            AppConf.Save();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < pnNoti.Controls.Count; i++)// 카운트(0,1,2,3)마다 일치여부 검사후  
            {

                if (i == Convert.ToInt32(AppConf.ConfigSet.NotificationLayout)) // 반환되는 값이 ENUM과 일치시 색상변환
                {
                    pnNoti.Controls[i].BackColor = Color.Gray;
                    label1.Text = AppConf.ConfigSet.NotificationLayout.ToString();
                }
                else pnNoti.Controls[i].BackColor = Color.WhiteSmoke;

            }

            checkPose.Checked = AppConf.ConfigSet.Pose;
            checkLongPlay.Checked = AppConf.ConfigSet.LongPlay;
            checkWindows.Checked = AppConf.ConfigSet.WindowSameExecute;
            checkAlarm.Checked = AppConf.ConfigSet.AlarmSound;
            trackBarFrame.Value = AppConf.ConfigSet.CamFrame;
            cboPicterm.SelectedIndex = AppConf.ConfigSet.SaveingPeriod;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCamera Fc = new FormCamera();
            Fc.ShowDialog();
        }
>>>>>>> Stashed changes
    }
}
