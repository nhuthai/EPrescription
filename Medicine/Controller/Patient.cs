using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace Medicine
{
    public class Patient
    {
        public String id = "";
        public String name = "";
        public int age = 0;
        public String address = "";
        ArrayList prescriptions = new ArrayList();

        public Patient(String id)
        {
            this.id = id;
            search();
        }

        public Patient(String id, String name, int age, String address)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.address = address;
            update();
        }

        public ArrayList PrescriptionList
        {
            get { return prescriptions; }
            set { prescriptions = value; }
        }

        public void addPrescription(Prescription script)
        {
            prescriptions.Add(script);
        }

        public ArrayList GetPrescriptionByTime(DateTime time)
        {
            ArrayList myScripts = new ArrayList();
            foreach (Prescription script in prescriptions)
            {
                ArrayList pills = script.getPills(time);
                if(pills != null && pills.Count > 0)
                {
                    Prescription tmpScript = new Prescription(this, script.doctor.id, script.disease.name);
                    tmpScript.setPills(pills,script.fromDate, script.ToDate);
                    myScripts.Add(tmpScript);
                }
            }
            return myScripts;
        }

        public void search()
        {
            prescriptions.Clear();
            // Select attributes
            String query = "Select ";
            query += "p.name, p.age, p.address, ";
            query += "s.Id, s.[from], s.[to], ";
            query += "d.Id, d.name, ";
            query += "disease.Id, disease.notice, ";
            query += "pill.Id, ";
            query += "pp.time, pp.amount ";
            // From tables
            query += " From patient As p, doctor As d, prescription As s, pill, disease, pres_pill As pp ";
            // Conditions to join tables
            query += " Where s.patientId = p.Id And s.doctorId = d.Id And s.diseaseId = disease.Id";
            query += " And pp.prescriptionId = s.Id And pp.pillId = pill.Id";
            // Special conditions
            query += " And p.id = @patient_id";

            ArrayList myParams = new ArrayList();

            Tuple<String, String> tuplePatient = new Tuple<String, String>("@patient_id", this.id);
            myParams.Add(tuplePatient);

            Query q = new SelectQuery(query, myParams);
            q.run(false);

            // Read results
            readResults(q.reader);
        }

        public void readResults(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                Prescription tmpScript = new Prescription();
                Dictionary<int, int> dictScriptId = new Dictionary<int, int>();
                while (reader.Read())
                {
                    this.name = reader.GetString(0);
                    this.age = reader.GetInt32(1);
                    this.address = reader.GetString(2);

                    int idScript = reader.GetInt32(3);
                    if (tmpScript == null || tmpScript.id == -1 || !dictScriptId.ContainsKey(idScript))
                    {
                        //6 d.id, 7 d.name
                        //8 disease.id, 9 disease.notice
                        tmpScript = new Prescription(this, reader.GetString(6), reader.GetString(8));
                        tmpScript.doctor.name = reader.GetString(7);
                        tmpScript.disease.notice = reader.GetString(9);
                        tmpScript.id = reader.GetInt32(3);
                        dictScriptId.Add(tmpScript.id, prescriptions.Count);
                        tmpScript.fromDate = reader.GetDateTime(4);
                        tmpScript.ToDate = reader.GetDateTime(5);
                        prescriptions.Add(tmpScript);
                    }
                    tmpScript = (Prescription)prescriptions[dictScriptId[idScript]];
                    //10 pill.name
                    //11 pp.time, 12 pp.amount
                    String tokenTime = reader.GetString(11);
                    bool[] timeToTake;
                    if (tokenTime.Equals("000"))
                        timeToTake = new bool[3] { false, false, false };
                    else if (tokenTime.Equals("001"))
                        timeToTake = new bool[3] { false, false, true };
                    else if (tokenTime.Equals("010"))
                        timeToTake = new bool[3] { false, true, false };
                    else if (tokenTime.Equals("011"))
                        timeToTake = new bool[3] { false, true, true };
                    else if (tokenTime.Equals("100"))
                        timeToTake = new bool[3] { true, false, false };
                    else if (tokenTime.Equals("101"))
                        timeToTake = new bool[3] { true, false, true };
                    else if (tokenTime.Equals("110"))
                        timeToTake = new bool[3] { true, true, false };
                    else
                        timeToTake = new bool[3] { true, true, true };
                    Pill aDrug = new Pill(reader.GetString(10), reader.GetInt32(12), timeToTake);
                    tmpScript.getPills().Add(aDrug);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
        }

        public void update()
        {
            // TODO (optional): Insert new patient to DB
        }
    }
}
