using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace SchoolSystem
{
    public class Con1
    {
        // connection string
        private static readonly string connectionString = "Server=DESKTOP-2NBO3MT\\SQLEXPRESS;Database=School;Trusted_Connection=True;";

        // method to get the connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
