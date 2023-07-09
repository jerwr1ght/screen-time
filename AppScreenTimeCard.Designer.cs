namespace ScreenTime
{
    partial class AppScreenTimeCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            appIcon = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            appName = new MaterialSkin.Controls.MaterialLabel();
            progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            timeLabel = new MaterialSkin.Controls.MaterialLabel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appIcon).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(appIcon, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(350, 80);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // appIcon
            // 
            appIcon.BackColor = Color.Transparent;
            appIcon.BackgroundImageLayout = ImageLayout.Center;
            appIcon.Dock = DockStyle.Fill;
            appIcon.Location = new Point(3, 3);
            appIcon.Name = "appIcon";
            appIcon.Size = new Size(64, 74);
            appIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            appIcon.TabIndex = 1;
            appIcon.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(appName, 0, 0);
            tableLayoutPanel2.Controls.Add(progressBar, 0, 1);
            tableLayoutPanel2.Controls.Add(timeLabel, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(73, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new Size(274, 74);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // appName
            // 
            appName.AutoSize = true;
            appName.Depth = 0;
            appName.Dock = DockStyle.Fill;
            appName.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            appName.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            appName.Location = new Point(3, 0);
            appName.MouseState = MaterialSkin.MouseState.HOVER;
            appName.Name = "appName";
            appName.Size = new Size(185, 44);
            appName.TabIndex = 0;
            appName.Text = "App name";
            appName.TextAlign = ContentAlignment.BottomLeft;
            // 
            // progressBar
            // 
            progressBar.Depth = 0;
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(3, 50);
            progressBar.Margin = new Padding(3, 6, 3, 3);
            progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(185, 5);
            progressBar.TabIndex = 1;
            progressBar.Value = 50;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Depth = 0;
            timeLabel.Dock = DockStyle.Fill;
            timeLabel.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            timeLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            timeLabel.Location = new Point(194, 44);
            timeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(77, 30);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "23 год";
            timeLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AppScreenTimeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4);
            Name = "AppScreenTimeCard";
            Size = new Size(350, 80);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)appIcon).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox appIcon;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel appName;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;
        private MaterialSkin.Controls.MaterialLabel timeLabel;
    }
}
