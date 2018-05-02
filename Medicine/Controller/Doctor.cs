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
    public class Doctor
    {
        public ArrayList Prescriptions = new ArrayList();
        public String id = "";
        public String name = "";

        public Doctor(String id)
        {
            this.id = id;
            searchDoctor(id);
        }

        public Doctor(String id, String name)
        {
            this.id = id;
            this.name = name;
            update();
        }

        public ArrayList GetPrescriptionByPatient(String patientId)
        {
            ArrayList myScripts = new ArrayList();
            foreach (Prescription script in Prescriptions)
            {
                if (script.patient.id.Equals(patientId))
                {
                    myScripts.Add(script);
                }
            }
            return myScripts;
        }

        public void searchDoctor(String id)
        {
            // Select attributes
            String query = "SELECT ";
            query += "name ";
            // From tables
            query += " FROM doctor ";
            // Special conditions
            query += " Where Id = @doctor_id";

            ArrayList myParams = new ArrayList();

            Tuple<String, String> tupleDr = new Tuple<String, String>("@doctor_id", this.id);
            myParams.Add(tupleDr);

            Query q = new SelectQuery(query, myParams);
            q.run(false);

            // Read results
            readResults(q);
            q.closeConnection();
        }

        public void readResults(Query q)
        {
            if (q.reader.HasRows)
            {
                while (q.reader.Read())
                {
                    this.name = q.reader.GetString(0);
                }
            }
            else
            {
                Console.WriteLine("No doctors found.");
            }
            q.reader.Close();
        }

        public void update()
        {
            // TODO (optional): Insert new doctor to DB
        }
    }
}
