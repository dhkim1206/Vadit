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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tbtesttext = new TextBox();
            pnWait = new Panel();
            lbwait = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            pnWait.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDarkDark;
            pictureBox1.Location = new Point(17, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 333);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ControlDarkDark;
            pictureBox2.Location = new Point(401, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(361, 333);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // btnResetPose
            // 
            btnResetPose.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnResetPose.Location = new Point(288, 381);
            btnResetPose.Name = "btnResetPose";
            btnResetPose.Size = new Size(87, 38);
            btnResetPose.TabIndex = 3;
            btnResetPose.Text = "자세촬영";
            btnResetPose.UseVisualStyleBackColor = true;
            btnResetPose.Click += btnResetPose_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, -3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(786, 453);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbtesttext);
            tabPage1.Controls.Add(pnWait);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(pictureBox1);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(btnResetPose);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(778, 425);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "바른 자세촬영";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbtesttext
            // 
            tbtesttext.Location = new Point(401, 381);
            tbtesttext.Name = "tbtesttext";
            tbtesttext.Size = new Size(361, 23);
            tbtesttext.TabIndex = 9;
            // 
            // pnWait
            // 
            pnWait.Controls.Add(lbwait);
            pnWait.Location = new Point(225, 164);
            pnWait.Name = "pnWait";
            pnWait.Size = new Size(312, 40);
            pnWait.TabIndex = 8;
            pnWait.Visible = false;
            // 
            // lbwait
            // 
            lbwait.AutoSize = true;
            lbwait.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbwait.Location = new Point(15, 11);
            lbwait.Name = "lbwait";
            lbwait.Size = new Size(258, 17);
            lbwait.TabIndex = 8;
            lbwait.Text = "자세를 분석할 동안 잠시만 기다려 주세요!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(404, 18);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 7;
            label2.Text = "설정된 바른자세";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 18);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "카메라";
            // 
            // FormCamera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 447);
            Controls.Add(tabControl1);
            Name = "FormCamera";
            Text = "FormCamera";
            FormClosing += FormCamera_FormClosing;
            Load += FormCamera_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            pnWait.ResumeLayout(false);
            pnWait.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button btnResetPose;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox tbtesttext;
        private Panel pnWait;
        private Label lbwait;
        private Label label2;
        private Label label1;
    }
}