namespace Vadit
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btn_ProgramExplain = new Button();
            categoryPanel = new Panel();
            pn_cursor = new Panel();
            btn_end = new Button();
            btn_FormSetting = new Button();
            btn_statisticsForm = new Button();
            btn_producer = new Button();
            mainPanel = new Panel();
            pictureBox1 = new PictureBox();
            pn_processingMessage = new Panel();
            label2 = new Label();
            pn_warningMessage = new Panel();
            pictureBox_warning = new PictureBox();
            lb_warning = new Label();
            btn_exit = new Button();
            label1 = new Label();
            panel1 = new Panel();
            categoryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pn_processingMessage.SuspendLayout();
            pn_warningMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_warning).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_ProgramExplain
            // 
            btn_ProgramExplain.BackColor = Color.FromArgb(32, 33, 36);
            btn_ProgramExplain.BackgroundImageLayout = ImageLayout.None;
            btn_ProgramExplain.FlatAppearance.BorderSize = 0;
            btn_ProgramExplain.FlatStyle = FlatStyle.Flat;
            btn_ProgramExplain.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ProgramExplain.ForeColor = Color.White;
            btn_ProgramExplain.Image = Properties.Resources.free_icon_window_display_5581930_1_;
            btn_ProgramExplain.ImageAlign = ContentAlignment.MiddleRight;
            btn_ProgramExplain.Location = new Point(26, 248);
            btn_ProgramExplain.Name = "btn_ProgramExplain";
            btn_ProgramExplain.RightToLeft = RightToLeft.Yes;
            btn_ProgramExplain.Size = new Size(210, 65);
            btn_ProgramExplain.TabIndex = 3;
            btn_ProgramExplain.Text = "설명";
            btn_ProgramExplain.UseVisualStyleBackColor = false;
            btn_ProgramExplain.Click += btn_ProgramExplain_Click_1;
            btn_ProgramExplain.MouseEnter += btn_ProgramExplain_MouseEnter;
            btn_ProgramExplain.MouseLeave += btn_ProgramExplain_MouseLeave;
            // 
            // categoryPanel
            // 
            categoryPanel.BackColor = Color.FromArgb(32, 33, 36);
            categoryPanel.Controls.Add(pn_cursor);
            categoryPanel.Controls.Add(btn_end);
            categoryPanel.Controls.Add(btn_ProgramExplain);
            categoryPanel.Controls.Add(btn_FormSetting);
            categoryPanel.Controls.Add(btn_statisticsForm);
            categoryPanel.Controls.Add(btn_producer);
            categoryPanel.Location = new Point(0, 37);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(189, 522);
            categoryPanel.TabIndex = 3;
            // 
            // pn_cursor
            // 
            pn_cursor.BackColor = Color.White;
            pn_cursor.Location = new Point(178, 160);
            pn_cursor.Name = "pn_cursor";
            pn_cursor.Size = new Size(4, 10);
            pn_cursor.TabIndex = 6;
            // 
            // btn_end
            // 
            btn_end.BackColor = Color.FromArgb(32, 33, 36);
            btn_end.BackgroundImageLayout = ImageLayout.None;
            btn_end.FlatAppearance.BorderSize = 0;
            btn_end.FlatStyle = FlatStyle.Flat;
            btn_end.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_end.ForeColor = Color.White;
            btn_end.Image = Properties.Resources.KakaoTalk_20230821_112406611;
            btn_end.ImageAlign = ContentAlignment.MiddleRight;
            btn_end.Location = new Point(25, 416);
            btn_end.Name = "btn_end";
            btn_end.RightToLeft = RightToLeft.Yes;
            btn_end.Size = new Size(210, 65);
            btn_end.TabIndex = 7;
            btn_end.Text = "종료";
            btn_end.UseVisualStyleBackColor = false;
            btn_end.Click += btn_end_Click;
            btn_end.MouseEnter += btn_end_MouseEnter;
            btn_end.MouseLeave += btn_end_MouseLeave;
            // 
            // btn_FormSetting
            // 
            btn_FormSetting.BackColor = Color.FromArgb(32, 33, 36);
            btn_FormSetting.BackgroundImageLayout = ImageLayout.None;
            btn_FormSetting.FlatAppearance.BorderSize = 0;
            btn_FormSetting.FlatStyle = FlatStyle.Flat;
            btn_FormSetting.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_FormSetting.ForeColor = Color.White;
            btn_FormSetting.Image = Properties.Resources.KakaoTalk_20230821_104715043;
            btn_FormSetting.ImageAlign = ContentAlignment.MiddleRight;
            btn_FormSetting.Location = new Point(25, 168);
            btn_FormSetting.Name = "btn_FormSetting";
            btn_FormSetting.RightToLeft = RightToLeft.Yes;
            btn_FormSetting.Size = new Size(210, 65);
            btn_FormSetting.TabIndex = 2;
            btn_FormSetting.Text = "설정";
            btn_FormSetting.UseVisualStyleBackColor = false;
            btn_FormSetting.Click += btn_FormSetting_Click;
            btn_FormSetting.MouseEnter += btn_FormSetting_MouseEnter;
            btn_FormSetting.MouseLeave += btn_FormSetting_MouseLeave;
            // 
            // btn_statisticsForm
            // 
            btn_statisticsForm.BackColor = Color.FromArgb(32, 33, 36);
            btn_statisticsForm.BackgroundImageLayout = ImageLayout.None;
            btn_statisticsForm.FlatAppearance.BorderSize = 0;
            btn_statisticsForm.FlatStyle = FlatStyle.Flat;
            btn_statisticsForm.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_statisticsForm.ForeColor = Color.White;
            btn_statisticsForm.Image = Properties.Resources.KakaoTalk_20230821_111614469;
            btn_statisticsForm.ImageAlign = ContentAlignment.MiddleRight;
            btn_statisticsForm.Location = new Point(26, 88);
            btn_statisticsForm.Name = "btn_statisticsForm";
            btn_statisticsForm.RightToLeft = RightToLeft.Yes;
            btn_statisticsForm.Size = new Size(210, 65);
            btn_statisticsForm.TabIndex = 1;
            btn_statisticsForm.Text = "분석";
            btn_statisticsForm.UseVisualStyleBackColor = false;
            btn_statisticsForm.Click += btn_statisticsForm_Click;
            btn_statisticsForm.MouseEnter += btn_statisticsForm_MouseEnter;
            btn_statisticsForm.MouseLeave += btn_statisticsForm_MouseLeave;
            // 
            // btn_producer
            // 
            btn_producer.BackColor = Color.FromArgb(32, 33, 36);
            btn_producer.BackgroundImageLayout = ImageLayout.None;
            btn_producer.FlatAppearance.BorderSize = 0;
            btn_producer.FlatStyle = FlatStyle.Flat;
            btn_producer.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_producer.ForeColor = Color.White;
            btn_producer.Image = Properties.Resources.KakaoTalk_20230821_104347268;
            btn_producer.ImageAlign = ContentAlignment.MiddleRight;
            btn_producer.Location = new Point(25, 325);
            btn_producer.Name = "btn_producer";
            btn_producer.RightToLeft = RightToLeft.Yes;
            btn_producer.Size = new Size(210, 65);
            btn_producer.TabIndex = 8;
            btn_producer.Text = "제작자";
            btn_producer.UseVisualStyleBackColor = false;
            btn_producer.Click += btn_producer_Click;
            btn_producer.MouseEnter += btn_producer_MouseEnter;
            btn_producer.MouseLeave += btn_producer_MouseLeave;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(49, 51, 56);
            mainPanel.Location = new Point(208, 40);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(805, 464);
            mainPanel.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.KakaoTalk_20230822_155142195;
            pictureBox1.Location = new Point(246, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pn_processingMessage
            // 
            pn_processingMessage.BackColor = Color.FromArgb(49, 51, 56);
            pn_processingMessage.Controls.Add(pictureBox1);
            pn_processingMessage.Controls.Add(label2);
            pn_processingMessage.Location = new Point(208, 510);
            pn_processingMessage.Name = "pn_processingMessage";
            pn_processingMessage.Size = new Size(807, 49);
            pn_processingMessage.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(285, 14);
            label2.Name = "label2";
            label2.Size = new Size(278, 19);
            label2.TabIndex = 2;
            label2.Text = "백그라운드에서 자세분석 실행중입니다.";
            // 
            // pn_warningMessage
            // 
            pn_warningMessage.BackColor = Color.FromArgb(49, 51, 56);
            pn_warningMessage.Controls.Add(pictureBox_warning);
            pn_warningMessage.Controls.Add(lb_warning);
            pn_warningMessage.Location = new Point(208, 510);
            pn_warningMessage.Name = "pn_warningMessage";
            pn_warningMessage.Size = new Size(807, 49);
            pn_warningMessage.TabIndex = 4;
            // 
            // pictureBox_warning
            // 
            pictureBox_warning.Image = Properties.Resources.KakaoTalk_20230824_093608718;
            pictureBox_warning.Location = new Point(279, 9);
            pictureBox_warning.Name = "pictureBox_warning";
            pictureBox_warning.Size = new Size(32, 31);
            pictureBox_warning.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_warning.TabIndex = 3;
            pictureBox_warning.TabStop = false;
            // 
            // lb_warning
            // 
            lb_warning.AutoSize = true;
            lb_warning.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_warning.ForeColor = Color.White;
            lb_warning.Location = new Point(315, 14);
            lb_warning.Name = "lb_warning";
            lb_warning.Size = new Size(179, 19);
            lb_warning.TabIndex = 2;
            lb_warning.Text = "바른자세를 입력해주세요";
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.FromArgb(32, 33, 36);
            btn_exit.BackgroundImageLayout = ImageLayout.None;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exit.ForeColor = SystemColors.ButtonShadow;
            btn_exit.Location = new Point(974, 3);
            btn_exit.Name = "btn_exit";
            btn_exit.RightToLeft = RightToLeft.Yes;
            btn_exit.Size = new Size(34, 28);
            btn_exit.TabIndex = 4;
            btn_exit.Text = "X";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Vadit";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 33, 36);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_exit);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1015, 40);
            panel1.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 40);
            ClientSize = new Size(1015, 560);
            Controls.Add(pn_warningMessage);
            Controls.Add(pn_processingMessage);
            Controls.Add(panel1);
            Controls.Add(mainPanel);
            Controls.Add(categoryPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            categoryPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pn_processingMessage.ResumeLayout(false);
            pn_processingMessage.PerformLayout();
            pn_warningMessage.ResumeLayout(false);
            pn_warningMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_warning).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_ProgramExplain;
        private Panel categoryPanel;
        private Button btn_FormSetting;
        private Button btn_statisticsForm;
        private Panel mainPanel;
        private Button btn_end;
        private Button btn_producer;
        private RadioButton radioButton1;
        private Panel pn_cursor;
        private Panel pn_processingMessage;
        private Button btn_exit;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox_warning;
        private Label lb_warning;
        private Panel pn_warningMessage;
    }
}