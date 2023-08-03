namespace Vadit
{
    partial class FormPictures
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            PictureGridView = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Picture = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)PictureGridView).BeginInit();
            SuspendLayout();
            // 
            // PictureGridView
            // 
            PictureGridView.AllowUserToAddRows = false;
            PictureGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 0, 64);
            dataGridViewCellStyle1.Font = new Font("함초롬돋움", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 0, 64);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            PictureGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            PictureGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PictureGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            PictureGridView.BackgroundColor = Color.Black;
            PictureGridView.BorderStyle = BorderStyle.Fixed3D;
            PictureGridView.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            PictureGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PictureGridView.Columns.AddRange(new DataGridViewColumn[] { Date, Category, Picture });
            PictureGridView.Dock = DockStyle.Fill;
            PictureGridView.GridColor = Color.Linen;
            PictureGridView.Location = new Point(0, 0);
            PictureGridView.MultiSelect = false;
            PictureGridView.Name = "PictureGridView";
            PictureGridView.ReadOnly = true;
            PictureGridView.RowTemplate.Height = 200;
            PictureGridView.Size = new Size(661, 673);
            PictureGridView.TabIndex = 0;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 58;
            // 
            // Category
            // 
            Category.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Category.HeaderText = "Category";
            Category.Name = "Category";
            Category.ReadOnly = true;
            Category.Width = 83;
            // 
            // Picture
            // 
            Picture.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Picture.FillWeight = 500F;
            Picture.HeaderText = "Picture";
            Picture.Name = "Picture";
            Picture.ReadOnly = true;
            Picture.Width = 53;
            // 
            // FormPictures
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(661, 673);
            Controls.Add(PictureGridView);
            Font = new Font("함초롬돋움", 8.999999F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormPictures";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPictures";
            ((System.ComponentModel.ISupportInitialize)PictureGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView PictureGridView;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewImageColumn Picture;
    }
}