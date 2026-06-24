namespace DVLD_2_my
{
    partial class frmTestTest
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
            this.tcPersonApplicationInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.personDetailsWithFilter_uc1 = new DVLD_2_my.PersonDetailsWithFilter_uc();
            this.personDetailsWithFilter_uc2 = new DVLD_2_my.PersonDetailsWithFilter_uc();
            this.tcPersonApplicationInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPersonApplicationInfo
            // 
            this.tcPersonApplicationInfo.Controls.Add(this.tpPersonInfo);
            this.tcPersonApplicationInfo.Controls.Add(this.tpApplicationInfo);
            this.tcPersonApplicationInfo.Location = new System.Drawing.Point(50, 41);
            this.tcPersonApplicationInfo.Name = "tcPersonApplicationInfo";
            this.tcPersonApplicationInfo.SelectedIndex = 0;
            this.tcPersonApplicationInfo.Size = new System.Drawing.Size(1282, 658);
            this.tcPersonApplicationInfo.TabIndex = 1;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.Controls.Add(this.button1);
            this.tpPersonInfo.Controls.Add(this.personDetailsWithFilter_uc2);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(1274, 625);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            this.tpPersonInfo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::DVLD_2_my.Properties.Resources.Next_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1101, 547);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 59);
            this.button1.TabIndex = 5;
            this.button1.Text = "Next";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(1274, 683);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            this.tpApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD_2_my.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1180, 706);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 60);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD_2_my.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1000, 706);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 60);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // personDetailsWithFilter_uc1
            // 
            this.personDetailsWithFilter_uc1.Location = new System.Drawing.Point(35, 19);
            this.personDetailsWithFilter_uc1.Name = "personDetailsWithFilter_uc1";
            this.personDetailsWithFilter_uc1.Size = new System.Drawing.Size(1275, 584);
            this.personDetailsWithFilter_uc1.TabIndex = 0;
            this.personDetailsWithFilter_uc1.Load += new System.EventHandler(this.personDetailsWithFilter_uc1_Load);
            // 
            // personDetailsWithFilter_uc2
            // 
            this.personDetailsWithFilter_uc2.Location = new System.Drawing.Point(6, 30);
            this.personDetailsWithFilter_uc2.Name = "personDetailsWithFilter_uc2";
            this.personDetailsWithFilter_uc2.Size = new System.Drawing.Size(1294, 530);
            this.personDetailsWithFilter_uc2.TabIndex = 6;
            // 
            // frmTestTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 793);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcPersonApplicationInfo);
            this.Name = "frmTestTest";
            this.Text = "Form Test";
            this.tcPersonApplicationInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetailsWithFilter_uc personDetailsWithFilter_uc1;
        private System.Windows.Forms.TabControl tcPersonApplicationInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private PersonDetailsWithFilter_uc personDetailsWithFilter_uc2;
    }
}