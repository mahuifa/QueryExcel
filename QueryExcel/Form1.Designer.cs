namespace QueryExcel
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox_input = new System.Windows.Forms.RichTextBox();
            this.comb_mode = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.查询模式 = new System.Windows.Forms.Label();
            this.but_Clear = new System.Windows.Forms.Button();
            this.but_query = new System.Windows.Forms.Button();
            this.but_select = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(315, 482);
            this.treeView1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.treeView1, "添加的文件！");
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(317, 482);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.toolTip1.SetToolTip(this.richTextBox1, "显示查询的结果！");
            // 
            // richTextBox_input
            // 
            this.richTextBox_input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_input.Location = new System.Drawing.Point(2, 5);
            this.richTextBox_input.Name = "richTextBox_input";
            this.richTextBox_input.Size = new System.Drawing.Size(240, 382);
            this.richTextBox_input.TabIndex = 0;
            this.richTextBox_input.Text = "";
            this.toolTip1.SetToolTip(this.richTextBox_input, "输入需要查询的信息！");
            // 
            // comb_mode
            // 
            this.comb_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comb_mode.FormattingEnabled = true;
            this.comb_mode.Items.AddRange(new object[] {
            "所有文件",
            "同级路径文件",
            "选中文件"});
            this.comb_mode.Location = new System.Drawing.Point(107, 393);
            this.comb_mode.Name = "comb_mode";
            this.comb_mode.Size = new System.Drawing.Size(109, 22);
            this.comb_mode.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comb_mode, "所有文件：查询当前文件夹及子文件夹下的所有文件。\r\n同级路径文件：只查询当前文件夹内文件，不查询子文件夹下文件。\r\n选中文件：查询文件树中选中的文件。");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(2, 48);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.查询模式);
            this.splitContainer2.Panel2.Controls.Add(this.but_Clear);
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox_input);
            this.splitContainer2.Panel2.Controls.Add(this.but_query);
            this.splitContainer2.Panel2.Controls.Add(this.but_select);
            this.splitContainer2.Panel2.Controls.Add(this.comb_mode);
            this.splitContainer2.Size = new System.Drawing.Size(887, 482);
            this.splitContainer2.SplitterDistance = 636;
            this.splitContainer2.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(636, 482);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 2;
            // 
            // 查询模式
            // 
            this.查询模式.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.查询模式.AutoSize = true;
            this.查询模式.Location = new System.Drawing.Point(24, 396);
            this.查询模式.Name = "查询模式";
            this.查询模式.Size = new System.Drawing.Size(77, 14);
            this.查询模式.TabIndex = 5;
            this.查询模式.Text = "查询模式：";
            // 
            // but_Clear
            // 
            this.but_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_Clear.Location = new System.Drawing.Point(170, 437);
            this.but_Clear.Name = "but_Clear";
            this.but_Clear.Size = new System.Drawing.Size(75, 23);
            this.but_Clear.TabIndex = 4;
            this.but_Clear.Text = "清空";
            this.but_Clear.UseVisualStyleBackColor = true;
            this.but_Clear.Click += new System.EventHandler(this.but_Clear_Click);
            // 
            // but_query
            // 
            this.but_query.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_query.Location = new System.Drawing.Point(89, 437);
            this.but_query.Name = "but_query";
            this.but_query.Size = new System.Drawing.Size(75, 23);
            this.but_query.TabIndex = 3;
            this.but_query.Text = "查询";
            this.but_query.UseVisualStyleBackColor = true;
            this.but_query.Click += new System.EventHandler(this.but_query_Click);
            // 
            // but_select
            // 
            this.but_select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_select.Location = new System.Drawing.Point(8, 437);
            this.but_select.Name = "but_select";
            this.but_select.Size = new System.Drawing.Size(75, 23);
            this.but_select.TabIndex = 1;
            this.but_select.Text = "选择文件";
            this.but_select.UseVisualStyleBackColor = true;
            this.but_select.Click += new System.EventHandler(this.but_select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 533);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowFormShadow = true;
            this.Text = "Excel查询工具";
            this.TitleBarColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.SetChildIndex(this.splitContainer2, 0);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label 查询模式;
        private System.Windows.Forms.Button but_Clear;
        private System.Windows.Forms.RichTextBox richTextBox_input;
        private System.Windows.Forms.Button but_query;
        private System.Windows.Forms.Button but_select;
        private System.Windows.Forms.ComboBox comb_mode;
    }
}

