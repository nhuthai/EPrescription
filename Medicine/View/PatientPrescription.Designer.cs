namespace Medicine
{
    partial class PatientPrescription
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
            this.Patientlbl = new System.Windows.Forms.Label();
            this.Addresslbl = new System.Windows.Forms.Label();
            this.Prescriptionpanel = new System.Windows.Forms.Panel();
            this.patientGrid = new System.Windows.Forms.DataGridView();
            this.Disease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drug = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prescriptionpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Patientlbl
            // 
            this.Patientlbl.AutoSize = true;
            this.Patientlbl.Location = new System.Drawing.Point(12, 9);
            this.Patientlbl.Name = "Patientlbl";
            this.Patientlbl.Size = new System.Drawing.Size(0, 13);
            this.Patientlbl.TabIndex = 0;
            // 
            // Addresslbl
            // 
            this.Addresslbl.AutoSize = true;
            this.Addresslbl.Location = new System.Drawing.Point(15, 41);
            this.Addresslbl.Name = "Addresslbl";
            this.Addresslbl.Size = new System.Drawing.Size(0, 13);
            this.Addresslbl.TabIndex = 1;
            // 
            // Prescriptionpanel
            // 
            this.Prescriptionpanel.AutoScroll = true;
            this.Prescriptionpanel.Controls.Add(this.patientGrid);
            this.Prescriptionpanel.Location = new System.Drawing.Point(12, 76);
            this.Prescriptionpanel.Name = "Prescriptionpanel";
            this.Prescriptionpanel.Size = new System.Drawing.Size(711, 173);
            this.Prescriptionpanel.TabIndex = 2;
            // 
            // patientGrid
            // 
            this.patientGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Disease,
            this.Drug,
            this.Amount,
            this.Doctor});
            this.patientGrid.Location = new System.Drawing.Point(0, 0);
            this.patientGrid.Name = "patientGrid";
            this.patientGrid.Size = new System.Drawing.Size(447, 173);
            this.patientGrid.TabIndex = 0;
            // 
            // Disease
            // 
            this.Disease.HeaderText = "Disease";
            this.Disease.Name = "Disease";
            // 
            // Drug
            // 
            this.Drug.HeaderText = "Drug";
            this.Drug.Name = "Drug";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Doctor
            // 
            this.Doctor.HeaderText = "by Doctor";
            this.Doctor.Name = "Doctor";
            // 
            // PatientPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.Prescriptionpanel);
            this.Controls.Add(this.Addresslbl);
            this.Controls.Add(this.Patientlbl);
            this.Name = "PatientPrescription";
            this.Text = "PatientPrescription";
            this.Load += new System.EventHandler(this.PatientPrescription_Load);
            this.Prescriptionpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Patientlbl;
        private System.Windows.Forms.Label Addresslbl;
        private System.Windows.Forms.Panel Prescriptionpanel;
        private System.Windows.Forms.DataGridView patientGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disease;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drug;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
    }
}