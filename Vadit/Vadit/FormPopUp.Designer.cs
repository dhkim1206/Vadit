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
            UserPosePicBox = new PictureBox();
            LbBadPoseName = new Label();
            ExamplePosePanel = new Panel();
            ExamplePosePicBox = new PictureBox();
            CommentPanel = new Panel();
            LbLongTime = new Label();
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
            UserPanel.Controls.Add(UserPosePicBox);
            UserPanel.Dock = DockStyle.Top;
            UserPanel.Location = new Point(10, 10);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(330, 175);
            UserPanel.TabIndex = 6;
            // 
            // UserPosePicBox
            // 
            UserPosePicBox.Dock = DockStyle.Fill;
            UserPosePicBox.Location = new Point(0, 0);
            UserPosePicBox.Name = "UserPosePicBox";
            UserPosePicBox.Padding = new Padding(5);
            UserPosePicBox.Size = new Size(330, 175);
            UserPosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            UserPosePicBox.TabIndex = 0;
            UserPosePicBox.TabStop = false;
            // 
            // LbBadPoseName
            // 
            LbBadPoseName.AutoSize = true;
            LbBadPoseName.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            LbBadPoseName.Location = new Point(132, 26);
            LbBadPoseName.Margin = new Padding(2, 0, 2, 0);
            LbBadPoseName.Name = "LbBadPoseName";
            LbBadPoseName.Size = new Size(0, 20);
            LbBadPoseName.TabIndex = 1;
            // 
            // ExamplePosePanel
            // 
            ExamplePosePanel.BackColor = Color.Silver;
            ExamplePosePanel.Controls.Add(ExamplePosePicBox);
            ExamplePosePanel.Dock = DockStyle.Top;
            ExamplePosePanel.Location = new Point(10, 185);
            ExamplePosePanel.Margin = new Padding(5);
            ExamplePosePanel.Name = "ExamplePosePanel";
            ExamplePosePanel.Size = new Size(330, 175);
            ExamplePosePanel.TabIndex = 3;
            // 
            // ExamplePosePicBox
            // 
            ExamplePosePicBox.Dock = DockStyle.Fill;
            ExamplePosePicBox.Location = new Point(0, 0);
            ExamplePosePicBox.Name = "ExamplePosePicBox";
            ExamplePosePicBox.Padding = new Padding(5);
            ExamplePosePicBox.Size = new Size(330, 175);
            ExamplePosePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ExamplePosePicBox.TabIndex = 0;
            ExamplePosePicBox.TabStop = false;
            // 
            // CommentPanel
            // 
            CommentPanel.BackColor = Color.FromArgb(224, 224, 224);
            CommentPanel.Controls.Add(LbLongTime);
            CommentPanel.Controls.Add(LbBadPoseName);
            CommentPanel.Dock = DockStyle.Top;
            CommentPanel.Location = new Point(10, 360);
            CommentPanel.Name = "CommentPanel";
            CommentPanel.Size = new Size(330, 70);
            CommentPanel.TabIndex = 3;
            // 
            // LbLongTime
            // 
            LbLongTime.AutoSize = true;
            LbLongTime.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            LbLongTime.Location = new Point(21, 17);
            LbLongTime.Margin = new Padding(2, 0, 2, 0);
            LbLongTime.Name = "LbLongTime";
            LbLongTime.Size = new Size(0, 20);
            LbLongTime.TabIndex = 2;
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
            Margin = new Padding(2);
            Name = "FormPopUp";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.Manual;
            Text = "FormPopUp";
            UserPanel.ResumeLayout(false);
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
        private PictureBox UserPosePicBox;
        private Panel ExamplePosePanel;
        private PictureBox ExamplePosePicBox;
        private Panel CommentPanel;
        private Label LbBadPoseName;
        private System.Windows.Forms.Timer LongTimer;
        private Label LbLongTime;
    }
}