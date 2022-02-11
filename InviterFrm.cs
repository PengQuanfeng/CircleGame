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
    }
}
