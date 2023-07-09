namespace ScreenTime
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new ImageList(components);
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dateBackButton = new MaterialSkin.Controls.MaterialButton();
            dateForwardButton = new MaterialSkin.Controls.MaterialButton();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            flowLayoutPanel1 = new FlowLayoutPanel();
            searchDateLabel = new MaterialSkin.Controls.MaterialLabel();
            chartDatesLabel = new MaterialSkin.Controls.MaterialLabel();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            contextMenuStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            materialTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "1.png");
            imageList1.Images.SetKeyName(1, "7.png");
            imageList1.Images.SetKeyName(2, "home.png");
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "The app is closed and located in tray";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(123, 48);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(122, 22);
            openToolStripMenuItem.Text = "Відкрити";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(122, 22);
            closeToolStripMenuItem.Text = "Закрити";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.Controls.Add(tableLayoutPanel2);
            tabPage2.ImageKey = "7.png";
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1049, 532);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Тиждень";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(materialLabel2, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1043, 526);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Fill;
            materialLabel2.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel2.Location = new Point(3, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(1037, 526);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "Упс... ця фіча ще в розробці\r\n\r\n(╮°-°)╮┳━━┳ (╯°□°)╯ ┻━━┻";
            materialLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateBackButton
            // 
            dateBackButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dateBackButton.Cursor = Cursors.Hand;
            dateBackButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            dateBackButton.Depth = 0;
            dateBackButton.Dock = DockStyle.Fill;
            dateBackButton.HighEmphasis = true;
            dateBackButton.Icon = Properties.Resources.left_arrow;
            dateBackButton.Location = new Point(6, 5);
            dateBackButton.Margin = new Padding(0);
            dateBackButton.MouseState = MaterialSkin.MouseState.HOVER;
            dateBackButton.Name = "dateBackButton";
            dateBackButton.NoAccentTextColor = Color.Empty;
            dateBackButton.RightToLeft = RightToLeft.No;
            dateBackButton.Size = new Size(103, 26);
            dateBackButton.TabIndex = 0;
            dateBackButton.Text = "Назад";
            dateBackButton.TextAlign = ContentAlignment.MiddleRight;
            dateBackButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            dateBackButton.UseAccentColor = false;
            dateBackButton.UseVisualStyleBackColor = true;
            dateBackButton.Click += dateBackButton_Click;
            // 
            // dateForwardButton
            // 
            dateForwardButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dateForwardButton.Cursor = Cursors.Hand;
            dateForwardButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            dateForwardButton.Depth = 0;
            dateForwardButton.Dock = DockStyle.Fill;
            dateForwardButton.HighEmphasis = true;
            dateForwardButton.Icon = Properties.Resources.right_arrow;
            dateForwardButton.Location = new Point(940, 5);
            dateForwardButton.Margin = new Padding(0);
            dateForwardButton.MouseState = MaterialSkin.MouseState.HOVER;
            dateForwardButton.Name = "dateForwardButton";
            dateForwardButton.NoAccentTextColor = Color.Empty;
            dateForwardButton.RightToLeft = RightToLeft.No;
            dateForwardButton.Size = new Size(105, 26);
            dateForwardButton.TabIndex = 1;
            dateForwardButton.Text = "Вперед";
            dateForwardButton.TextAlign = ContentAlignment.MiddleRight;
            dateForwardButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            dateForwardButton.UseAccentColor = false;
            dateForwardButton.UseVisualStyleBackColor = true;
            dateForwardButton.Click += dateForwardButton_Click;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.ImageKey = "1.png";
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1049, 532);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "День";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(cartesianChart1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutPanel1.Controls.Add(dateBackButton, 0, 0);
            tableLayoutPanel1.Controls.Add(dateForwardButton, 2, 0);
            tableLayoutPanel1.Controls.Add(searchDateLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(chartDatesLabel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(6, 5, 4, 5);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.Size = new Size(1049, 532);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // cartesianChart1
            // 
            tableLayoutPanel1.SetColumnSpan(cartesianChart1, 3);
            cartesianChart1.Dock = DockStyle.Fill;
            cartesianChart1.Location = new Point(24, 48);
            cartesianChart1.Margin = new Padding(18, 17, 18, 17);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1003, 200);
            cartesianChart1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(6, 291);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1039, 236);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // searchDateLabel
            // 
            searchDateLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(searchDateLabel, 3);
            searchDateLabel.Depth = 0;
            searchDateLabel.Dock = DockStyle.Fill;
            searchDateLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            searchDateLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            searchDateLabel.Location = new Point(6, 265);
            searchDateLabel.Margin = new Padding(0);
            searchDateLabel.MouseState = MaterialSkin.MouseState.HOVER;
            searchDateLabel.Name = "searchDateLabel";
            searchDateLabel.Size = new Size(1039, 26);
            searchDateLabel.TabIndex = 5;
            searchDateLabel.Text = "materialLabel2";
            searchDateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chartDatesLabel
            // 
            chartDatesLabel.AutoSize = true;
            chartDatesLabel.Depth = 0;
            chartDatesLabel.Dock = DockStyle.Fill;
            chartDatesLabel.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            chartDatesLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            chartDatesLabel.Location = new Point(112, 8);
            chartDatesLabel.Margin = new Padding(3);
            chartDatesLabel.MouseState = MaterialSkin.MouseState.HOVER;
            chartDatesLabel.Name = "chartDatesLabel";
            chartDatesLabel.Size = new Size(825, 20);
            chartDatesLabel.TabIndex = 6;
            chartDatesLabel.Text = "materialLabel2";
            chartDatesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(0, 24);
            materialTabControl1.Margin = new Padding(0);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1057, 573);
            materialTabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1060, 600);
            Controls.Add(materialTabControl1);
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerHighlightWithAccent = false;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            ForeColor = Color.Coral;
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1060, 600);
            Name = "Form1";
            Padding = new Padding(0, 24, 3, 3);
            Text = "Screen Time";
            FormClosing += Form1_FormClosing;
            contextMenuStrip1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            materialTabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private ImageList imageList1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private MaterialSkin.Controls.MaterialButton dateBackButton;
        private MaterialSkin.Controls.MaterialButton dateForwardButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel searchDateLabel;
        private MaterialSkin.Controls.MaterialLabel chartDatesLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}