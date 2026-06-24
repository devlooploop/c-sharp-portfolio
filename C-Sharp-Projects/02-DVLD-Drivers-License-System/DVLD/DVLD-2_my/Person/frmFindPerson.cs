using System;
using System.Windows.Forms;

namespace DVLD_2_my.Person
{
    public partial class frmFindPerson : Form
    {

        public delegate void PersonEventHandler(object sender, int personID);
        public event PersonEventHandler PersonDataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }


        protected virtual void PersenSelected(object sender, int personID)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PersonDataBack != null)
            {
                PersonDataBack.Invoke(this, personDetailsWithFilter_uc2.PersonID);
            }

            Close();
        }
    }
}
