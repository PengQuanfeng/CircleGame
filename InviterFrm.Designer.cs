
namespace CircleGame
{
    partial class InviterFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCopartnerId = new System.Windows.Forms.Label();
            this.lblCopartnerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInviter = new System.Windows.Forms.DataGridView();
            this.User_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nickname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Round = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count1Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoPerson_Win_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TwoPersonPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count1ForFourPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count1PriceForFourPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count2Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Win_count3Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportInviter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInviter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "合伙人标识:";
            // 
            // lblCopartnerId
            // 
            this.lblCopartnerId.AutoSize = true;
            this.lblCopartnerId.ForeColor = System.Drawing.Color.Red;
            this.lblCopartnerId.Location = new System.Drawing.Point(175, 9);
            this.lblCopartnerId.Name = "lblCopartnerId";
            this.lblCopartnerId.Size = new System.Drawing.Size(119, 15);
            this.lblCopartnerId.TabIndex = 1;
            this.lblCopartnerId.Text = "lblCopartnerId";
            // 
            // lblCopartnerName
            // 
            this.lblCopartnerName.AutoSize = true;
            this.lblCopartnerName.ForeColor = System.Drawing.Color.Red;
            this.lblCopartnerName.Location = new System.Drawing.Point(434, 9);
            this.lblCopartnerName.Name = "lblCopartnerName";
            this.lblCopartnerName.Size = new System.Drawing.Size(135, 15);
            this.lblCopartnerName.TabIndex = 3;
            this.lblCopartnerName.Text = "lblCopartnerName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(329, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "合伙人名称:";
            // 
            // dgvInviter
            // 
            this.dgvInviter.AllowUserToAddRows = false;
            this.dgvInviter.AllowUserToDeleteRows = false;
            this.dgvInviter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInviter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_id,
            this.Nickname,
            this.Round,
            this.Win_count,
            this.Win_count1,
            this.Win_count1Price,
            this.TwoPerson_Win_count,
            this.TwoPersonPrice,
            this.Win_count1ForFourPerson,
            this.Win_count1PriceForFourPerson,
            this.Win_count2,
            this.Win_count2Price,
            this.Win_count3,
            this.Win_count3Price,
            this.Price});
            this.dgvInviter.Location = new System.Drawing.Point(12, 45);
            this.dgvInviter.Name = "dgvInviter";
            this.dgvInviter.ReadOnly = true;
            this.dgvInviter.RowHeadersWidth = 51;
            this.dgvInviter.RowTemplate.Height = 27;
            this.dgvInviter.Size = new System.Drawing.Size(2161, 790);
            this.dgvInviter.TabIndex = 4;
            // 
            // User_id
            // 
            this.User_id.DataPropertyName = "User_id";
            this.User_id.HeaderText = "受邀人标识";
            this.User_id.MinimumWidth = 6;
            this.User_id.Name = "User_id";
            this.User_id.ReadOnly = true;
            this.User_id.Width = 90;
            // 
            // Nickname
            // 
            this.Nickname.DataPropertyName = "Nickname";
            this.Nickname.HeaderText = "受邀人名称";
            this.Nickname.MinimumWidth = 6;
            this.Nickname.Name = "Nickname";
            this.Nickname.ReadOnly = true;
            this.Nickname.Width = 90;
            // 
            // Round
            // 
            this.Round.DataPropertyName = "Round";
            this.Round.HeaderText = "牌局数";
            this.Round.MinimumWidth = 6;
            this.Round.Name = "Round";
            this.Round.ReadOnly = true;
            this.Round.Width = 70;
            // 
            // Win_count
            // 
            this.Win_count.DataPropertyName = "Win_count";
            this.Win_count.HeaderText = "最大赢家次数";
            this.Win_count.MinimumWidth = 6;
            this.Win_count.Name = "Win_count";
            this.Win_count.ReadOnly = true;
            this.Win_count.Width = 110;
            // 
            // Win_count1
            // 
            this.Win_count1.DataPropertyName = "Win_count1";
            this.Win_count1.HeaderText = "单赢家次数";
            this.Win_count1.MinimumWidth = 6;
            this.Win_count1.Name = "Win_count1";
            this.Win_count1.ReadOnly = true;
            this.Win_count1.Width = 90;
            // 
            // Win_count1Price
            // 
            this.Win_count1Price.DataPropertyName = "Win_count1Price";
            this.Win_count1Price.HeaderText = "单赢家费用";
            this.Win_count1Price.MinimumWidth = 6;
            this.Win_count1Price.Name = "Win_count1Price";
            this.Win_count1Price.ReadOnly = true;
            this.Win_count1Price.Width = 90;
            // 
            // TwoPerson_Win_count
            // 
            this.TwoPerson_Win_count.DataPropertyName = "TwoPerson_Win_count";
            this.TwoPerson_Win_count.HeaderText = "单盈家次数(两人)";
            this.TwoPerson_Win_count.MinimumWidth = 6;
            this.TwoPerson_Win_count.Name = "TwoPerson_Win_count";
            this.TwoPerson_Win_count.ReadOnly = true;
            this.TwoPerson_Win_count.Width = 140;
            // 
            // TwoPersonPrice
            // 
            this.TwoPersonPrice.DataPropertyName = "TwoPersonPrice";
            this.TwoPersonPrice.HeaderText = "单盈家费用(两人)";
            this.TwoPersonPrice.MinimumWidth = 6;
            this.TwoPersonPrice.Name = "TwoPersonPrice";
            this.TwoPersonPrice.ReadOnly = true;
            this.TwoPersonPrice.Width = 140;
            // 
            // Win_count1ForFourPerson
            // 
            this.Win_count1ForFourPerson.DataPropertyName = "Win_count1ForFourPerson";
            this.Win_count1ForFourPerson.HeaderText = "单盈家次数(四人)";
            this.Win_count1ForFourPerson.MinimumWidth = 6;
            this.Win_count1ForFourPerson.Name = "Win_count1ForFourPerson";
            this.Win_count1ForFourPerson.ReadOnly = true;
            this.Win_count1ForFourPerson.Width = 140;
            // 
            // Win_count1PriceForFourPerson
            // 
            this.Win_count1PriceForFourPerson.DataPropertyName = "Win_count1PriceForFourPerson";
            this.Win_count1PriceForFourPerson.HeaderText = "单盈家费用(四人)";
            this.Win_count1PriceForFourPerson.MinimumWidth = 6;
            this.Win_count1PriceForFourPerson.Name = "Win_count1PriceForFourPerson";
            this.Win_count1PriceForFourPerson.ReadOnly = true;
            this.Win_count1PriceForFourPerson.Width = 140;
            // 
            // Win_count2
            // 
            this.Win_count2.DataPropertyName = "Win_count2";
            this.Win_count2.HeaderText = "双赢家次数";
            this.Win_count2.MinimumWidth = 6;
            this.Win_count2.Name = "Win_count2";
            this.Win_count2.ReadOnly = true;
            this.Win_count2.Width = 90;
            // 
            // Win_count2Price
            // 
            this.Win_count2Price.DataPropertyName = "Win_count2Price";
            this.Win_count2Price.HeaderText = "双赢家费用";
            this.Win_count2Price.MinimumWidth = 6;
            this.Win_count2Price.Name = "Win_count2Price";
            this.Win_count2Price.ReadOnly = true;
            this.Win_count2Price.Width = 90;
            // 
            // Win_count3
            // 
            this.Win_count3.DataPropertyName = "Win_count3";
            this.Win_count3.HeaderText = "三赢家次数";
            this.Win_count3.MinimumWidth = 6;
            this.Win_count3.Name = "Win_count3";
            this.Win_count3.ReadOnly = true;
            this.Win_count3.Width = 90;
            // 
            // Win_count3Price
            // 
            this.Win_count3Price.DataPropertyName = "Win_count3Price";
            this.Win_count3Price.HeaderText = "三赢家费用";
            this.Win_count3Price.MinimumWidth = 6;
            this.Win_count3Price.Name = "Win_count3Price";
            this.Win_count3Price.ReadOnly = true;
            this.Win_count3Price.Width = 90;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "EveryInvitePrice";
            this.Price.HeaderText = "总费用";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // btnExportInviter
            // 
            this.btnExportInviter.Location = new System.Drawing.Point(682, 0);
            this.btnExportInviter.Name = "btnExportInviter";
            this.btnExportInviter.Size = new System.Drawing.Size(95, 33);
            this.btnExportInviter.TabIndex = 6;
            this.btnExportInviter.Text = "导出Excel";
            this.btnExportInviter.UseVisualStyleBackColor = true;
            this.btnExportInviter.Click += new System.EventHandler(this.btnExportInviter_Click);
            // 
            // InviterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2180, 840);
            this.Controls.Add(this.btnExportInviter);
            this.Controls.Add(this.dgvInviter);
            this.Controls.Add(this.lblCopartnerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCopartnerId);
            this.Controls.Add(this.label1);
            this.Name = "InviterFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "受邀人费用列表";
            this.Load += new System.EventHandler(this.inviterFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInviter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCopartnerId;
        private System.Windows.Forms.Label lblCopartnerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInviter;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nickname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Round;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count1Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoPerson_Win_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn TwoPersonPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count1ForFourPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count1PriceForFourPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count2Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Win_count3Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Button btnExportInviter;
    }
}