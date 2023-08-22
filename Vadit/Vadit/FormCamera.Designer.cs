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
            pictureBox2 = new PictureBox();
            btnResetPose = new Button();
            tbtesttext = new TextBox();
            pnWait = new Panel();
            lbwait = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_exit = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnWait.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(32, 33, 36);
            pictureBox1.Location = new Point(32, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 333);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(32, 33, 36);
            pictureBox2.Location = new Point(416, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(361, 333);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // btnResetPose
            // 
            btnResetPose.BackColor = Color.FromArgb(38, 38, 38);
            btnResetPose.BackgroundImageLayout = ImageLayout.None;
            btnResetPose.FlatStyle = FlatStyle.Flat;
            btnResetPose.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnResetPose.ForeColor = Color.White;
            btnResetPose.Location = new Point(303, 429);
            btnResetPose.Name = "btnResetPose";
            btnResetPose.Size = new Size(87, 38);
            btnResetPose.TabIndex = 3;
            btnResetPose.Text = "자세촬영";
            btnResetPose.UseVisualStyleBackColor = false;
            btnResetPose.Click += btnResetPose_Click;
            // 
            // tbtesttext
            // 
            tbtesttext.BackColor = Color.FromArgb(38, 38, 38);
            tbtesttext.ForeColor = Color.White;
            tbtesttext.Location = new Point(416, 440);
            tbtesttext.Name = "tbtesttext";
            tbtesttext.Size = new Size(361, 23);
            tbtesttext.TabIndex = 9;
            // 
            // pnWait
            // 
            pnWait.Controls.Add(lbwait);
            pnWait.Location = new Point(240, 212);
            pnWait.Name = "pnWait";
            pnWait.Size = new Size(312, 40);
            pnWait.TabIndex = 8;
            pnWait.Visible = false;
            // 
            // lbwait
            // 
            lbwait.AutoSize = true;
            lbwait.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbwait.ForeColor = Color.White;
            lbwait.Location = new Point(15, 11);
            lbwait.Name = "lbwait";
            lbwait.Size = new Size(258, 17);
            lbwait.TabIndex = 8;
            lbwait.Text = "자세를 분석할 동안 잠시만 기다려 주세요!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(426, 65);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 7;
            label2.Text = "설정된 바른자세";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 65);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "카메라";
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.FromArgb(32, 33, 36);
            btn_exit.BackgroundImageLayout = ImageLayout.None;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Calibri", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exit.ForeColor = SystemColors.ButtonShadow;
            btn_exit.Location = new Point(773, 3);
            btn_exit.Name = "btn_exit";
            btn_exit.RightToLeft = RightToLeft.Yes;
            btn_exit.Size = new Size(34, 28);
            btn_exit.TabIndex = 4;
            btn_exit.Text = "X";
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(32, 33, 36);
            panel1.Controls.Add(btn_exit);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(812, 40);
            panel1.TabIndex = 10;
            // 
            // FormCamera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(812, 490);
            Controls.Add(panel1);
            Controls.Add(tbtesttext);
            Controls.Add(pnWait);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(btnResetPose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCamera";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCamera";
            FormClosing += FormCamera_FormClosing;
            Load += FormCamera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnWait.ResumeLayout(false);
            pnWait.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnResetPose;
        private TextBox tbtesttext;
        private Panel pnWait;
        private Label lbwait;
        private Label label2;
        private Label label1;
        private Button btn_exit;
        private Panel panel1;
    }
}