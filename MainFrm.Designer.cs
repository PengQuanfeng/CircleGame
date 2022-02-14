
namespace CircleGame
{
    partial class MainFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabContrl = new System.Windows.Forms.TabControl();
            this.copartnerPage = new System.Windows.Forms.TabPage();
            this.btnExportCopartner = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dgvCopartner = new System.Windows.Forms.DataGridView();
            this.copartnerID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.copartnerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoubleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabContrl.SuspendLayout();
            this.copartnerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopartner)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContrl
            // 
            this.tabContrl.Controls.Add(this.copartnerPage);
            this.tabContrl.Location = new System.Drawing.Point(12, 12);
            this.tabContrl.Name = "tabContrl";
            this.tabContrl.SelectedIndex = 0;
            this.tabContrl.Size = new System.Drawing.Size(1033, 590);
            this.tabContrl.TabIndex = 0;
            // 
            // copartnerPage
            // 
            this.copartnerPage.Controls.Add(this.btnExportCopartner);
            this.copartnerPage.Controls.Add(this.lbl);
            this.copartnerPage.Controls.Add(this.progressBar);
            this.copartnerPage.Controls.Add(this.btnConfirm);
            this.copartnerPage.Controls.Add(this.dateTimePicker);
            this.copartnerPage.Controls.Add(this.dgvCopartner);
            this.copartnerPage.Location = new System.Drawing.Point(4, 25);
            this.copartnerPage.Name = "copartnerPage";
            this.copartnerPage.Padding = new System.Windows.Forms.Padding(3);
            this.copartnerPage.Size = new System.Drawing.Size(1025, 561);
            this.copartnerPage.TabIndex = 0;
            this.copartnerPage.Text = "合伙人费用";
            this.copartnerPage.UseVisualStyleBackColor = true;
            // 
            // btnExportCopartner
            // 
            this.btnExportCopartner.Location = new System.Drawing.Point(365, 13);
            this.btnExportCopartner.Name = "btnExportCopartner";
            this.btnExportCopartner.Size = new System.Drawing.Size(95, 33);
            this.btnExportCopartner.TabIndex = 5;
            this.btnExportCopartner.Text = "导出Excel";
            this.btnExportCopartner.UseVisualStyleBackColor = true;
            this.btnExportCopartner.Click += new System.EventHandler(this.btnExportCopartner_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.Location = new System.Drawing.Point(491, 20);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 15);
            this.lbl.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 504);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1016, 50);
            this.progressBar.TabIndex = 3;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(239, 11);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 33);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "开始统计";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(16, 13);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 1;
            // 
            // dgvCopartner
            // 
            this.dgvCopartner.AllowUserToAddRows = false;
            this.dgvCopartner.AllowUserToDeleteRows = false;
            this.dgvCopartner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCopartner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCopartner.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.copartnerID,
            this.copartnerName,
            this.UnitPrice,
            this.DoubleUnitPrice,
            this.TotalPrice});
            this.dgvCopartner.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCopartner.Location = new System.Drawing.Point(6, 53);
            this.dgvCopartner.Name = "dgvCopartner";
            this.dgvCopartner.RowHeadersWidth = 51;
            this.dgvCopartner.RowTemplate.Height = 27;
            this.dgvCopartner.Size = new System.Drawing.Size(1023, 445);
            this.dgvCopartner.TabIndex = 0;
            this.dgvCopartner.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCopartner_CellContentClick);
            // 
            // copartnerID
            // 
            this.copartnerID.HeaderText = "合伙人标识";
            this.copartnerID.MinimumWidth = 6;
            this.copartnerID.Name = "copartnerID";
            this.copartnerID.Width = 125;
            // 
            // copartnerName
            // 
            this.copartnerName.HeaderText = "合伙人名称";
            this.copartnerName.MinimumWidth = 6;
            this.copartnerName.Name = "copartnerName";
            this.copartnerName.Width = 125;
            // 
            // UnitPrice
            // 
            dataGridViewCellStyle1.Format = "N2";
            this.UnitPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.UnitPrice.HeaderText = "两人局费用基数";
            this.UnitPrice.MinimumWidth = 6;
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UnitPrice.Width = 150;
            // 
            // DoubleUnitPrice
            // 
            this.DoubleUnitPrice.HeaderText = "四人局费用基数";
            this.DoubleUnitPrice.MinimumWidth = 6;
            this.DoubleUnitPrice.Name = "DoubleUnitPrice";
            this.DoubleUnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DoubleUnitPrice.Width = 150;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "总费用";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TotalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TotalPrice.Width = 125;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 605);
            this.Controls.Add(this.tabContrl);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "圈子游戏主界面";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.tabContrl.ResumeLayout(false);
            this.copartnerPage.ResumeLayout(false);
            this.copartnerPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopartner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContrl;
        private System.Windows.Forms.TabPage copartnerPage;
        private System.Windows.Forms.DataGridView dgvCopartner;
        private System.Windows.Forms.DataGridViewLinkColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoubleUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewLinkColumn copartnerName;
        private System.Windows.Forms.DataGridViewLinkColumn copartnerID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnExportCopartner;
    }
}

