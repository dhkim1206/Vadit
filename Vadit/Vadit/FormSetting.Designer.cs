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
            checkPose = new CheckBox();
            checkLongPlay = new CheckBox();
            checkWindows = new CheckBox();
            label7 = new Label();
            pnNoti = new Panel();
            panel4 = new Panel();
            pb1 = new PictureBox();
            panel6 = new Panel();
            pb2 = new PictureBox();
            panel7 = new Panel();
            pb3 = new PictureBox();
            cboPicSaving = new ComboBox();
            label13 = new Label();
            checkAlarm = new CheckBox();
            button1 = new Button();
            panel1 = new Panel();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            trackBarFrame = new TrackBar();
            label12 = new Label();
            pnNoti.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb1).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb2).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarFrame).BeginInit();
            SuspendLayout();
            // 
            // checkPose
            // 
            checkPose.AutoSize = true;
            checkPose.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkPose.ForeColor = Color.White;
            checkPose.Location = new Point(31, 53);
            checkPose.Name = "checkPose";
            checkPose.Size = new Size(113, 21);
            checkPose.TabIndex = 12;
            checkPose.Text = "전날 자세 알림";
            checkPose.UseVisualStyleBackColor = true;
            // 
            // checkLongPlay
            // 
            checkLongPlay.AutoSize = true;
            checkLongPlay.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkLongPlay.ForeColor = Color.White;
            checkLongPlay.Location = new Point(253, 22);
            checkLongPlay.Name = "checkLongPlay";
            checkLongPlay.Size = new Size(152, 21);
            checkLongPlay.TabIndex = 13;
            checkLongPlay.Text = "장시간 이용안내 알림";
            checkLongPlay.UseVisualStyleBackColor = true;
            // 
            // checkWindows
            // 
            checkWindows.AutoSize = true;
            checkWindows.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkWindows.ForeColor = Color.White;
            checkWindows.Location = new Point(253, 53);
            checkWindows.Name = "checkWindows";
            checkWindows.Size = new Size(225, 21);
            checkWindows.TabIndex = 14;
            checkWindows.Text = "윈도우 시작시 프로그램 자동 실행";
            checkWindows.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(47, 22);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(119, 19);
            label7.TabIndex = 23;
            label7.Text = "알림창 레이아웃";
            // 
            // pnNoti
            // 
            pnNoti.BackColor = Color.FromArgb(35, 36, 40);
            pnNoti.Controls.Add(panel4);
            pnNoti.Controls.Add(panel6);
            pnNoti.Controls.Add(panel7);
            pnNoti.Location = new Point(40, 52);
            pnNoti.Margin = new Padding(2);
            pnNoti.Name = "pnNoti";
            pnNoti.Padding = new Padding(6);
            pnNoti.Size = new Size(741, 211);
            pnNoti.TabIndex = 24;
            pnNoti.Tag = "0";
            pnNoti.Paint += pnNoti_Paint;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(38, 38, 38);
            panel4.Controls.Add(pb1);
            panel4.Location = new Point(16, 11);
            panel4.Margin = new Padding(6);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(218, 186);
            panel4.TabIndex = 2;
            // 
            // pb1
            // 
            pb1.BackColor = SystemColors.ButtonHighlight;
            pb1.Dock = DockStyle.Fill;
            pb1.Image = Properties.Resources.KakaoTalk_20230822_143941512_02;
            pb1.Location = new Point(3, 3);
            pb1.Margin = new Padding(2);
            pb1.Name = "pb1";
            pb1.Size = new Size(212, 180);
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.TabIndex = 9;
            pb1.TabStop = false;
            pb1.Tag = "0";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(38, 38, 38);
            panel6.Controls.Add(pb2);
            panel6.Location = new Point(260, 11);
            panel6.Margin = new Padding(6);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(218, 186);
            panel6.TabIndex = 1;
            // 
            // pb2
            // 
            pb2.BackColor = SystemColors.ButtonHighlight;
            pb2.Dock = DockStyle.Fill;
            pb2.Image = Properties.Resources.KakaoTalk_20230822_1439415121;
            pb2.Location = new Point(3, 3);
            pb2.Margin = new Padding(2);
            pb2.Name = "pb2";
            pb2.Size = new Size(212, 180);
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.TabIndex = 9;
            pb2.TabStop = false;
            pb2.Tag = "1";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(38, 38, 38);
            panel7.Controls.Add(pb3);
            panel7.Location = new Point(507, 10);
            panel7.Margin = new Padding(4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(218, 186);
            panel7.TabIndex = 0;
            panel7.Tag = "";
            // 
            // pb3
            // 
            pb3.BackColor = Color.White;
            pb3.Image = Properties.Resources.KakaoTalk_20230822_143941512_012;
            pb3.Location = new Point(4, 4);
            pb3.Margin = new Padding(0);
            pb3.Name = "pb3";
            pb3.Size = new Size(211, 178);
            pb3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb3.TabIndex = 9;
            pb3.TabStop = false;
            pb3.Tag = "2";
            // 
            // cboPicSaving
            // 
            cboPicSaving.BackColor = Color.FromArgb(35, 36, 40);
            cboPicSaving.FlatStyle = FlatStyle.Flat;
            cboPicSaving.ForeColor = Color.White;
            cboPicSaving.FormattingEnabled = true;
            cboPicSaving.ImeMode = ImeMode.Off;
            cboPicSaving.Items.AddRange(new object[] { "15일", "30일", "90일" });
            cboPicSaving.Location = new Point(576, 51);
            cboPicSaving.Margin = new Padding(0);
            cboPicSaving.Name = "cboPicSaving";
            cboPicSaving.Size = new Size(111, 23);
            cboPicSaving.TabIndex = 38;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(576, 26);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(90, 17);
            label13.TabIndex = 39;
            label13.Text = "사진 저장기한";
            // 
            // checkAlarm
            // 
            checkAlarm.AutoSize = true;
            checkAlarm.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            checkAlarm.ForeColor = Color.White;
            checkAlarm.Location = new Point(31, 22);
            checkAlarm.Name = "checkAlarm";
            checkAlarm.Size = new Size(96, 21);
            checkAlarm.TabIndex = 41;
            checkAlarm.Text = "알림음 사용";
            checkAlarm.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(78, 78, 78);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("맑은 고딕", 13.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.free_icon_computer_worker_7870360;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(587, 400);
            button1.Name = "button1";
            button1.Size = new Size(194, 58);
            button1.TabIndex = 1;
            button1.Text = "바른 자세 설정";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 36, 40);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(cboPicSaving);
            panel1.Controls.Add(checkLongPlay);
            panel1.Controls.Add(checkWindows);
            panel1.Controls.Add(checkAlarm);
            panel1.Controls.Add(checkPose);
            panel1.Location = new Point(40, 277);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 96);
            panel1.TabIndex = 42;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(35, 36, 40);
            label8.Font = new Font("함초롬돋움", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(474, 442);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.Yes;
            label8.Size = new Size(66, 16);
            label8.TabIndex = 46;
            label8.Text = "5번 검출시";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(35, 36, 40);
            label9.Font = new Font("함초롬돋움", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(256, 443);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(66, 16);
            label9.TabIndex = 45;
            label9.Text = "3번 검출시";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(35, 36, 40);
            label10.Font = new Font("함초롬돋움", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(45, 443);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(59, 16);
            label10.TabIndex = 44;
            label10.Text = "검출 즉시";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarFrame
            // 
            trackBarFrame.BackColor = Color.FromArgb(35, 36, 40);
            trackBarFrame.LargeChange = 1;
            trackBarFrame.Location = new Point(38, 413);
            trackBarFrame.Margin = new Padding(2);
            trackBarFrame.Maximum = 2;
            trackBarFrame.Name = "trackBarFrame";
            trackBarFrame.Size = new Size(502, 45);
            trackBarFrame.TabIndex = 43;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(47, 387);
            label12.Margin = new Padding(3);
            label12.Name = "label12";
            label12.Size = new Size(171, 17);
            label12.TabIndex = 48;
            label12.Text = "나쁜 자세 검출 시 알림 주기";
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 51, 56);
            ClientSize = new Size(814, 496);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(trackBarFrame);
            Controls.Add(label12);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(pnNoti);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSetting";
            Text = "FormSetting";
            FormClosing += FormSetting_FormClosing;
            Load += FormSetting_Load;
            pnNoti.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb1).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb2).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarFrame).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkPose;
        private CheckBox checkLongPlay;
        private CheckBox checkWindows;
        private Label label7;
        private Panel pnNoti;
        private Panel panel4;
        private PictureBox pb1;
        private Panel panel6;
        private PictureBox pb2;
        private Panel panel7;
        private PictureBox pb3;
        private Label label13;
        private CheckBox checkAlarm;
        private Button button1;
        private Panel panel1;
        protected ComboBox cboPicSaving;
        private Label label8;
        private Label label9;
        private Label label10;
        private TrackBar trackBarFrame;
        private Label label12;
    }
}