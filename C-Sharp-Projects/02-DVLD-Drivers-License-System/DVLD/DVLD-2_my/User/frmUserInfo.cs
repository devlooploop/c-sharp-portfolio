using System;
using System.Windows.Forms;


namespace DVLD_2_my.User
{
    public partial class frmUserInfo : Form
    {
        private int _userID;


        public frmUserInfo(int userID)
        {
            InitializeComponent();
            //  OnPere = frmUserInfo_Load(this, userID) // subscribe to the OnPersonSelected to retrive person Card Info
            _userID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(_userID);

        }

    }

}
