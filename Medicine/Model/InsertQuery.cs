using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Model
{
    class InsertQuery : Query
    {
        public InsertQuery(String type, String table, String attribute, ArrayList Params)
        {
            this.type = type;
            this.table = table;
            this.attribute = attribute;
            this.Params = Params;
        }

        public InsertQuery(String query, ArrayList Params)
        {
            this.queryString = query;
            this.Params = Params;
        }

        public override bool run(bool manualOpenClose)
        {
            if (!manualOpenClose)
                this.conn = openConnection(this.conn);
            // Select simple doctor
            try
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                foreach (Tuple<String, String> t in Params)
                {
                    cmd.Parameters.AddWithValue(t.Item1, t.Item2);
                }
                int result = cmd.ExecuteNonQuery();

                if (result <= 0)
                {
                    Console.WriteLine("Cannot insert!");
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return false;
            }
            if (!manualOpenClose)
                closeConnection(this.conn);
            return true;
        }
    }
}
