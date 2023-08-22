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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            PictureFlowLayout = new FlowLayoutPanel();
            pn_Nodata = new Panel();
            lb_NoData = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            pn_Nodata.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(43, 45, 49);
            chart1.BackgroundImageLayout = ImageLayout.None;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Location = new Point(24, 12);
            chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series2";
            chart1.Series.Add(series3);
            chart1.Series.Add(series4);
            chart1.Size = new Size(756, 300);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            title2.Font = new Font("함초롬돋움", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            title2.ForeColor = Color.White;
            title2.Name = "Title1";
            title2.Text = "자세 점수";
            chart1.Titles.Add(title2);
            // 
            // PictureFlowLayout
            // 
            PictureFlowLayout.BackColor = Color.FromArgb(43, 45, 49);
            PictureFlowLayout.Location = new Point(24, 335);
            PictureFlowLayout.Name = "PictureFlowLayout";
            PictureFlowLayout.Size = new Size(756, 120);
            PictureFlowLayout.TabIndex = 1;
            // 
            // pn_Nodata
            // 
            pn_Nodata.BackColor = Color.FromArgb(43, 45, 49);
            pn_Nodata.Controls.Add(lb_NoData);
            pn_Nodata.Location = new Point(24, 332);
            pn_Nodata.Name = "pn_Nodata";
            pn_Nodata.Size = new Size(756, 123);
            pn_Nodata.TabIndex = 7;
            // 
            // lb_NoData
            // 
            lb_NoData.AutoSize = true;
            lb_NoData.BackColor = Color.FromArgb(43, 45, 49);
            lb_NoData.Font = new Font("함초롬돋움", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lb_NoData.ForeColor = Color.White;
            lb_NoData.Location = new Point(288, 42);
            lb_NoData.Name = "lb_NoData";
            lb_NoData.Size = new Size(179, 35);
            lb_NoData.TabIndex = 0;
            lb_NoData.Text = "데이터가 없음";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("함초롬돋움", 8.999999F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.HighlightText;
            label4.Location = new Point(32, 317);
            label4.Name = "label4";
            label4.Size = new Size(83, 16);
            label4.TabIndex = 8;
            label4.Text = "검출된 자세 : ";
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(49, 51, 56);
            ClientSize = new Size(798, 464);
            Controls.Add(label4);
            Controls.Add(pn_Nodata);
            Controls.Add(PictureFlowLayout);
            Controls.Add(chart1);
            Name = "FormStatistics";
            Text = "FormStatistics";
            Load += FormStatistics_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            pn_Nodata.ResumeLayout(false);
            pn_Nodata.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private FlowLayoutPanel PictureFlowLayout;
        private Panel pn_Nodata;
        private Label lb_NoData;
        private Label label4;
    }
}