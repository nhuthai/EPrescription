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
    public partial class DoctorNote : Form
    {
        public ArrayList Notes = new ArrayList();
        public Doctor doctor;

        public DoctorNote(String doctorId)
        {
            InitializeComponent();
            doctor = new Doctor(doctorId);
            this.Doctorlbl.Text = doctor.name;

            initializeBlankNote();
        }

        private void DoctorNote_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ANote drNote = new ANote(0, ((ANote)Notes[Notes.Count - 1]).maxAlignY + 5);
            Notes.Add(drNote);
            drNote.AddToPanel(this.NotePanel);
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            if (!assertForm())
                MessageBox.Show("Please fill the blanks!");
            else
            {
                Prescription script = new Prescription(PatientTbx.Text, doctor, diseasetBx.Text, Notes, FromDate.Value, ToDate.Value);
                script.updateDB();
                remove();
                initializeBlankNote();
            }
        }

        public void remove()
        {
            foreach (ANote n in Notes)
            {
                n.RemoveFromPanel(this.NotePanel);
            }
            Notes.Clear();
        }

        public void initializeBlankNote()
        {
            ANote drNote1 = new ANote();
            Notes.Add(drNote1);
            drNote1.AddToPanel(this.NotePanel);

            ANote drNote2 = new ANote(0, drNote1.maxAlignY + 5);
            Notes.Add(drNote2);
            drNote2.AddToPanel(this.NotePanel);
        }

        private bool assertForm()
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            return (this.PatientTbx.Text.Trim(charsToTrim).Length > 0 && this.diseasetBx.Text.Trim(charsToTrim).Length > 0);
        }
    }
}
