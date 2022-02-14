using CircleGameCommonService;
using CircleGameConfig;
using CircleGameModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleGame
{
    public partial class MainFrm : Form
    {
        private delegate void UpdateUI(InviterPriceInput inviterPriceInput);
        private UpdateUI updateUI;
        private IExcelService excelService = new ExcelService();
        private string excelPath = AppDomain.CurrentDomain.BaseDirectory;

        private delegate void CompleteCallBack();
        private CompleteCallBack completeCallBack;

        private Dictionary<String, List<MyInviteDetail>> copartnerDic = new Dictionary<string, List<MyInviteDetail>>();

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now.Date.AddDays(-1);
            updateUI += UpdateUIProcess;
            completeCallBack += CompletedCallBackProcess;
            progressBar.Visible = false;
            Config.SetSelectedDateTime(dateTimePicker.Value.ToString("yyyy-MM-dd"));
            //加载合伙人信息
            LoadCopartner();
        }

        /// <summary>
        /// 加载合伙人信息
        /// </summary>
        private void LoadCopartner()
        {
            CopartnerView copartnerView = new CopartnerView();
            List<Copartner> copartners = copartnerView.GetCopartners();
            if (copartners == null) { return; }
            for (int index = 0; index < copartners.Count; index++)
            {
                Copartner copartner = copartners[index];
                int currentRowIndex = dgvCopartner.Rows.Add();
                DataGridViewRow row = dgvCopartner.Rows[currentRowIndex];
                row.Cells["copartnerID"].Value = copartner.Inviter_uid;
                row.Cells["copartnerName"].Value = copartner.Inviter_nickname;
                row.Cells["UnitPrice"].Value = Config.GetUnitPrice();
                row.Cells["DoubleUnitPrice"].Value = Config.GetDoubleUnitPrice();
                row.Cells["TotalPrice"].Value = 0;
            }
        }

        /// <summary>
        /// 获取到合伙人对应的总收费
        /// </summary>
        /// <param name="copartnerID"></param>
        /// <param name="unitPrice"></param>
        /// <param name="doubleUnitPrice"></param>
        /// <returns></returns>
        private double GetTotalPrice(String copartnerID, String unitPrice, String doubleUnitPrice)
        {
            double totalPrice = 0;
            double unitP = double.Parse(unitPrice);
            double doubleP = double.Parse(doubleUnitPrice);
            MyInviteDetailView myInviteDetailView = new MyInviteDetailView();
            List<MyInviteDetail> myInviteDetails = myInviteDetailView.GetMyInviteDetails(copartnerID);
            if (myInviteDetails == null) { return totalPrice; }
            if (copartnerDic.ContainsKey(copartnerID))
            {
                copartnerDic[copartnerID] = myInviteDetails;
            }
            else
            {
                copartnerDic.Add(copartnerID, myInviteDetails);
            }
            for (int index = 0; index < myInviteDetails.Count; index++)
            {
                MyInviteDetail myInviteDetail = myInviteDetails[index];
                myInviteDetail.CopartnerID = copartnerID;
                List<CircleWinnerRecord> circleWinnerRecords = GetCircleWinnerRecords(copartnerID, myInviteDetail.User_id);
                if (circleWinnerRecords == null)
                {
                    continue;
                }
                double everyInvitePrice = myInviteDetail.GetInvitePrice(circleWinnerRecords, unitP, doubleP);
                totalPrice += everyInvitePrice;
            }

            return totalPrice;
        }

        /// <summary>
        /// 获取到被邀请人牌局信息
        /// </summary>
        /// <param name="copartnerID"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<CircleWinnerRecord> GetCircleWinnerRecords(String copartnerID, String userId)
        {
            CircleWinnerRecordView circleWinnerRecordView = new CircleWinnerRecordView();
            List<CircleWinnerRecord> circleWinnerRecords = circleWinnerRecordView.GetWinnerRecords(copartnerID, userId);
            return circleWinnerRecords;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Task[] tasks = new Task[dgvCopartner.Rows.Count];
            progressBar.Visible = true;
            progressBar.Show();
            progressBar.Value = 0;
            progressBar.Step = 100 / dgvCopartner.Rows.Count;
            Config.SetSelectedDateTime(dateTimePicker.Value.ToString("yyyy-MM-dd"));
            lbl.Text = "正在进行费用统计，请稍等...";

            for (int rowIndex = 0; rowIndex < dgvCopartner.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = dgvCopartner.Rows[rowIndex];
                String inviter_uid = row.Cells["copartnerID"].Value.ToString();
                String unitPrice = row.Cells["UnitPrice"].Value.ToString();
                String doubleUnitPrice = row.Cells["DoubleUnitPrice"].Value.ToString();
                row.Cells["TotalPrice"].Value = 0;
                InviterPriceInput inviterPriceInput = new InviterPriceInput();
                inviterPriceInput.RowIndex = rowIndex;
                inviterPriceInput.Inviter_uid = inviter_uid;
                inviterPriceInput.UnitPrice = unitPrice;
                inviterPriceInput.DoublePrice = doubleUnitPrice;
                Action<object> action = new Action<object>(CalculationCopartnerTotalPrice);
                Task task = new Task(action, inviterPriceInput);
                task.Start();
                tasks[rowIndex] = task;
            }

            Task resultTask = Task.WhenAll(tasks);
            Task continueTask = resultTask.ContinueWith(TaskCompletedCallBack);
        }

        /// <summary>
        /// 计算每一个合伙人的费用
        /// </summary>
        /// <param name="input"></param>
        private void CalculationCopartnerTotalPrice(object input)
        {
            if (input is InviterPriceInput)
            {
                InviterPriceInput inviterPriceInput = input as InviterPriceInput;

                double totalPrice = GetTotalPrice(inviterPriceInput.Inviter_uid, inviterPriceInput.UnitPrice, inviterPriceInput.DoublePrice);
                inviterPriceInput.TotalPrice = totalPrice;
                this.Invoke(updateUI, inviterPriceInput);
            }
        }

        /// <summary>
        /// 更新UI
        /// </summary>
        /// <param name="inviterPriceInput"></param>
        private void UpdateUIProcess(InviterPriceInput inviterPriceInput)
        {
            DataGridViewRow row = dgvCopartner.Rows[inviterPriceInput.RowIndex];
            row.Cells["TotalPrice"].Value = inviterPriceInput.TotalPrice;
            progressBar.PerformStep();
        }

        /// <summary>
        /// 所有任务完成产生回调
        /// </summary>
        private void TaskCompletedCallBack(Task task)
        {
            this.Invoke(completeCallBack);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CompletedCallBackProcess()
        {
            progressBar.Visible = false;
            lbl.Text = "费用统计完成...";
        }

        private void dgvCopartner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击的是总费用
            if (sender is DataGridView && e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DataGridView dataGridView = sender as DataGridView;
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                String inviter_uid = row.Cells["copartnerID"].Value.ToString();
                String copartnerName = row.Cells["copartnerName"].Value.ToString();
                String unitPrice = row.Cells["UnitPrice"].Value.ToString();
                String doubleUnitPrice = row.Cells["DoubleUnitPrice"].Value.ToString();

                List<MyInviteDetail> myInviteDetails = new List<MyInviteDetail>();
                if (copartnerDic.ContainsKey(inviter_uid))
                {
                    myInviteDetails = copartnerDic[inviter_uid];
                }
                InviterFrm inviterFrm = new InviterFrm(inviter_uid, copartnerName, myInviteDetails);
                DialogResult dialogResult = inviterFrm.ShowDialog();
            }
        }

        private void btnExportCopartner_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCopartner != null && dgvCopartner.Rows.Count > 0)
                {
                    DataTable dataTable = new DataTable();
                    for (int columnIndex = 0; columnIndex < dgvCopartner.Columns.Count; columnIndex++)
                    {
                        dataTable.Columns.Add(dgvCopartner.Columns[columnIndex].HeaderText);
                    }

                    for (int rowIndex = 0; rowIndex < dgvCopartner.Rows.Count; rowIndex++)
                    {
                        DataGridViewRow row = dgvCopartner.Rows[rowIndex];
                        DataRow newRow = dataTable.Rows.Add();
                        for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                        {
                            newRow[cellIndex] = row.Cells[cellIndex].Value;
                        }
                    }

                    excelService.ExportExcel(excelPath + "\\" + Config.GetSelectedDateTime() + ".xlsx", "合伙人费用概要统计", dataTable);
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
