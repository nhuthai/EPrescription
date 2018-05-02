using Medicine.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    public class Prescription
    {
        public int id = -1; // for distinct when creating prescription from DB
        public Patient patient;
        public Disease disease;
        public Doctor doctor;
        private ArrayList pills = new ArrayList();
        public DateTime fromDate;
        public DateTime ToDate;

        public Prescription() { }

        public Prescription(Patient patient, String doctor, String disease)
        {
            this.doctor = new Doctor(doctor);
            this.patient = patient;
            this.disease = new Disease(disease);
        }

        public Prescription(String patient, Doctor doctor, String disease)
        {
            this.doctor = doctor;
            this.patient = new Patient(patient);
            this.disease = new Disease(disease);
        }

        public Prescription(Patient patient, String doctor, String disease, ArrayList pillNotes, DateTime from, DateTime To)
        {
            this.patient = patient;
            this.doctor = new Doctor(doctor);
            this.disease = new Disease(disease);
            this.fromDate = from;
            this.ToDate = To;
            foreach (ANote note in pillNotes)
            {
                Pill p = new Pill();
                if(note.getInfor(p))
                {
                    this.pills.Add(p);
                }
            }
        }

        public Prescription(String patient, Doctor doctor, String disease, ArrayList pillNotes, DateTime from, DateTime To)
        {
            this.patient = new Patient(patient);
            this.doctor = doctor;
            this.disease = new Disease(disease);
            this.fromDate = from;
            this.ToDate = To;
            foreach (ANote note in pillNotes)
            {
                Pill p = new Pill();
                if (note.getInfor(p))
                {
                    this.pills.Add(p);
                }
            }
        }

        public void setPills(ArrayList pills, DateTime from, DateTime To)
        {
            this.pills = pills;
            this.fromDate = from;
            this.ToDate = To;
        }

        public ArrayList getPills()
        {
            return pills;
        }

        public ArrayList getPills(DateTime now)
        {
            if (!(fromDate!=null && ToDate!=null && fromDate.Date.CompareTo(now.Date) <= 0 && now.Date.CompareTo(ToDate.Date) <= 0))
                return null;
            ArrayList currentPills = new ArrayList();
            foreach(Pill pill in pills)
            {
                if (pill.isTimeToTake(now))
                    currentPills.Add(pill);
            }
            return currentPills;
        }

        public void updateDB()
        {
            SqlConnection myConn = new SqlConnection();
            // Insert script
            string query = "Insert into prescription values (@doctor_id, @patient_id, @disease_id, @from, @to)";

            ArrayList myParams = new ArrayList();

            Tuple<String, String> tupleDr = new Tuple<String, String>("@doctor_id", this.doctor.id);
            myParams.Add(tupleDr);
            Tuple<String, String> tuplePatient = new Tuple<String, String>("@patient_id", this.patient.id);
            myParams.Add(tuplePatient);
            Tuple<String, String> tupleDisease = new Tuple<String, String>("@disease_id", this.disease.name);
            myParams.Add(tupleDisease);
            Tuple<String, String> tupleFrom = new Tuple<String, String>("@from", this.fromDate.ToString());
            myParams.Add(tupleFrom);
            Tuple<String, String> tupleTo = new Tuple<String, String>("@to", this.ToDate.ToString());
            myParams.Add(tupleTo);

            Query q = new InsertQuery(query, myParams);
            q.openConnection(myConn);
            if (!q.run(true))
                return;

            // Get scriptId
            // Select attributes
            query = "SELECT TOP 1 Id FROM prescription ORDER BY Id DESC";
            myParams.Clear();

            q = new SelectQuery(query, myParams);
            q.run(true);

            // Read results
            if (q.reader.HasRows)
            {
                while (q.reader.Read())
                {
                    this.id = q.reader.GetInt32(0);
                }
            }
            else
            {
                Console.WriteLine("No Scripts found.");
                q.closeConnection(myConn);
                return;
            }
            q.reader.Close();

            // Insert pills
            foreach (Pill p in this.pills)
            {
                query = "Insert into pres_pill values (@script_id, @pill_id, @time, @amount)";
                myParams.Clear();
                myParams = new ArrayList();

                Tuple<String, String> tupleScript = new Tuple<String, String>("@script_id", this.id.ToString());
                myParams.Add(tupleScript);
                Tuple<String, String> tuplePill = new Tuple<String, String>("@pill_id", p.name);
                myParams.Add(tuplePill);
                Tuple<String, String> tupleTime = new Tuple<String, String>("@time", p.timeToString());
                myParams.Add(tupleTime);
                Tuple<String, String> tupleAmount = new Tuple<String, String>("@amount", p.amount.ToString());
                myParams.Add(tupleAmount);

                q = new InsertQuery(query, myParams);
                if (!q.run(true))
                    return;
            }
            q.closeConnection(myConn);
        }
    }
}
