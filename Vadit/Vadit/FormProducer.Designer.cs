﻿namespace Vadit
{
    partial class FormProducer
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 25);
            label1.Name = "label1";
            label1.Size = new Size(54, 19);
            label1.TabIndex = 1;
            label1.Text = "제작자";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(107, 291);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 2;
            label2.Text = "김도형";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(375, 291);
            label3.Name = "label3";
            label3.Size = new Size(54, 19);
            label3.TabIndex = 6;
            label3.Text = "김명준";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(641, 291);
            label4.Name = "label4";
            label4.Size = new Size(54, 19);
            label4.TabIndex = 7;
            label4.Text = "박선형";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("함초롬돋움", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(66, 63);
            label5.Name = "label5";
            label5.Size = new Size(679, 19);
            label5.TabIndex = 8;
            label5.Text = "위 프로그램은 계명대학교 학생과 메디알 테크놀로지와 산학협력프로젝트로 진행한 프로그램입니다";
            // 
            // FormProducer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 51, 56);
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProducer";
            Text = "FormProducer";
            Load += FormProducer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}