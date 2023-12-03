using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Vadit.AppBase;

namespace Vadit
{
    public partial class FormSetting : Form
    {
        Data _data;
        public FormSetting()
        {

            InitializeComponent();

            pb3.Click += ChangeNotificationLayout;
            pb2.Click += ChangeNotificationLayout;
            pb1.Click += ChangeNotificationLayout;
            _data = new Data();
        }

        private void ChangeNotificationLayout(object sender, EventArgs e)
        {
            pnNoti.Tag = (sender as PictureBox).Tag;

            AppConf.ConfigSet.NotificationLayout = (EnumNotificationLayout)Convert.ToInt32(pnNoti.Tag);

            for (int i = 0; i < pnNoti.Controls.Count; i++)
            {
                if (i == Convert.ToInt32(pnNoti.Tag)) pnNoti.Controls[i].BackColor = Color.Gray;
                else pnNoti.Controls[i].BackColor = Color.FromArgb(38, 38, 38);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AppGlobal.VM != null)
                if (AppGlobal.VM._bgw.IsBusy)
                    AppGlobal.VM._bgw.CancelAsync();
            FormCamera subForm1 = new FormCamera();
            subForm1.ShowDialog();

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCamera Fc = new FormCamera();
            Fc.ShowDialog();
            cboPicSaving.SelectedIndex = AppConf.ConfigSet.SaveingPeriod;
        }

        private void pnNoti_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FormSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConf.ConfigSet.Pose = checkPose.Checked;
            AppConf.ConfigSet.LongPlay = checkLongPlay.Checked;
            AppConf.ConfigSet.WindowSameExecute = checkWindows.Checked;
            AppConf.ConfigSet.AlarmSound = checkAlarm.Checked;
            AppConf.ConfigSet.CamFrame = trackBarFrame.Value;
            AppConf.ConfigSet.SaveingPeriod = cboPicSaving.SelectedIndex;
            AppConf.Save();

            AutoStartManager autoStartManager = new AutoStartManager();
            autoStartManager.Run();

            _data.DeleteOldData();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            checkPose.Hide();
            for (int i = 0; i < pnNoti.Controls.Count; i++)
            {

                if (i == Convert.ToInt32(AppConf.ConfigSet.NotificationLayout))
                {
                    pnNoti.Controls[i].BackColor = Color.Gray;
                }
                else pnNoti.Controls[i].BackColor = Color.FromArgb(38, 38, 38);

            }

            checkPose.Checked = AppConf.ConfigSet.Pose;
            checkLongPlay.Checked = AppConf.ConfigSet.LongPlay;
            checkWindows.Checked = AppConf.ConfigSet.WindowSameExecute;
            checkAlarm.Checked = AppConf.ConfigSet.AlarmSound;
            trackBarFrame.Value = AppConf.ConfigSet.CamFrame;
            cboPicSaving.SelectedIndex = AppConf.ConfigSet.SaveingPeriod;
        }
    }
}
