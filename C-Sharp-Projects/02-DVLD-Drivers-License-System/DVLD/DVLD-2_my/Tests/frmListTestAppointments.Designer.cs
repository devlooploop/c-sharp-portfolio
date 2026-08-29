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
            this.lbl_Title_frmListTestAppointments = new System.Windows.Forms.Label();
            this.pbListTestAppointments = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddNewAppointment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl_RecordCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLicenseTestAppointments = new System.Windows.Forms.DataGridView();
            this.ctrDrivingLicenseApplicationInfo1 = new DVLD_2_my.Applications.Controls.ctrDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbListTestAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Title_frmListTestAppointments
            // 
            this.lbl_Title_frmListTestAppointments.AutoSize = true;
            this.lbl_Title_frmListTestAppointments.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Title_frmListTestAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title_frmListTestAppointments.ForeColor = System.Drawing.Color.Red;
            this.lbl_Title_frmListTestAppointments.Location = new System.Drawing.Point(274, 143);
            this.lbl_Title_frmListTestAppointments.Name = "lbl_Title_frmListTestAppointments";
            this.lbl_Title_frmListTestAppointments.Size = new System.Drawing.Size(591, 55);
            this.lbl_Title_frmListTestAppointments.TabIndex = 25;
            this.lbl_Title_frmListTestAppointments.Text = "Vision Test Appointments";
            // 
            // pbListTestAppointments
            // 
            this.pbListTestAppointments.Image = global::DVLD_2_my.Properties.Resources.Vision_512;
            this.pbListTestAppointments.Location = new System.Drawing.Point(501, 18);
            this.pbListTestAppointments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbListTestAppointments.Name = "pbListTestAppointments";
            this.pbListTestAppointments.Size = new System.Drawing.Size(129, 120);
            this.pbListTestAppointments.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbListTestAppointments.TabIndex = 44;
            this.pbListTestAppointments.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 672);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 29);
            this.label4.TabIndex = 47;
            this.label4.Text = "Appointments:";
            // 
            // btnAddNewAppointment
            // 
            this.btnAddNewAppointment.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddNewAppointment.Image = global::DVLD_2_my.Properties.Resources.Add_Appointment_32;
            this.btnAddNewAppointment.Location = new System.Drawing.Point(1064, 659);
            this.btnAddNewAppointment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnAddNewAppointment.Name = "btnAddNewAppointment";
            this.btnAddNewAppointment.Size = new System.Drawing.Size(58, 42);
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
            this.btnClose.Location = new System.Drawing.Point(920, 935);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(202, 60);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lbl_RecordCount
            // 
            this.lbl_RecordCount.AutoSize = true;
            this.lbl_RecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_RecordCount.Location = new System.Drawing.Point(166, 934);
            this.lbl_RecordCount.Name = "lbl_RecordCount";
            this.lbl_RecordCount.Size = new System.Drawing.Size(52, 29);
            this.lbl_RecordCount.TabIndex = 53;
            this.lbl_RecordCount.Text = "???";
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
            // dgvLicenseTestAppointments
            // 
            this.dgvLicenseTestAppointments.AllowUserToAddRows = false;
            this.dgvLicenseTestAppointments.AllowUserToDeleteRows = false;
            this.dgvLicenseTestAppointments.AllowUserToResizeRows = false;
            this.dgvLicenseTestAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvLicenseTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLicenseTestAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLicenseTestAppointments.Location = new System.Drawing.Point(17, 709);
            this.dgvLicenseTestAppointments.MultiSelect = false;
            this.dgvLicenseTestAppointments.Name = "dgvLicenseTestAppointments";
            this.dgvLicenseTestAppointments.ReadOnly = true;
            this.dgvLicenseTestAppointments.RowHeadersWidth = 62;
            this.dgvLicenseTestAppointments.RowTemplate.Height = 28;
            this.dgvLicenseTestAppointments.Size = new System.Drawing.Size(1099, 222);
            this.dgvLicenseTestAppointments.TabIndex = 55;
            this.dgvLicenseTestAppointments.TabStop = false;
            // 
            // ctrDrivingLicenseApplicationInfo1
            // 
            this.ctrDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(16, 203);
            this.ctrDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctrDrivingLicenseApplicationInfo1.Name = "ctrDrivingLicenseApplicationInfo1";
            this.ctrDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1118, 448);
            this.ctrDrivingLicenseApplicationInfo1.TabIndex = 54;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 1009);
            this.Controls.Add(this.dgvLicenseTestAppointments);
            this.Controls.Add(this.ctrDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.lbl_RecordCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewAppointment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbListTestAppointments);
            this.Controls.Add(this.lbl_Title_frmListTestAppointments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListTestAppointments";
            this.Text = "Vision Test Appointment";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbListTestAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLicenseTestAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Title_frmListTestAppointments;
        private System.Windows.Forms.PictureBox pbListTestAppointments;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo3;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddNewAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl_RecordCount;
        private System.Windows.Forms.Label label2;
        private Applications.Controls.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo2;
        private System.Windows.Forms.DataGridView dgvLicenseTestAppointments;
    }
}