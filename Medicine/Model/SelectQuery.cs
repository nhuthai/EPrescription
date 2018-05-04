using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Model
{
    public class SelectQuery : Query
    {
        public SelectQuery(String type, String table, String attribute, ArrayList Params)
        {
            this.type = type;
            this.table = table;
            this.attribute = attribute;
            this.Params = Params;
        }

        public SelectQuery(String query, ArrayList Params)
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
                foreach(Tuple<String, String> t in Params)
                {
                    cmd.Parameters.AddWithValue(t.Item1, t.Item2);
                }
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return false;
            }
            return true;
        }
    }
}
