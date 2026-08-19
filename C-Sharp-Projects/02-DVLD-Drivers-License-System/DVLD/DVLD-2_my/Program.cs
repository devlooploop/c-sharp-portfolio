using DVLD_2_my.Applications;
using System;
using System.Windows.Forms;


namespace DVLD_2_my
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMainMenu());
            //Application.Run(new frmLogin());
            //Application.Run(new frmManageUsers());
            //Application.Run(new frmTestTest());
            // Application.Run(new frmFindPerson());
            //Application.Run(new frmPersonDetails());
            //Application.Run(new frmManagePeople());
            // Application.Run(new frmManageUsers());
            // Application.Run(new frmManageApplicationTypes());
             Application.Run(new frmListLocalDrivingLicenseApplications());
        }
    }
}
