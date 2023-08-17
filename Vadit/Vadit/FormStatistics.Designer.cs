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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            PictureFlowLayout = new FlowLayoutPanel();
            lb_NoData = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pn_Nodata = new Panel();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            pn_Nodata.SuspendLayout();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(38, 38, 38);
            chart1.BackgroundImageLayout = ImageLayout.None;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Location = new Point(24, 12);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series2";
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Size = new Size(774, 300);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            title1.Font = new Font("함초롬돋움", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            title1.ForeColor = Color.White;
            title1.Name = "Title1";
            title1.Text = "좋은 자세 비율";
            chart1.Titles.Add(title1);
            // 
            // PictureFlowLayout
            // 
            PictureFlowLayout.Location = new Point(24, 335);
            PictureFlowLayout.Name = "PictureFlowLayout";
            PictureFlowLayout.Size = new Size(774, 120);
            PictureFlowLayout.TabIndex = 1;
            // 
            // lb_NoData
            // 
            lb_NoData.AutoSize = true;
            lb_NoData.Font = new Font("함초롬돋움", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lb_NoData.ForeColor = Color.White;
            lb_NoData.Location = new Point(288, 42);
            lb_NoData.Name = "lb_NoData";
            lb_NoData.Size = new Size(179, 35);
            lb_NoData.TabIndex = 0;
            lb_NoData.Text = "데이터가 없음";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(139, 313);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "거북목 : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(215, 313);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 4;
            label2.Text = "척추 측만증 : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(321, 314);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 5;
            label3.Text = "추간판 탈출 : ";
            // 
            // pn_Nodata
            // 
            pn_Nodata.Controls.Add(lb_NoData);
            pn_Nodata.Location = new Point(24, 332);
            pn_Nodata.Name = "pn_Nodata";
            pn_Nodata.Size = new Size(774, 123);
            pn_Nodata.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(36, 313);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 7;
            label4.Text = "검출된 자세 : ";
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 38, 38);
            ClientSize = new Size(812, 475);
            Controls.Add(label4);
            Controls.Add(pn_Nodata);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lb_NoData;
        private Panel pn_Nodata;
        private Label label4;
    }
}