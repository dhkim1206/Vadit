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
            this.components = new System.ComponentModel.Container();
            this.DefaultTimer = new System.Windows.Forms.Timer(this.components);
            this.UserPanel = new System.Windows.Forms.Panel();
            this.UserPosePicBox = new System.Windows.Forms.PictureBox();
            this.ExamplePosePanel = new System.Windows.Forms.Panel();
            this.ExamplePosePicBox = new System.Windows.Forms.PictureBox();
            this.CommentPanel = new System.Windows.Forms.Panel();
            this.CommentButton = new System.Windows.Forms.Button();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.LongTimer = new System.Windows.Forms.Timer(this.components);
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserPosePicBox)).BeginInit();
            this.ExamplePosePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExamplePosePicBox)).BeginInit();
            this.CommentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DefaultTimer
            // 
            this.DefaultTimer.Interval = 1000;
            this.DefaultTimer.Tick += new System.EventHandler(this.DefaultTimer_Tick);
            // 
            // UserPanel
            // 
            this.UserPanel.BackColor = System.Drawing.Color.Gray;
            this.UserPanel.Controls.Add(this.UserPosePicBox);
            this.UserPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserPanel.Location = new System.Drawing.Point(13, 13);
            this.UserPanel.Margin = new System.Windows.Forms.Padding(4);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(424, 233);
            this.UserPanel.TabIndex = 6;
            // 
            // UserPosePicBox
            // 
            this.UserPosePicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPosePicBox.Location = new System.Drawing.Point(0, 0);
            this.UserPosePicBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserPosePicBox.Name = "UserPosePicBox";
            this.UserPosePicBox.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.UserPosePicBox.Size = new System.Drawing.Size(424, 233);
            this.UserPosePicBox.TabIndex = 0;
            this.UserPosePicBox.TabStop = false;
            // 
            // ExamplePosePanel
            // 
            this.ExamplePosePanel.BackColor = System.Drawing.Color.Silver;
            this.ExamplePosePanel.Controls.Add(this.ExamplePosePicBox);
            this.ExamplePosePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExamplePosePanel.Location = new System.Drawing.Point(13, 246);
            this.ExamplePosePanel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ExamplePosePanel.Name = "ExamplePosePanel";
            this.ExamplePosePanel.Size = new System.Drawing.Size(424, 233);
            this.ExamplePosePanel.TabIndex = 3;
            // 
            // ExamplePosePicBox
            // 
            this.ExamplePosePicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExamplePosePicBox.Location = new System.Drawing.Point(0, 0);
            this.ExamplePosePicBox.Margin = new System.Windows.Forms.Padding(4);
            this.ExamplePosePicBox.Name = "ExamplePosePicBox";
            this.ExamplePosePicBox.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.ExamplePosePicBox.Size = new System.Drawing.Size(424, 233);
            this.ExamplePosePicBox.TabIndex = 0;
            this.ExamplePosePicBox.TabStop = false;
            // 
            // CommentPanel
            // 
            this.CommentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CommentPanel.Controls.Add(this.CommentButton);
            this.CommentPanel.Controls.Add(this.CommentLabel);
            this.CommentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CommentPanel.Location = new System.Drawing.Point(13, 479);
            this.CommentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.CommentPanel.Name = "CommentPanel";
            this.CommentPanel.Size = new System.Drawing.Size(424, 93);
            this.CommentPanel.TabIndex = 3;
            // 
            // CommentButton
            // 
            this.CommentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CommentButton.FlatAppearance.BorderSize = 0;
            this.CommentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CommentButton.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CommentButton.Location = new System.Drawing.Point(4, 4);
            this.CommentButton.Margin = new System.Windows.Forms.Padding(4);
            this.CommentButton.Name = "CommentButton";
            this.CommentButton.Size = new System.Drawing.Size(417, 85);
            this.CommentButton.TabIndex = 1;
            this.CommentButton.Text = "틀린자세 텍스트";
            this.CommentButton.UseVisualStyleBackColor = false;
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CommentLabel.Location = new System.Drawing.Point(165, 36);
            this.CommentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(101, 23);
            this.CommentLabel.TabIndex = 0;
            this.CommentLabel.Text = "택스트 위치";
            this.CommentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(450, 587);
            this.Controls.Add(this.CommentPanel);
            this.Controls.Add(this.ExamplePosePanel);
            this.Controls.Add(this.UserPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPopUp";
            this.Padding = new System.Windows.Forms.Padding(13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormPopUp";
            this.VisibleChanged += new System.EventHandler(this.FormPopUp_VisibleChanged);
            this.UserPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserPosePicBox)).EndInit();
            this.ExamplePosePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExamplePosePicBox)).EndInit();
            this.CommentPanel.ResumeLayout(false);
            this.CommentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer DefaultTimer;
        private Panel UserPanel;
        private PictureBox UserPosePicBox;
        private Panel ExamplePosePanel;
        private PictureBox ExamplePosePicBox;
        private Panel CommentPanel;
        private Button CommentButton;
        private Label CommentLabel;
        private System.Windows.Forms.Timer LongTimer;
    }
}