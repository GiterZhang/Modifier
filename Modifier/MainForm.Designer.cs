namespace Modifier
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.全部最大值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部最小值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部设定值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.moduleStausLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.aboutLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 145);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(10, 6);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(821, 470);
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(813, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(813, 438);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(813, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "test";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeColumns = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.BackgroundColor = System.Drawing.Color.White;
            this.gridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.function,
            this.value,
            this.errorText});
            this.gridView.ContextMenuStrip = this.contextMenu;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.GridColor = System.Drawing.Color.LightGray;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.Name = "gridView";
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridView.Size = new System.Drawing.Size(813, 438);
            this.gridView.TabIndex = 1;
            this.gridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridView_CellBeginEdit);
            this.gridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellEndEdit);
            this.gridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellValueChanged);
            // 
            // function
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.function.DefaultCellStyle = dataGridViewCellStyle1;
            this.function.HeaderText = "功能";
            this.function.Name = "function";
            this.function.ReadOnly = true;
            this.function.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.function.Width = 250;
            // 
            // value
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.value.DefaultCellStyle = dataGridViewCellStyle2;
            this.value.HeaderText = "值";
            this.value.Name = "value";
            this.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.value.Width = 220;
            // 
            // errorText
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Red;
            this.errorText.DefaultCellStyle = dataGridViewCellStyle3;
            this.errorText.HeaderText = "提示";
            this.errorText.Name = "errorText";
            this.errorText.ReadOnly = true;
            this.errorText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.errorText.Width = 330;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.全部最大值ToolStripMenuItem,
            this.全部最小值ToolStripMenuItem,
            this.全部设定值ToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(137, 98);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // 全部最大值ToolStripMenuItem
            // 
            this.全部最大值ToolStripMenuItem.Name = "全部最大值ToolStripMenuItem";
            this.全部最大值ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.全部最大值ToolStripMenuItem.Text = "全部最大值";
            this.全部最大值ToolStripMenuItem.Click += new System.EventHandler(this.全部最大值ToolStripMenuItem_Click);
            // 
            // 全部最小值ToolStripMenuItem
            // 
            this.全部最小值ToolStripMenuItem.Name = "全部最小值ToolStripMenuItem";
            this.全部最小值ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.全部最小值ToolStripMenuItem.Text = "全部最小值";
            this.全部最小值ToolStripMenuItem.Click += new System.EventHandler(this.全部最小值ToolStripMenuItem_Click);
            // 
            // 全部设定值ToolStripMenuItem
            // 
            this.全部设定值ToolStripMenuItem.Name = "全部设定值ToolStripMenuItem";
            this.全部设定值ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.全部设定值ToolStripMenuItem.Text = "全部设定值";
            this.全部设定值ToolStripMenuItem.Click += new System.EventHandler(this.全部设定值ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moduleStausLabel,
            this.currentStatusStrip,
            this.versionLabel,
            this.linkLabel1,
            this.linkLabel2,
            this.linkLabel3,
            this.toolStripStatusLabel1,
            this.aboutLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 611);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(821, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // moduleStausLabel
            // 
            this.moduleStausLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.moduleStausLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.moduleStausLabel.Name = "moduleStausLabel";
            this.moduleStausLabel.Size = new System.Drawing.Size(72, 21);
            this.moduleStausLabel.Text = "模块未运行";
            // 
            // currentStatusStrip
            // 
            this.currentStatusStrip.AutoSize = false;
            this.currentStatusStrip.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.currentStatusStrip.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.currentStatusStrip.Name = "currentStatusStrip";
            this.currentStatusStrip.Size = new System.Drawing.Size(150, 21);
            this.currentStatusStrip.Text = "当前状态：未运行";
            this.currentStatusStrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // versionLabel
            // 
            this.versionLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.versionLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(60, 21);
            this.versionLabel.Text = "版本号：";
            // 
            // linkLabel1
            // 
            this.linkLabel1.IsLink = true;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 21);
            this.linkLabel1.Text = "3dm论坛";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.IsLink = true;
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(68, 21);
            this.linkLabel2.Text = "nba2k贴吧";
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.linkLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.linkLabel3.IsLink = true;
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(60, 21);
            this.linkLabel3.Text = "查看更新";
            this.linkLabel3.Click += new System.EventHandler(this.linkLabel3_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(120, 21);
            this.toolStripStatusLabel1.Text = "作者：Dorami2k";
            // 
            // aboutLabel
            // 
            this.aboutLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.aboutLabel.IsLink = true;
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(66, 21);
            this.aboutLabel.Text = "关于&&捐赠";
            this.aboutLabel.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Modifier.Properties.Resources._2kLOGO;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(821, 637);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameModifier";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel moduleStausLabel;
        private System.Windows.Forms.ToolStripStatusLabel currentStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel versionLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridView;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripStatusLabel linkLabel1;
        private System.Windows.Forms.ToolStripStatusLabel linkLabel2;
        private System.Windows.Forms.ToolStripStatusLabel linkLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel aboutLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 全部最大值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部最小值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部设定值ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorText;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

