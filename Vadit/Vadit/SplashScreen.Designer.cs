namespace Vadit
{
    partial class SplashScreen
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
            PbSplash = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PbSplash).BeginInit();
            SuspendLayout();
            // 
            // PbSplash
            // 
            PbSplash.Dock = DockStyle.Fill;
            PbSplash.Location = new Point(0, 0);
            PbSplash.Name = "PbSplash";
            PbSplash.Size = new Size(800, 450);
            PbSplash.SizeMode = PictureBoxSizeMode.AutoSize;
            PbSplash.TabIndex = 0;
            PbSplash.TabStop = false;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(PbSplash);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)PbSplash).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PbSplash;
    }
}