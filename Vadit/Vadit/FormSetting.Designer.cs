namespace Vadit
{
    partial class FormSetting
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(475, 360);
            button1.Name = "button1";
            button1.Size = new Size(313, 78);
            button1.TabIndex = 0;
            button1.Text = "자세 재설정 하기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormSetting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Name = "FormSetting";
            Text = "FormSetting";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}