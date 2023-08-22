namespace Vadit
{
    partial class FormPopUp
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
            components = new System.ComponentModel.Container();
            DefaultTimer = new System.Windows.Forms.Timer(components);
            UserPanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            UserPosePicBox = new PictureBox();
            ExamplePosePanel = new Panel();
            ExamplePosePicBox = new PictureBox();
            CommentPanel = new Panel();
            CommentButton = new Button();
            CommentLabel = new Label();
            LongTimer = new System.Windows.Forms.Timer(components);
            UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UserPosePicBox).BeginInit();
            ExamplePosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExamplePosePicBox).BeginInit();
            CommentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DefaultTimer
            // 
            DefaultTimer.Interval = 1000;
            DefaultTimer.Tick += DefaultTimer_Tick;
            // 
            // UserPanel
            // 
            UserPanel.BackColor = Color.Gray;
            UserPanel.Controls.Add(label1);
            UserPanel.Controls.Add(label2);
            UserPanel.Controls.Add(UserPosePicBox);
            UserPanel.Dock = DockStyle.Top;
            UserPanel.Location = new Point(10, 10);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(330, 175);
            UserPanel.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 6);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 6);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // UserPosePicBox
            // 
            UserPosePicBox.Dock = DockStyle.Fill;
            UserPosePicBox.Location = new Point(0, 0);
            UserPosePicBox.Name = "UserPosePicBox";
            UserPosePicBox.Padding = new Padding(5, 5, 5, 5);
            UserPosePicBox.Size = new Size(330, 175);
            UserPosePicBox.TabIndex = 0;
            UserPosePicBox.TabStop = false;
            // 
            // ExamplePosePanel
            // 
            ExamplePosePanel.BackColor = Color.Silver;
            ExamplePosePanel.Controls.Add(ExamplePosePicBox);
            ExamplePosePanel.Dock = DockStyle.Top;
            ExamplePosePanel.Location = new Point(10, 185);
            ExamplePosePanel.Margin = new Padding(5, 5, 5, 5);
            ExamplePosePanel.Name = "ExamplePosePanel";
            ExamplePosePanel.Size = new Size(330, 175);
            ExamplePosePanel.TabIndex = 3;
            // 
            // ExamplePosePicBox
            // 
            ExamplePosePicBox.Dock = DockStyle.Fill;
            ExamplePosePicBox.Location = new Point(0, 0);
            ExamplePosePicBox.Name = "ExamplePosePicBox";
            ExamplePosePicBox.Padding = new Padding(5, 5, 5, 5);
            ExamplePosePicBox.Size = new Size(330, 175);
            ExamplePosePicBox.TabIndex = 0;
            ExamplePosePicBox.TabStop = false;
            // 
            // CommentPanel
            // 
            CommentPanel.BackColor = Color.FromArgb(224, 224, 224);
            CommentPanel.Controls.Add(CommentButton);
            CommentPanel.Controls.Add(CommentLabel);
            CommentPanel.Dock = DockStyle.Top;
            CommentPanel.Location = new Point(10, 360);
            CommentPanel.Name = "CommentPanel";
            CommentPanel.Size = new Size(330, 70);
            CommentPanel.TabIndex = 3;
            // 
            // CommentButton
            // 
            CommentButton.BackColor = Color.FromArgb(0, 0, 0, 0);
            CommentButton.FlatAppearance.BorderSize = 0;
            CommentButton.FlatStyle = FlatStyle.Flat;
            CommentButton.Font = new Font("맑은 고딕", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            CommentButton.Location = new Point(3, 3);
            CommentButton.Name = "CommentButton";
            CommentButton.Size = new Size(324, 64);
            CommentButton.TabIndex = 1;
            CommentButton.Text = "틀린자세 텍스트";
            CommentButton.UseVisualStyleBackColor = false;
            // 
            // CommentLabel
            // 
            CommentLabel.AutoSize = true;
            CommentLabel.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            CommentLabel.Location = new Point(128, 27);
            CommentLabel.Name = "CommentLabel";
            CommentLabel.Size = new Size(78, 17);
            CommentLabel.TabIndex = 0;
            CommentLabel.Text = "택스트 위치";
            CommentLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormPopUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 51, 56);
            ClientSize = new Size(350, 440);
            Controls.Add(CommentPanel);
            Controls.Add(ExamplePosePanel);
            Controls.Add(UserPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormPopUp";
            Padding = new Padding(10, 10, 10, 10);
            StartPosition = FormStartPosition.Manual;
            Text = "FormPopUp";
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UserPosePicBox).EndInit();
            ExamplePosePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ExamplePosePicBox).EndInit();
            CommentPanel.ResumeLayout(false);
            CommentPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer DefaultTimer;
        private Panel UserPanel;
        private Label label2;
        private PictureBox UserPosePicBox;
        private Panel ExamplePosePanel;
        private PictureBox ExamplePosePicBox;
        private Panel CommentPanel;
        private Button CommentButton;
        private Label CommentLabel;
        private Label label1;
        private System.Windows.Forms.Timer LongTimer;
    }
}