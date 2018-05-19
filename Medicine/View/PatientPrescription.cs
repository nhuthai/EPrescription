using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine
{
    public partial class PatientPrescription : Form
    {
        public ArrayList Prescriptions = new ArrayList();
        public ArrayList PrescriptionsView = new ArrayList();
        public Patient patient;

        public PatientPrescription(String idPatient)
        {
            InitializeComponent();
            patient = new Patient(idPatient);
            this.Patientlbl.Text = patient.name + ", " + patient.age + " years old";
            this.Addresslbl.Text = patient.address;
            getInfor(idPatient);
        }

        private void PatientPrescription_Load(object sender, EventArgs e)
        {
            
        }

        public void getInfor(String idPatient)
        {
            patient.search();
            remove();
            Prescriptions = patient.GetPrescriptionByTime(DateTime.Now);
            display();
        }

        public void display()
        {
            int preHeight = 0;
            foreach(Prescription p in Prescriptions)
            {
                /*APrescription ptPrescript = new APrescription(0, preHeight, p);
                PrescriptionsView.Add(ptPrescript);
                ptPrescript.AddToPanel(this.Prescriptionpanel);
                preHeight = ptPrescript.maxAlignY + 5;*/
                foreach(Pill pi in p.getPills())
                {
                    this.patientGrid.Rows.Add(p.disease.name, pi.name, pi.amount, p.doctor.name);
                }
            }
        }

        public void remove()
        {
            foreach(APrescription p in PrescriptionsView)
            {
                p.RemoveFromPanel(this.Prescriptionpanel);
            }
            PrescriptionsView.Clear();
            Prescriptions.Clear();
        }
    }
}
