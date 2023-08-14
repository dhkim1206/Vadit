namespace Vadit
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkAlarm = new CheckBox();
            label13 = new Label();
            cboPicterm = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            trackBarFrame = new TrackBar();
            label12 = new Label();
            pnNoti = new Panel();
            panel4 = new Panel();
            pb1 = new PictureBox();
            panel6 = new Panel();
            pb2 = new PictureBox();
            panel7 = new Panel();
            pb3 = new PictureBox();
            label7 = new Label();
            checkWindows = new CheckBox();
            checkLongPlay = new CheckBox();
            checkPose = new CheckBox();
            tabPage2 = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarFrame).BeginInit();
            pnNoti.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb1).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 13.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(597, 358);
            button1.Name = "button1";
            button1.Size = new Size(155, 41);
            button1.TabIndex = 1;
            button1.Text = "자세 재설정 하기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(788, 447);
            tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(checkAlarm);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(cboPicterm);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(trackBarFrame);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(pnNoti);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(checkWindows);
            tabPage1.Controls.Add(checkLongPlay);
            tabPage1.Controls.Add(checkPose);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(780, 419);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "기본설정";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkAlarm
            // 
            checkAlarm.AutoSize = true;
            checkAlarm.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkAlarm.Location = new Point(9, 62);
            checkAlarm.Name = "checkAlarm";
            checkAlarm.Size = new Size(103, 23);
            checkAlarm.TabIndex = 41;
            checkAlarm.Text = "알림음 사용";
            checkAlarm.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(9, 371);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(98, 19);
            label13.TabIndex = 39;
            label13.Text = "사진 저장기한";
            // 
            // cboPicterm
            // 
            cboPicterm.FormattingEnabled = true;
            cboPicterm.ImeMode = ImeMode.Off;
            cboPicterm.Items.AddRange(new object[] { "15일동안 저장", "30일동안 저장", "90일동안 저장" });
            cboPicterm.Location = new Point(104, 371);
            cboPicterm.Margin = new Padding(2);
            cboPicterm.Name = "cboPicterm";
            cboPicterm.Size = new Size(111, 23);
            cboPicterm.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(317, 338);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.Yes;
            label8.Size = new Size(49, 15);
            label8.TabIndex = 34;
            label8.Text = "5분 1회";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(156, 338);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(49, 15);
            label9.TabIndex = 33;
            label9.Text = "3분 1회";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(2, 338);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(49, 15);
            label10.TabIndex = 32;
            label10.Text = "1분 1회";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(470, 338);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.Yes;
            label11.Size = new Size(56, 15);
            label11.TabIndex = 35;
            label11.Text = "10분 1회";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarFrame
            // 
            trackBarFrame.BackColor = SystemColors.ButtonHighlight;
            trackBarFrame.LargeChange = 1;
            trackBarFrame.Location = new Point(9, 311);
            trackBarFrame.Margin = new Padding(2);
            trackBarFrame.Maximum = 3;
            trackBarFrame.Name = "trackBarFrame";
            trackBarFrame.Size = new Size(502, 45);
            trackBarFrame.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(5, 286);
            label12.Margin = new Padding(3);
            label12.Name = "label12";
            label12.Size = new Size(98, 19);
            label12.TabIndex = 36;
            label12.Text = "자세분석 주기";
            // 
            // pnNoti
            // 
            pnNoti.Controls.Add(panel4);
            pnNoti.Controls.Add(panel6);
            pnNoti.Controls.Add(panel7);
            pnNoti.Location = new Point(5, 142);
            pnNoti.Margin = new Padding(2);
            pnNoti.Name = "pnNoti";
            pnNoti.Padding = new Padding(6);
            pnNoti.Size = new Size(517, 128);
            pnNoti.TabIndex = 24;
            pnNoti.Tag = "0";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(pb1);
            panel4.Location = new Point(12, 9);
            panel4.Margin = new Padding(6);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(156, 109);
            panel4.TabIndex = 2;
            // 
            // pb1
            // 
            pb1.BackColor = SystemColors.ButtonHighlight;
            pb1.Dock = DockStyle.Fill;
            pb1.Location = new Point(3, 3);
            pb1.Margin = new Padding(2);
            pb1.Name = "pb1";
            pb1.Size = new Size(150, 103);
            pb1.TabIndex = 9;
            pb1.TabStop = false;
            pb1.Tag = "0";
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(pb2);
            panel6.Location = new Point(180, 9);
            panel6.Margin = new Padding(6);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(156, 109);
            panel6.TabIndex = 1;
            // 
            // pb2
            // 
            pb2.BackColor = SystemColors.ButtonHighlight;
            pb2.Dock = DockStyle.Fill;
            pb2.Location = new Point(3, 3);
            pb2.Margin = new Padding(2);
            pb2.Name = "pb2";
            pb2.Size = new Size(150, 103);
            pb2.TabIndex = 9;
            pb2.TabStop = false;
            pb2.Tag = "1";
            // 
            // panel7
            // 
            panel7.BackColor = Color.WhiteSmoke;
            panel7.Controls.Add(pb3);
            panel7.Location = new Point(348, 9);
            panel7.Margin = new Padding(4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(156, 109);
            panel7.TabIndex = 0;
            panel7.Tag = "";
            // 
            // pb3
            // 
            pb3.BackColor = Color.White;
            pb3.Location = new Point(3, 3);
            pb3.Margin = new Padding(0);
            pb3.Name = "pb3";
            pb3.Size = new Size(149, 103);
            pb3.TabIndex = 9;
            pb3.TabStop = false;
            pb3.Tag = "2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(5, 120);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(145, 19);
            label7.TabIndex = 23;
            label7.Text = "알림창 레이아웃 선택";
            // 
            // checkWindows
            // 
            checkWindows.AutoSize = true;
            checkWindows.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkWindows.Location = new Point(9, 35);
            checkWindows.Name = "checkWindows";
            checkWindows.Size = new Size(244, 23);
            checkWindows.TabIndex = 14;
            checkWindows.Text = "윈도우 시작시 프로그램 자동 실행";
            checkWindows.UseVisualStyleBackColor = true;
            // 
            // checkLongPlay
            // 
            checkLongPlay.AutoSize = true;
            checkLongPlay.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkLongPlay.Location = new Point(9, 9);
            checkLongPlay.Name = "checkLongPlay";
            checkLongPlay.Size = new Size(164, 23);
            checkLongPlay.TabIndex = 13;
            checkLongPlay.Text = "장시간 이용안내 알림";
            checkLongPlay.UseVisualStyleBackColor = true;
            // 
            // checkPose
            // 
            checkPose.AutoSize = true;
            checkPose.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkPose.Location = new Point(9, 88);
            checkPose.Name = "checkPose";
            checkPose.Size = new Size(122, 23);
            checkPose.TabIndex = 12;
            checkPose.Text = "전날 자세 알림";
            checkPose.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(780, 419);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "바른자세 설정";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(419, 33);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 42;
            label1.Text = "label1";
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(788, 447);
            Controls.Add(tabControl1);
            Name = "FormSetting";
            Text = "FormSetting";
            FormClosing += FormSetting_FormClosing;
            Load += FormSetting_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarFrame).EndInit();
            pnNoti.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb1).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb2).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckBox checkAlarm;
        private Label label13;
        private ComboBox cboPicterm;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TrackBar trackBarFrame;
        private Label label12;
        private Panel pnNoti;
        private Panel panel4;
        private PictureBox pb1;
        private Panel panel6;
        private PictureBox pb2;
        private Panel panel7;
        private PictureBox pb3;
        private Label label7;
        private CheckBox checkWindows;
        private CheckBox checkLongPlay;
        private CheckBox checkPose;
        private TabPage tabPage2;
        private Label label1;
    }
}