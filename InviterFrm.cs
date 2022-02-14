using CircleGameCommonService;
using CircleGameConfig;
using CircleGameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleGame
{
    public partial class InviterFrm : Form
    {
        private String copartnerId;
        private String copartnerName;
        private List<MyInviteDetail> myInviteDetails;
        private IExcelService excelService = new ExcelService();
        private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

        public InviterFrm()
        {
            InitializeComponent();
        }

        public InviterFrm(String inviter_uid, String copartnerName, List<MyInviteDetail> myInviteDetails) : this()
        {
            this.copartnerId = inviter_uid;
            this.copartnerName = copartnerName;
            this.myInviteDetails = myInviteDetails;
        }

        private void inviterFrm_Load(object sender, EventArgs e)
        {
            dgvInviter.AutoGenerateColumns = false;
            lblCopartnerId.Text = copartnerId;
            lblCopartnerName.Text = copartnerName;
            List<MyInviteDetail> inviteDetails = myInviteDetails.FindAll(i => i.EveryInvitePrice > 0.1);
            dgvInviter.DataSource = inviteDetails;
        }

        private void btnExportInviter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInviter != null && dgvInviter.Rows.Count > 0)
                {
                    DataTable dataTable = new DataTable();
                    for (int columnIndex = 0; columnIndex < dgvInviter.Columns.Count; columnIndex++)
                    {
                        dataTable.Columns.Add(dgvInviter.Columns[columnIndex].HeaderText);
                    }

                    for (int rowIndex = 0; rowIndex < dgvInviter.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow row = dgvInviter.Rows[rowIndex];
                        object[] cellValues = new object[row.Cells.Count];
                        for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                        {
                            cellValues[cellIndex] = row.Cells[cellIndex].Value;
                        }
                        dataTable.Rows.Add(cellValues);
                    }

                    excelService.ExportExcel(excelPath + "\\" + Config.GetSelectedDateTime() + ".xlsx", lblCopartnerName.Text + "费用详情统计", dataTable);
                    MessageBox.Show("导出成功");
                }
            }
            catch (Exception ex)
            {
                Log4Helper.Error(this.GetType(), ex.Message);
                MessageBox.Show("导出Excel文件出错，请确保文件没被打开");
            }
        }
    }
}
