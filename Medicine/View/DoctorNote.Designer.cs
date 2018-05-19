namespace Medicine
{
    partial class DoctorNote
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
            this.AddBtn = new System.Windows.Forms.Button();
            this.NotePanel = new System.Windows.Forms.Panel();
            this.PatientTbx = new System.Windows.Forms.TextBox();
            this.patientNamelbl = new System.Windows.Forms.Label();
            this.Submitbtn = new System.Windows.Forms.Button();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.Fromlbl = new System.Windows.Forms.Label();
            this.Tolbl = new System.Windows.Forms.Label();
            this.Diseaselbl = new System.Windows.Forms.Label();
            this.diseasetBx = new System.Windows.Forms.TextBox();
            this.Doctorlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(15, 266);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // NotePanel
            // 
            this.NotePanel.AllowDrop = true;
            this.NotePanel.AutoScroll = true;
            this.NotePanel.Location = new System.Drawing.Point(14, 64);
            this.NotePanel.Name = "NotePanel";
            this.NotePanel.Size = new System.Drawing.Size(668, 196);
            this.NotePanel.TabIndex = 1;
            // 
            // PatientTbx
            // 
            this.PatientTbx.Location = new System.Drawing.Point(58, 12);
            this.PatientTbx.Name = "PatientTbx";
            this.PatientTbx.Size = new System.Drawing.Size(321, 20);
            this.PatientTbx.TabIndex = 2;
            // 
            // patientNamelbl
            // 
            this.patientNamelbl.AutoSize = true;
            this.patientNamelbl.Location = new System.Drawing.Point(12, 9);
            this.patientNamelbl.Name = "patientNamelbl";
            this.patientNamelbl.Size = new System.Drawing.Size(40, 13);
            this.patientNamelbl.TabIndex = 3;
            this.patientNamelbl.Text = "Patient";
            // 
            // Submitbtn
            // 
            this.Submitbtn.Location = new System.Drawing.Point(112, 266);
            this.Submitbtn.Name = "Submitbtn";
            this.Submitbtn.Size = new System.Drawing.Size(75, 23);
            this.Submitbtn.TabIndex = 4;
            this.Submitbtn.Text = "Update";
            this.Submitbtn.UseVisualStyleBackColor = true;
            this.Submitbtn.Click += new System.EventHandler(this.Submitbtn_Click);
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(58, 38);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(200, 20);
            this.FromDate.TabIndex = 5;
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(452, 38);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(200, 20);
            this.ToDate.TabIndex = 6;
            // 
            // Fromlbl
            // 
            this.Fromlbl.AutoSize = true;
            this.Fromlbl.Location = new System.Drawing.Point(15, 38);
            this.Fromlbl.Name = "Fromlbl";
            this.Fromlbl.Size = new System.Drawing.Size(30, 13);
            this.Fromlbl.TabIndex = 7;
            this.Fromlbl.Text = "From";
            // 
            // Tolbl
            // 
            this.Tolbl.AutoSize = true;
            this.Tolbl.Location = new System.Drawing.Point(411, 38);
            this.Tolbl.Name = "Tolbl";
            this.Tolbl.Size = new System.Drawing.Size(20, 13);
            this.Tolbl.TabIndex = 8;
            this.Tolbl.Text = "To";
            // 
            // Diseaselbl
            // 
            this.Diseaselbl.AutoSize = true;
            this.Diseaselbl.Location = new System.Drawing.Point(396, 9);
            this.Diseaselbl.Name = "Diseaselbl";
            this.Diseaselbl.Size = new System.Drawing.Size(45, 13);
            this.Diseaselbl.TabIndex = 9;
            this.Diseaselbl.Text = "Disease";
            // 
            // diseasetBx
            // 
            this.diseasetBx.Location = new System.Drawing.Point(448, 9);
            this.diseasetBx.Name = "diseasetBx";
            this.diseasetBx.Size = new System.Drawing.Size(234, 20);
            this.diseasetBx.TabIndex = 10;
            // 
            // Doctorlbl
            // 
            this.Doctorlbl.AutoSize = true;
            this.Doctorlbl.Location = new System.Drawing.Point(647, 276);
            this.Doctorlbl.Name = "Doctorlbl";
            this.Doctorlbl.Size = new System.Drawing.Size(0, 13);
            this.Doctorlbl.TabIndex = 11;
            // 
            // DoctorNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 301);
            this.Controls.Add(this.Doctorlbl);
            this.Controls.Add(this.diseasetBx);
            this.Controls.Add(this.Diseaselbl);
            this.Controls.Add(this.Tolbl);
            this.Controls.Add(this.Fromlbl);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.Submitbtn);
            this.Controls.Add(this.patientNamelbl);
            this.Controls.Add(this.PatientTbx);
            this.Controls.Add(this.NotePanel);
            this.Controls.Add(this.AddBtn);
            this.Name = "DoctorNote";
            this.Text = "DoctorNote";
            this.Load += new System.EventHandler(this.DoctorNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Panel NotePanel;
        private System.Windows.Forms.TextBox PatientTbx;
        private System.Windows.Forms.Label patientNamelbl;
        private System.Windows.Forms.Button Submitbtn;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.Label Fromlbl;
        private System.Windows.Forms.Label Tolbl;
        private System.Windows.Forms.Label Diseaselbl;
        private System.Windows.Forms.TextBox diseasetBx;
        private System.Windows.Forms.Label Doctorlbl;
    }
}