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
    public class Query
    {
        public String queryString = "";
        public String type = "";
        public String attribute = "";
        public String table = "";
        public ArrayList Params;
        public SqlDataReader reader;
        protected String connString;
        protected SqlConnection conn;

        public Query() { }

        public Query(String type, String table, String attribute, ArrayList Params)
        {
            this.type = type;
            this.table = table;
            this.attribute = attribute;
            this.Params = Params;
        }

        public Query(String query, ArrayList Params)
        {
            this.queryString = query;
            this.Params = Params;
        }

        public override string ToString()
        {
            // get final query as text
            return this.queryString;
        }

        public SqlConnection openConnection(SqlConnection myConn)
        {
            connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
            myConn = new SqlConnection(connString);
            // Select simple doctor
            try
            {
                myConn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                myConn.Close();
            }
            return myConn;
        }

        public void closeConnection(SqlConnection myConn)
        {
            try
            {
                myConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void closeConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public virtual bool run(bool manualOpenClose)
        {
            return true;
        }
    }
}
