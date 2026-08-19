namespace DVLD_2_my.Tests
{
    partial class frmVisionTestAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtVisionTestAppointment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddVisionTestAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrDrivingLicenseApplicationInfo3 = new DVLD_2_my.Applications.Controls.ctrDrivingLicenseApplicationInfo();
            this.ctrDrivingLicenseApplicationInfo2 = new DVLD_2_my.Applications.Controls.ctrDrivingLicenseApplicationInfo();
            this.ctrDrivingLicenseApplicationInfo1 = new DVLD_2_my.Applications.Controls.ctrDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(274, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 55);
            this.label1.TabIndex = 25;
            this.label1.Text = "Vision Test Appointments";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_2_my.Properties.Resources.Vision_512;
            this.pictureBox1.Location = new System.Drawing.Point(501, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // txtVisionTestAppointment
            // 
            this.txtVisionTestAppointment.Location = new System.Drawing.Point(17, 712);
            this.txtVisionTestAppointment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVisionTestAppointment.Multiline = true;
            this.txtVisionTestAppointment.Name = "txtVisionTestAppointment";
            this.txtVisionTestAppointment.Size = new System.Drawing.Size(1096, 196);
            this.txtVisionTestAppointment.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 29);
            this.label4.TabIndex = 47;
            this.label4.Text = "Appointments:";
            // 
            // btnAddVisionTestAppointment
            // 
            this.btnAddVisionTestAppointment.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddVisionTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVisionTestAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddVisionTestAppointment.Image = global::DVLD_2_my.Properties.Resources.Add_Appointment_32;
            this.btnAddVisionTestAppointment.Location = new System.Drawing.Point(1055, 660);
            this.btnAddVisionTestAppointment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddVisionTestAppointment.Name = "btnAddVisionTestAppointment";
            this.btnAddVisionTestAppointment.Size = new System.Drawing.Size(58, 42);
            this.btnAddVisionTestAppointment.TabIndex = 48;
            this.btnAddVisionTestAppointment.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.Image = global::DVLD_2_my.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(869, 934);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(202, 60);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordCount.Location = new System.Drawing.Point(166, 934);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(52, 29);
            this.lblRecordCount.TabIndex = 53;
            this.lblRecordCount.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 934);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 52;
            this.label2.Text = "# Records:";
            // 
            // ctrDrivingLicenseApplicationInfo3
            // 
            this.ctrDrivingLicenseApplicationInfo3.Location = new System.Drawing.Point(13, 203);
            this.ctrDrivingLicenseApplicationInfo3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDrivingLicenseApplicationInfo3.Name = "ctrDrivingLicenseApplicationInfo3";
            this.ctrDrivingLicenseApplicationInfo3.Size = new System.Drawing.Size(1118, 453);
            this.ctrDrivingLicenseApplicationInfo3.TabIndex = 54;
            // 
            // ctrDrivingLicenseApplicationInfo2
            // 
            this.ctrDrivingLicenseApplicationInfo2.Location = new System.Drawing.Point(13, 203);
            this.ctrDrivingLicenseApplicationInfo2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDrivingLicenseApplicationInfo2.Name = "ctrDrivingLicenseApplicationInfo2";
            this.ctrDrivingLicenseApplicationInfo2.Size = new System.Drawing.Size(1118, 447);
            this.ctrDrivingLicenseApplicationInfo2.TabIndex = 54;
            // 
            // ctrDrivingLicenseApplicationInfo1
            // 
            this.ctrDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 152);
            this.ctrDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrDrivingLicenseApplicationInfo1.Name = "ctrDrivingLicenseApplicationInfo1";
            this.ctrDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(755, 359);
            this.ctrDrivingLicenseApplicationInfo1.TabIndex = 45;
            // 
            // frmVisionTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 1010);
            this.Controls.Add(this.ctrDrivingLicenseApplicationInfo3);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddVisionTestAppointment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVisionTestAppointment);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmVisionTestAppointment";
            this.Text = "frmVisionTestAppointment";
            this.Load += new System.EventHandler(this.frmVisionTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.TextBox txtVisionTestAppointment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddVisionTestAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo2;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo3;
    }
}