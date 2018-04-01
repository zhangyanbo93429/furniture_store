namespace WindowsFormsApp5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进货记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出货记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进出货操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.利润情况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.进货状况导出txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出txt出货状况ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 55);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1219, 307);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "出货";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(32, 383);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "进货";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(795, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "更改";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1051, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "查询\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "导入excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(580, 383);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "导出excel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.使用帮助ToolStripMenuItem,
            this.利润情况ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1291, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前库存ToolStripMenuItem,
            this.进货记录ToolStripMenuItem,
            this.出货记录ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.显示ToolStripMenuItem.Text = "查看信息";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 当前库存ToolStripMenuItem
            // 
            this.当前库存ToolStripMenuItem.Name = "当前库存ToolStripMenuItem";
            this.当前库存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.当前库存ToolStripMenuItem.Text = "当前库存";
            this.当前库存ToolStripMenuItem.Click += new System.EventHandler(this.当前库存ToolStripMenuItem_Click);
            // 
            // 进货记录ToolStripMenuItem
            // 
            this.进货记录ToolStripMenuItem.Name = "进货记录ToolStripMenuItem";
            this.进货记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.进货记录ToolStripMenuItem.Text = "进货记录";
            this.进货记录ToolStripMenuItem.Click += new System.EventHandler(this.进货记录ToolStripMenuItem_Click);
            // 
            // 出货记录ToolStripMenuItem
            // 
            this.出货记录ToolStripMenuItem.Name = "出货记录ToolStripMenuItem";
            this.出货记录ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.出货记录ToolStripMenuItem.Text = "出货记录";
            this.出货记录ToolStripMenuItem.Click += new System.EventHandler(this.出货记录ToolStripMenuItem_Click);
            // 
            // 使用帮助ToolStripMenuItem
            // 
            this.使用帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.进出货操作ToolStripMenuItem,
            this.出货ToolStripMenuItem,
            this.更改ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.导出txtToolStripMenuItem,
            this.进货状况导出txtToolStripMenuItem,
            this.导出txt出货状况ToolStripMenuItem});
            this.使用帮助ToolStripMenuItem.Name = "使用帮助ToolStripMenuItem";
            this.使用帮助ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.使用帮助ToolStripMenuItem.Text = "进出货操作";
            this.使用帮助ToolStripMenuItem.Click += new System.EventHandler(this.使用帮助ToolStripMenuItem_Click);
            // 
            // 进出货操作ToolStripMenuItem
            // 
            this.进出货操作ToolStripMenuItem.Name = "进出货操作ToolStripMenuItem";
            this.进出货操作ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.进出货操作ToolStripMenuItem.Text = "进货";
            this.进出货操作ToolStripMenuItem.Click += new System.EventHandler(this.进出货操作ToolStripMenuItem_Click);
            // 
            // 出货ToolStripMenuItem
            // 
            this.出货ToolStripMenuItem.Name = "出货ToolStripMenuItem";
            this.出货ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.出货ToolStripMenuItem.Text = "出货";
            this.出货ToolStripMenuItem.Click += new System.EventHandler(this.出货ToolStripMenuItem_Click);
            // 
            // 更改ToolStripMenuItem
            // 
            this.更改ToolStripMenuItem.Name = "更改ToolStripMenuItem";
            this.更改ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.更改ToolStripMenuItem.Text = "更改";
            this.更改ToolStripMenuItem.Click += new System.EventHandler(this.更改ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 导出txtToolStripMenuItem
            // 
            this.导出txtToolStripMenuItem.Name = "导出txtToolStripMenuItem";
            this.导出txtToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.导出txtToolStripMenuItem.Text = "导出txt（库存状况）";
            this.导出txtToolStripMenuItem.Click += new System.EventHandler(this.导出txtToolStripMenuItem_Click);
            // 
            // 利润情况ToolStripMenuItem
            // 
            this.利润情况ToolStripMenuItem.Name = "利润情况ToolStripMenuItem";
            this.利润情况ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.利润情况ToolStripMenuItem.Text = "利润情况";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(509, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // 进货状况导出txtToolStripMenuItem
            // 
            this.进货状况导出txtToolStripMenuItem.Name = "进货状况导出txtToolStripMenuItem";
            this.进货状况导出txtToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.进货状况导出txtToolStripMenuItem.Text = "导出txt（进货状况）";
            this.进货状况导出txtToolStripMenuItem.Click += new System.EventHandler(this.进货状况导出txtToolStripMenuItem_Click);
            // 
            // 导出txt出货状况ToolStripMenuItem
            // 
            this.导出txt出货状况ToolStripMenuItem.Name = "导出txt出货状况ToolStripMenuItem";
            this.导出txt出货状况ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.导出txt出货状况ToolStripMenuItem.Text = "导出txt（出货状况）";
            this.导出txt出货状况ToolStripMenuItem.Click += new System.EventHandler(this.导出txt出货状况ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 524);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进货记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出货记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 使用帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 利润情况ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 进出货操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出货ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进货状况导出txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出txt出货状况ToolStripMenuItem;
    }
}

