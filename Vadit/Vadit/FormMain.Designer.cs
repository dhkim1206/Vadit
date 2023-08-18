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
            btn_ProgramExplain = new Button();
            categoryPanel = new Panel();
            panel3 = new Panel();
            pn_Scroll = new Panel();
            button1 = new Button();
            btn_FormSetting = new Button();
            btn_statisticsForm = new Button();
            mainPanel = new Panel();
            panel1 = new Panel();
            button2 = new Button();
            timerSliding = new System.Windows.Forms.Timer(components);
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
            btn_ProgramExplain.Font = new Font("굴림", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_ProgramExplain.ForeColor = Color.White;
            btn_ProgramExplain.ImageAlign = ContentAlignment.MiddleRight;
            btn_ProgramExplain.Location = new Point(1, 290);
            btn_ProgramExplain.Name = "btn_ProgramExplain";
            btn_ProgramExplain.RightToLeft = RightToLeft.Yes;
            btn_ProgramExplain.Size = new Size(184, 75);
            btn_ProgramExplain.TabIndex = 3;
            btn_ProgramExplain.Text = "프로그램 설명";
            btn_ProgramExplain.UseVisualStyleBackColor = false;
            btn_ProgramExplain.Click += btn_ProgramExplain_Click_1;
            // 
            // categoryPanel
            // 
            categoryPanel.BackColor = Color.FromArgb(32, 33, 36);
            categoryPanel.Controls.Add(panel3);
            categoryPanel.Controls.Add(pn_Scroll);
            categoryPanel.Controls.Add(button1);
            categoryPanel.Controls.Add(btn_ProgramExplain);
            categoryPanel.Controls.Add(btn_FormSetting);
            categoryPanel.Controls.Add(btn_statisticsForm);
            categoryPanel.Location = new Point(0, 37);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(202, 504);
            categoryPanel.TabIndex = 3;
            categoryPanel.Paint += categoryPanel_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkGray;
            panel3.Location = new Point(191, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1, 475);
            panel3.TabIndex = 6;
            // 
            // pn_Scroll
            // 
            pn_Scroll.BackColor = Color.Teal;
            pn_Scroll.Location = new Point(188, 310);
            pn_Scroll.Name = "pn_Scroll";
            pn_Scroll.Size = new Size(8, 40);
            pn_Scroll.TabIndex = 5;
            pn_Scroll.Paint += pn_Scroll_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(13, 454);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(146, 22);
            button1.TabIndex = 4;
            button1.Text = "팝업버튼";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btn_FormSetting
            // 
            btn_FormSetting.BackColor = Color.FromArgb(32, 33, 36);
            btn_FormSetting.BackgroundImageLayout = ImageLayout.None;
            btn_FormSetting.FlatAppearance.BorderSize = 0;
            btn_FormSetting.FlatStyle = FlatStyle.Flat;
            btn_FormSetting.Font = new Font("굴림", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_FormSetting.ForeColor = Color.White;
            btn_FormSetting.ImageAlign = ContentAlignment.MiddleLeft;
            btn_FormSetting.Location = new Point(3, 210);
            btn_FormSetting.Name = "btn_FormSetting";
            btn_FormSetting.RightToLeft = RightToLeft.Yes;
            btn_FormSetting.Size = new Size(181, 75);
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
            btn_statisticsForm.Font = new Font("굴림", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_statisticsForm.ForeColor = Color.White;
            btn_statisticsForm.Location = new Point(1, 120);
            btn_statisticsForm.Name = "btn_statisticsForm";
            btn_statisticsForm.RightToLeft = RightToLeft.Yes;
            btn_statisticsForm.Size = new Size(184, 75);
            btn_statisticsForm.TabIndex = 1;
            btn_statisticsForm.Text = "통계";
            btn_statisticsForm.UseVisualStyleBackColor = false;
            btn_statisticsForm.Click += btn_statisticsForm_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(38, 38, 40);
            mainPanel.Location = new Point(208, 40);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(805, 482);
            mainPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 33, 36);
            panel1.Controls.Add(button2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1013, 40);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(32, 33, 36);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonShadow;
            button2.Location = new Point(969, 6);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(34, 28);
            button2.TabIndex = 4;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // timerSliding
            // 
            timerSliding.Interval = 3;
            timerSliding.Tick += timerSliding_Tick;
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
        private Button button2;
        private Button button1;
        private Panel pn_Scroll;
        private Panel panel3;
        private System.Windows.Forms.Timer timerSliding;
    }
}