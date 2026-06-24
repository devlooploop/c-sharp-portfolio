using System;
using System.Windows.Forms;

namespace DVLD_2_my
{
    public partial class frmPersonDetails : Form
    {

        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            personDetails_uc1.LoadPersonInfo(personID);
        }

        public frmPersonDetails(string nationalNumber)
        {
            InitializeComponent();
            personDetails_uc1.LoadPersonInfo(nationalNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
