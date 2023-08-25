namespace Vadit
{
    partial class FormExplain
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("함초롬돋움", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(56, 37);
            label2.Name = "label2";
            label2.Size = new Size(138, 27);
            label2.TabIndex = 1;
            label2.Text = "프로그램 설명";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(728, 17);
            label3.TabIndex = 2;
            label3.Text = "해당 프로그램은 Openpose와 Body25와 같은 라이브러리를 활용하여 각 사용자의 신체 부위별 좌표값을 실시간 분석합니다.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(13, 121);
            label4.Name = "label4";
            label4.Size = new Size(535, 17);
            label4.TabIndex = 3;
            label4.Text = "이 분석된 좌표값은 다양한 VDT 증후군 자세의 특징과 비교하여 일치하는지를 검사합니다. ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 153);
            label1.Name = "label1";
            label1.Size = new Size(687, 17);
            label1.TabIndex = 4;
            label1.Text = "사용자의 바른 자세 이미지를 기준으로 설정하고, 이를 바탕으로 좌표값의 정확한 기준점을 파악하여 검출의 정확도를";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.free_icon_biotech_3055629;
            pictureBox1.Location = new Point(13, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(13, 183);
            label5.Name = "label5";
            label5.Size = new Size(774, 17);
            label5.TabIndex = 6;
            label5.Text = "향상시키기 위한 노력이 이루어졌습니다. 이를 통해 오차 범위를 최소화하고 보다 정확한 증후군 검출을 실현하도록 설계되었습니다.";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.KakaoTalk_20230821_104347268;
            pictureBox2.Location = new Point(13, 245);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(12, 302);
            label9.Name = "label9";
            label9.Size = new Size(785, 17);
            label9.TabIndex = 8;
            label9.Text = "해당 프로그램은 계명대학교 학생 김도형, 김명준, 박선형 학생이 (주)메디알테크놀로지와 산학협력 프로젝트로 개발한 프로그램입니다";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("함초롬돋움", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(56, 249);
            label10.Name = "label10";
            label10.Size = new Size(72, 27);
            label10.TabIndex = 7;
            label10.Text = "제작자";
            // 
            // FormExplain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(49, 51, 56);
            ClientSize = new Size(800, 620);
            Controls.Add(pictureBox2);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormExplain";
            Text = "FormExplain";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label5;
        private PictureBox pictureBox2;
        private Label label9;
        private Label label10;
    }
}