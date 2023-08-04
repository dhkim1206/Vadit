namespace Vadit
{
    partial class FormStatistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            PictureFlowLayout = new FlowLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(38, 38, 38);
            chart1.BackgroundImageLayout = ImageLayout.None;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Location = new Point(12, 12);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series2";
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Size = new Size(723, 300);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            // 
            // PictureFlowLayout
            // 
            PictureFlowLayout.AutoScroll = true;
            PictureFlowLayout.Location = new Point(24, 328);
            PictureFlowLayout.Name = "PictureFlowLayout";
            PictureFlowLayout.Size = new Size(774, 120);
            PictureFlowLayout.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(616, 299);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(697, 299);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(812, 475);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(PictureFlowLayout);
            Controls.Add(chart1);
            Name = "FormStatistics";
            Text = "FormStatistics";
            Load += FormStatistics_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private FlowLayoutPanel PictureFlowLayout;
        private Button button1;
        private Button button2;
    }
}