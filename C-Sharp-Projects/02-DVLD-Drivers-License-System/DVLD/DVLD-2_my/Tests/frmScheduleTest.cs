using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;



namespace DVLD_2_my.Tests
{
    public partial class frmScheduleTest : Form
    {
        //int _localDrivingLicenseApplicationID = -1;

        public frmScheduleTest()
        {
            InitializeComponent();
        }

        public frmScheduleTest(int localDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
        }
        

        /* make schedule test at this point ... enum and switch on the 3-tets(vision, street & written)
         * then let the switch-on statment chose witch (pic-box to show + related info).
         * .... later at this point!
         */ 
    }
}
