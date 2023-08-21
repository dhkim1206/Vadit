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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btn_ProgramExplain = new Button();
            categoryPanel = new Panel();
            pn_Scroll = new Panel();
            btn_end = new Button();
            btn_FormSetting = new Button();
            btn_statisticsForm = new Button();
            btn_producer = new Button();
            mainPanel = new Panel();
            panel1 = new Panel();
            btn_exit = new Button();
            timerSliding = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            categoryPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_ProgramExplain
            // 
            btn_ProgramExplain.BackColor = Color.FromArgb(32, 33, 36);
            btn_ProgramExplain.BackgroundImageLayout = ImageLayout.None;
            btn_ProgramExplain.FlatAppearance.BorderSize = 0;
            btn_ProgramExplain.FlatStyle = FlatStyle.Flat;
            btn_ProgramExplain.Font = new Font("굴림", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ProgramExplain.ForeColor = Color.White;
            btn_ProgramExplain.Image = Properties.Resources.free_icon_window_display_5581930_1_;
            btn_ProgramExplain.ImageAlign = ContentAlignment.MiddleRight;
            btn_ProgramExplain.Location = new Point(26, 215);
            btn_ProgramExplain.Name = "btn_ProgramExplain";
            btn_ProgramExplain.RightToLeft = RightToLeft.Yes;
            btn_ProgramExplain.Size = new Size(210, 75);
            btn_ProgramExplain.TabIndex = 3;
            btn_ProgramExplain.Text = "설명";
            btn_ProgramExplain.UseVisualStyleBackColor = false;
            btn_ProgramExplain.Click += btn_ProgramExplain_Click_1;
            // 
            // categoryPanel
            // 
            categoryPanel.BackColor = Color.FromArgb(32, 33, 36);
            categoryPanel.Controls.Add(pn_Scroll);
            categoryPanel.Controls.Add(btn_end);
            categoryPanel.Controls.Add(btn_ProgramExplain);
            categoryPanel.Controls.Add(btn_FormSetting);
            categoryPanel.Controls.Add(btn_statisticsForm);
            categoryPanel.Controls.Add(btn_producer);
            categoryPanel.Location = new Point(0, 37);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(202, 504);
            categoryPanel.TabIndex = 3;
            // 
            // pn_Scroll
            // 
            pn_Scroll.BackColor = Color.White;
            pn_Scroll.Location = new Point(178, 69);
            pn_Scroll.Name = "pn_Scroll";
            pn_Scroll.Size = new Size(6, 45);
            pn_Scroll.TabIndex = 5;
            // 
            // btn_end
            // 
            btn_end.BackColor = Color.FromArgb(32, 33, 36);
            btn_end.BackgroundImageLayout = ImageLayout.None;
            btn_end.FlatAppearance.BorderSize = 0;
            btn_end.FlatStyle = FlatStyle.Flat;
            btn_end.Font = new Font("굴림", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_end.ForeColor = Color.White;
            btn_end.Image = Properties.Resources.KakaoTalk_20230821_112406611;
            btn_end.ImageAlign = ContentAlignment.MiddleRight;
            btn_end.Location = new Point(25, 416);
            btn_end.Name = "btn_end";
            btn_end.RightToLeft = RightToLeft.Yes;
            btn_end.Size = new Size(210, 75);
            btn_end.TabIndex = 7;
            btn_end.Text = "종료";
            btn_end.UseVisualStyleBackColor = false;
            btn_end.Click += btn_end_Click;
            // 
            // btn_FormSetting
            // 
            btn_FormSetting.BackColor = Color.FromArgb(32, 33, 36);
            btn_FormSetting.BackgroundImageLayout = ImageLayout.None;
            btn_FormSetting.FlatAppearance.BorderSize = 0;
            btn_FormSetting.FlatStyle = FlatStyle.Flat;
            btn_FormSetting.Font = new Font("굴림", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_FormSetting.ForeColor = Color.White;
            btn_FormSetting.Image = Properties.Resources.KakaoTalk_20230821_104715043;
            btn_FormSetting.ImageAlign = ContentAlignment.MiddleRight;
            btn_FormSetting.Location = new Point(25, 135);
            btn_FormSetting.Name = "btn_FormSetting";
            btn_FormSetting.RightToLeft = RightToLeft.Yes;
            btn_FormSetting.Size = new Size(210, 75);
            btn_FormSetting.TabIndex = 2;
            btn_FormSetting.Text = "설정";
            btn_FormSetting.UseVisualStyleBackColor = false;
            btn_FormSetting.Click += btn_FormSetting_Click;
            // 
            // btn_statisticsForm
            // 
            btn_statisticsForm.BackColor = Color.FromArgb(32, 33, 36);
            btn_statisticsForm.BackgroundImageLayout = ImageLayout.None;
            btn_statisticsForm.FlatAppearance.BorderSize = 0;
            btn_statisticsForm.FlatStyle = FlatStyle.Flat;
            btn_statisticsForm.Font = new Font("굴림", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_statisticsForm.ForeColor = Color.White;
            btn_statisticsForm.Image = Properties.Resources.KakaoTalk_20230821_111614469;
            btn_statisticsForm.ImageAlign = ContentAlignment.MiddleRight;
            btn_statisticsForm.Location = new Point(25, 55);
            btn_statisticsForm.Name = "btn_statisticsForm";
            btn_statisticsForm.RightToLeft = RightToLeft.Yes;
            btn_statisticsForm.Size = new Size(210, 75);
            btn_statisticsForm.TabIndex = 1;
            btn_statisticsForm.Text = "분석";
            btn_statisticsForm.UseVisualStyleBackColor = false;
            btn_statisticsForm.Click += btn_statisticsForm_Click;
            // 
            // btn_producer
            // 
            btn_producer.BackColor = Color.FromArgb(32, 33, 36);
            btn_producer.BackgroundImageLayout = ImageLayout.None;
            btn_producer.FlatAppearance.BorderSize = 0;
            btn_producer.FlatStyle = FlatStyle.Flat;
            btn_producer.Font = new Font("굴림", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_producer.ForeColor = Color.White;
            btn_producer.Image = Properties.Resources.KakaoTalk_20230821_104347268;
            btn_producer.ImageAlign = ContentAlignment.MiddleRight;
            btn_producer.Location = new Point(25, 290);
            btn_producer.Name = "btn_producer";
            btn_producer.RightToLeft = RightToLeft.Yes;
            btn_producer.Size = new Size(210, 75);
            btn_producer.TabIndex = 8;
            btn_producer.Text = "제작자";
            btn_producer.UseVisualStyleBackColor = false;
            btn_producer.Click += btn_producer_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(38, 38, 40);
            mainPanel.Location = new Point(208, 40);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(805, 501);
            mainPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 33, 36);
            panel1.Controls.Add(btn_exit);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1013, 40);
            panel1.TabIndex = 0;
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
            // timerSliding
            // 
            timerSliding.Interval = 3;
            timerSliding.Tick += timerSliding_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 40);
            ClientSize = new Size(1013, 542);
            Controls.Add(panel1);
            Controls.Add(mainPanel);
            Controls.Add(categoryPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FormMain_FormClosing;
            categoryPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_ProgramExplain;
        private Panel categoryPanel;
        private Button btn_FormSetting;
        private Button btn_statisticsForm;
        private Panel mainPanel;
        private Panel panel1;
        private Button btn_exit;
        private System.Windows.Forms.Timer timerSliding;
        private Button btn_end;
        private Panel pn_Scroll;
        private Button btn_producer;
        private RadioButton radioButton1;
        private ContextMenuStrip contextMenuStrip1;
    }
}