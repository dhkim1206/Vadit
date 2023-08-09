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
            btn_ProgramExplain = new Button();
            categoryPanel = new Panel();
            btn_FormSetting = new Button();
            btn_statisticsForm = new Button();
            mainPanel = new Panel();
            panel1 = new Panel();
            button2 = new Button();
            categoryPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_ProgramExplain
            // 
            btn_ProgramExplain.BackColor = Color.FromArgb(38, 38, 38);
            btn_ProgramExplain.BackgroundImageLayout = ImageLayout.None;
            btn_ProgramExplain.FlatAppearance.BorderSize = 0;
            btn_ProgramExplain.FlatStyle = FlatStyle.Flat;
            btn_ProgramExplain.Font = new Font("함초롬돋움", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProgramExplain.ForeColor = SystemColors.ButtonShadow;
            btn_ProgramExplain.Location = new Point(0, 5);
            btn_ProgramExplain.Name = "btn_ProgramExplain";
            btn_ProgramExplain.RightToLeft = RightToLeft.Yes;
            btn_ProgramExplain.Size = new Size(146, 50);
            btn_ProgramExplain.TabIndex = 3;
            btn_ProgramExplain.Text = "프로그램 설명";
            btn_ProgramExplain.UseVisualStyleBackColor = false;
            btn_ProgramExplain.Click += btn_ProgramExplain_Click;
            // 
            // categoryPanel
            // 
            categoryPanel.BackColor = Color.FromArgb(58, 58, 58);
            categoryPanel.Controls.Add(btn_ProgramExplain);
            categoryPanel.Controls.Add(btn_FormSetting);
            categoryPanel.Controls.Add(btn_statisticsForm);
            categoryPanel.Location = new Point(0, 37);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(146, 482);
            categoryPanel.TabIndex = 3;
            // 
            // btn_FormSetting
            // 
            btn_FormSetting.BackColor = Color.FromArgb(38, 38, 38);
            btn_FormSetting.BackgroundImageLayout = ImageLayout.None;
            btn_FormSetting.FlatAppearance.BorderSize = 0;
            btn_FormSetting.FlatStyle = FlatStyle.Flat;
            btn_FormSetting.Font = new Font("함초롬돋움", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_FormSetting.ForeColor = SystemColors.ButtonShadow;
            btn_FormSetting.Location = new Point(0, 115);
            btn_FormSetting.Name = "btn_FormSetting";
            btn_FormSetting.RightToLeft = RightToLeft.Yes;
            btn_FormSetting.Size = new Size(146, 50);
            btn_FormSetting.TabIndex = 2;
            btn_FormSetting.Text = "설정";
            btn_FormSetting.UseVisualStyleBackColor = false;
            btn_FormSetting.Click += btn_FormSetting_Click;
            // 
            // btn_statisticsForm
            // 
            btn_statisticsForm.BackColor = Color.FromArgb(38, 38, 38);
            btn_statisticsForm.BackgroundImageLayout = ImageLayout.None;
            btn_statisticsForm.FlatAppearance.BorderSize = 0;
            btn_statisticsForm.FlatStyle = FlatStyle.Flat;
            btn_statisticsForm.Font = new Font("함초롬돋움", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_statisticsForm.ForeColor = SystemColors.ButtonShadow;
            btn_statisticsForm.Location = new Point(0, 60);
            btn_statisticsForm.Name = "btn_statisticsForm";
            btn_statisticsForm.RightToLeft = RightToLeft.Yes;
            btn_statisticsForm.Size = new Size(146, 50);
            btn_statisticsForm.TabIndex = 1;
            btn_statisticsForm.Text = "통계";
            btn_statisticsForm.UseVisualStyleBackColor = false;
            btn_statisticsForm.Click += btn_statisticsForm_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(38, 38, 38);
            mainPanel.Location = new Point(146, 37);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(802, 482);
            mainPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(948, 40);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(25, 25, 25);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonShadow;
            button2.Location = new Point(908, 6);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(34, 28);
            button2.TabIndex = 4;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 519);
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
    }
}