namespace DVLD_2_my.Tests
{
    partial class frmListTestAppointments
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
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(183, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "Vision Test Appointments";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_2_my.Properties.Resources.Vision_512;
            this.pictureBox1.Location = new System.Drawing.Point(334, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // txtVisionTestAppointment
            // 
            this.txtVisionTestAppointment.Location = new System.Drawing.Point(11, 463);
            this.txtVisionTestAppointment.Multiline = true;
            this.txtVisionTestAppointment.Name = "txtVisionTestAppointment";
            this.txtVisionTestAppointment.Size = new System.Drawing.Size(732, 129);
            this.txtVisionTestAppointment.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 437);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Appointments:";
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddNewAppointment.Image = global::DVLD_2_my.Properties.Resources.Add_Appointment_32;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(703, 429);
            this.btnAddNewAppointment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(39, 27);
            this.btnAddNewAppointment.TabIndex = 48;
            this.btnAddNewAppointment.UseVisualStyleBackColor = false;
            this.btnAddNewAppointment.Click += new System.EventHandler(this.btnAddNewAppointment_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.Image = global::DVLD_2_my.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(579, 607);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 39);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordCount.Location = new System.Drawing.Point(111, 607);
            this.lblRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(39, 20);
            this.lblRecordCount.TabIndex = 53;
            this.lblRecordCount.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 607);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "# Records:";
            // 
            // ctrDrivingLicenseApplicationInfo1
            // 
            this.ctrDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(11, 132);
            this.ctrDrivingLicenseApplicationInfo1.Name = "ctrDrivingLicenseApplicationInfo1";
            this.ctrDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(745, 291);
            this.ctrDrivingLicenseApplicationInfo1.TabIndex = 54;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 656);
            this.Controls.Add(this.ctrDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVisionTestAppointment);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestAppointments";
            this.Text = "Vision Test Appointment";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo3;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.TextBox txtVisionTestAppointment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label label2;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo2;
    }
}