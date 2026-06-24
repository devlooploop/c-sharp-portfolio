using System.Windows.Forms;

namespace DVLD_2_my
{
    public partial class frmTestTest : Form
    {
        enum enPageControlPerson : byte { ePersonInfo = 0, eApplicationInfo = 1 }

        public frmTestTest()
        {
            InitializeComponent();
        }

        private void personDetailsWithFilter_uc1_Load(object sender, System.EventArgs e)
        {

        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            tcPersonApplicationInfo.SelectedIndex = (byte)enPageControlPerson.eApplicationInfo;
        }
    }
}
