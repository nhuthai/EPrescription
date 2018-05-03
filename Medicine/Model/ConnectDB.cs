using Medicine.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    public class ConnectDB
    {
        private String connString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

        public ConnectDB()
        {

        }

        public void startSess(Query query)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query.ToString(), conn);
                command.Connection.Open();

                query.reader = command.ExecuteReader();
                //command.ExecuteNonQuery();
            }
        }
    }
}
