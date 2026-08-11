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



namespace DVLD_2_my.Applications.Controls
{

    public partial class ctrlApplicationBasicInfo : UserControl
    {

        private clsApplication _application;
        private int _applicationId;

        public int ApplicationID 
        { 
            get { return _applicationId; } 
        }
       

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public ctrlApplicationBasicInfo(int applicationId)
        {
            InitializeComponent();

        }

        
    }
}
