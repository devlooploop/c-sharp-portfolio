namespace DVLD_2_my.User
{
    partial class ctrUserCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIsActiveValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUserNameValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserIDValue = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.personDetails_uc1 = new DVLD_2_my.PersonDetails_uc();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIsActiveValue
            // 
            this.lblIsActiveValue.AutoSize = true;
            this.lblIsActiveValue.BackColor = System.Drawing.Color.White;
            this.lblIsActiveValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActiveValue.Location = new System.Drawing.Point(924, 52);
            this.lblIsActiveValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsActiveValue.Name = "lblIsActiveValue";
            this.lblIsActiveValue.Size = new System.Drawing.Size(51, 25);
            this.lblIsActiveValue.TabIndex = 15;
            this.lblIsActiveValue.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(800, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Is Active :";
            // 
            // lblUserNameValue
            // 
            this.lblUserNameValue.AutoSize = true;
            this.lblUserNameValue.BackColor = System.Drawing.Color.White;
            this.lblUserNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameValue.Location = new System.Drawing.Point(560, 52);
            this.lblUserNameValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserNameValue.Name = "lblUserNameValue";
            this.lblUserNameValue.Size = new System.Drawing.Size(51, 25);
            this.lblUserNameValue.TabIndex = 13;
            this.lblUserNameValue.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(410, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "User Name :";
            // 
            // lblUserIDValue
            // 
            this.lblUserIDValue.AutoSize = true;
            this.lblUserIDValue.BackColor = System.Drawing.Color.White;
            this.lblUserIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserIDValue.Location = new System.Drawing.Point(127, 52);
            this.lblUserIDValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserIDValue.Name = "lblUserIDValue";
            this.lblUserIDValue.Size = new System.Drawing.Size(51, 25);
            this.lblUserIDValue.TabIndex = 11;
            this.lblUserIDValue.Text = "???";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(15, 52);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 25);
            this.label22.TabIndex = 10;
            this.label22.Text = "User ID :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblIsActiveValue);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblUserIDValue);
            this.groupBox1.Controls.Add(this.lblUserNameValue);
            this.groupBox1.Location = new System.Drawing.Point(14, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 112);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // personDetails_uc1
            // 
            this.personDetails_uc1.AllowLinkLabelEditPersonEnabled = true;
            this.personDetails_uc1.Location = new System.Drawing.Point(3, 15);
            this.personDetails_uc1.Margin = new System.Windows.Forms.Padding(2);
            this.personDetails_uc1.Name = "personDetails_uc1";
            this.personDetails_uc1.Size = new System.Drawing.Size(1174, 328);
            this.personDetails_uc1.TabIndex = 0;
            // 
            // ctrUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personDetails_uc1);
            this.Name = "ctrUserCard";
            this.Size = new System.Drawing.Size(1191, 492);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetails_uc personDetails_uc1;
        private System.Windows.Forms.Label lblIsActiveValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUserNameValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserIDValue;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
