namespace DVLD_2_my
{
    partial class PersonDetailsWithFilter_uc
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
            this.gbFilterPersonBy = new System.Windows.Forms.GroupBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtFilterPerson = new System.Windows.Forms.TextBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.cbFilterPersonBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personDetails_uc1 = new DVLD_2_my.PersonDetails_uc();
            this.gbFilterPersonBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterPersonBy
            // 
            this.gbFilterPersonBy.BackColor = System.Drawing.Color.White;
            this.gbFilterPersonBy.Controls.Add(this.btnAddPerson);
            this.gbFilterPersonBy.Controls.Add(this.txtFilterPerson);
            this.gbFilterPersonBy.Controls.Add(this.btnFindPerson);
            this.gbFilterPersonBy.Controls.Add(this.cbFilterPersonBy);
            this.gbFilterPersonBy.Controls.Add(this.label1);
            this.gbFilterPersonBy.Location = new System.Drawing.Point(3, 3);
            this.gbFilterPersonBy.Name = "gbFilterPersonBy";
            this.gbFilterPersonBy.Size = new System.Drawing.Size(1156, 86);
            this.gbFilterPersonBy.TabIndex = 43;
            this.gbFilterPersonBy.TabStop = false;
            this.gbFilterPersonBy.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPerson.Image = global::DVLD_2_my.Properties.Resources.Add_Person_32;
            this.btnAddPerson.Location = new System.Drawing.Point(659, 27);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(57, 54);
            this.btnAddPerson.TabIndex = 14;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtFilterPerson
            // 
            this.txtFilterPerson.Location = new System.Drawing.Point(333, 39);
            this.txtFilterPerson.Name = "txtFilterPerson";
            this.txtFilterPerson.Size = new System.Drawing.Size(239, 26);
            this.txtFilterPerson.TabIndex = 13;
            this.txtFilterPerson.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterPerson_KeyPress);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPerson.Image = global::DVLD_2_my.Properties.Resources.Search_Person;
            this.btnFindPerson.Location = new System.Drawing.Point(592, 27);
            this.btnFindPerson.Margin = new System.Windows.Forms.Padding(5);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(57, 54);
            this.btnFindPerson.TabIndex = 12;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // cbFilterPersonBy
            // 
            this.cbFilterPersonBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterPersonBy.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterPersonBy.FormattingEnabled = true;
            this.cbFilterPersonBy.Items.AddRange(new object[] {
            "National No.",
            "Person ID"});
            this.cbFilterPersonBy.Location = new System.Drawing.Point(112, 33);
            this.cbFilterPersonBy.Margin = new System.Windows.Forms.Padding(5);
            this.cbFilterPersonBy.Name = "cbFilterPersonBy";
            this.cbFilterPersonBy.Size = new System.Drawing.Size(202, 38);
            this.cbFilterPersonBy.TabIndex = 11;
            this.cbFilterPersonBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterPersonBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Filter By:";
            // 
            // personDetails_uc1
            // 
            this.personDetails_uc1.AllowLinkLabelEditPersonEnabled = true;
            this.personDetails_uc1.BackColor = System.Drawing.Color.White;
            this.personDetails_uc1.Location = new System.Drawing.Point(6, 105);
            this.personDetails_uc1.Name = "personDetails_uc1";
            this.personDetails_uc1.Size = new System.Drawing.Size(1166, 317);
            this.personDetails_uc1.TabIndex = 0;
            // 
            // PersonDetailsWithFilter_uc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFilterPersonBy);
            this.Controls.Add(this.personDetails_uc1);
            this.Name = "PersonDetailsWithFilter_uc";
            this.Size = new System.Drawing.Size(1173, 415);
            this.Load += new System.EventHandler(this.PersonDetailsWithFilter_uc_Load);
            this.gbFilterPersonBy.ResumeLayout(false);
            this.gbFilterPersonBy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetails_uc personDetails_uc1;
        private System.Windows.Forms.GroupBox gbFilterPersonBy;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.TextBox txtFilterPerson;
        private System.Windows.Forms.Button btnFindPerson;
        private System.Windows.Forms.ComboBox cbFilterPersonBy;
        private System.Windows.Forms.Label label1;
    }
}
