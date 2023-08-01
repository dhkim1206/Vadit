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
            btn_poseForm = new Button();
            mainPanel = new Panel();
            categoryPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btn_ProgramExplain
            // 
            btn_ProgramExplain.BackColor = Color.White;
            btn_ProgramExplain.BackgroundImageLayout = ImageLayout.None;
            btn_ProgramExplain.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_ProgramExplain.Location = new Point(0, 0);
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
            categoryPanel.Controls.Add(btn_ProgramExplain);
            categoryPanel.Controls.Add(btn_FormSetting);
            categoryPanel.Controls.Add(btn_statisticsForm);
            categoryPanel.Controls.Add(btn_poseForm);
            categoryPanel.Dock = DockStyle.Left;
            categoryPanel.Location = new Point(0, 0);
            categoryPanel.Name = "categoryPanel";
            categoryPanel.Size = new Size(146, 519);
            categoryPanel.TabIndex = 3;
            // 
            // btn_FormSetting
            // 
            btn_FormSetting.BackColor = Color.White;
            btn_FormSetting.BackgroundImageLayout = ImageLayout.None;
            btn_FormSetting.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_FormSetting.Location = new Point(0, 168);
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
            btn_statisticsForm.BackColor = Color.White;
            btn_statisticsForm.BackgroundImageLayout = ImageLayout.None;
            btn_statisticsForm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_statisticsForm.Location = new Point(0, 112);
            btn_statisticsForm.Name = "btn_statisticsForm";
            btn_statisticsForm.RightToLeft = RightToLeft.Yes;
            btn_statisticsForm.Size = new Size(146, 50);
            btn_statisticsForm.TabIndex = 1;
            btn_statisticsForm.Text = "통계";
            btn_statisticsForm.UseVisualStyleBackColor = false;
            btn_statisticsForm.Click += btn_statisticsForm_Click;
            // 
            // btn_poseForm
            // 
            btn_poseForm.BackColor = Color.White;
            btn_poseForm.BackgroundImageLayout = ImageLayout.None;
            btn_poseForm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_poseForm.Location = new Point(0, 56);
            btn_poseForm.Name = "btn_poseForm";
            btn_poseForm.RightToLeft = RightToLeft.Yes;
            btn_poseForm.Size = new Size(146, 50);
            btn_poseForm.TabIndex = 0;
            btn_poseForm.Text = "자세분석";
            btn_poseForm.UseVisualStyleBackColor = false;
            btn_poseForm.Click += btn_poseForm_Click;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(146, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(802, 519);
            mainPanel.TabIndex = 4;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 519);
            Controls.Add(mainPanel);
            Controls.Add(categoryPanel);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += FormMain_FormClosing;
            categoryPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_ProgramExplain;
        private Panel categoryPanel;
        private Button btn_FormSetting;
        private Button btn_statisticsForm;
        private Button btn_poseForm;
        private Panel mainPanel;
    }
}