namespace Vadit
{
    partial class FormCamera
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
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            btnResetPose = new Button();
            btnResetComplet = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientInactiveCaption;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(602, 351);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 379);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(602, 46);
            textBox1.TabIndex = 2;
            // 
            // btnResetPose
            // 
            btnResetPose.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetPose.Location = new Point(629, 193);
            btnResetPose.Name = "btnResetPose";
            btnResetPose.Size = new Size(169, 88);
            btnResetPose.TabIndex = 3;
            btnResetPose.Text = "바른자세 다시 입력하기";
            btnResetPose.UseVisualStyleBackColor = true;
            btnResetPose.Click += btnResetPose_Click;
            // 
            // btnResetComplet
            // 
            btnResetComplet.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnResetComplet.Location = new Point(629, 287);
            btnResetComplet.Name = "btnResetComplet";
            btnResetComplet.Size = new Size(169, 90);
            btnResetComplet.TabIndex = 4;
            btnResetComplet.Text = "입력 완료";
            btnResetComplet.UseVisualStyleBackColor = true;
            btnResetComplet.Click += btnResetComplet_Click;
            // 
            // FormCamera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 447);
            Controls.Add(btnResetComplet);
            Controls.Add(btnResetPose);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "FormCamera";
            Text = "FormCamera";
            FormClosing += FormCamera_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Button btnResetPose;
        private Button btnResetComplet;
    }
}