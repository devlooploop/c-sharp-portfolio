using Business;
using System.Windows.Forms;


namespace DVLD_2_my.User
{
    public partial class ctrUserCard : UserControl
    {

        private clsUser _user;
        private int _userID = -1;

        public int UserID
        {
            get { return _userID; }
        }

        public ctrUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserValues()
        {
            personDetails_uc1.ResetPersonInfo();

            lblUserNameValue.Text = "???";
            lblUserIDValue.Text = "???";
            lblIsActiveValue.Text = "???";
        }

        public void LoadUserInfo(int userID)
        {
            _userID = userID;
            _user = clsUser.FindByUserID(userID);

            if (_user == null)
            {
                _ResetUserValues();

                MessageBox.Show($"No User Found with User ID: {userID}", "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillInfo();

        }

        private void _FillInfo()
        {

            personDetails_uc1.LoadPersonInfo(_user.PersonID);

            lblUserIDValue.Text = _user.UserID.ToString();
            lblUserNameValue.Text = _user.UserName.ToString();

            if (_user.IsActive)
                lblIsActiveValue.Text = "Yes";
            else
                lblIsActiveValue.Text = "No";
        }


    }


}
