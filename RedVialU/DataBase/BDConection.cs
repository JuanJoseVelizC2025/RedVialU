using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAcces
{
    public abstract class ConnetionTosql
    {
        protected readonly string connectionString;
        public ConnetionTosql()
        {
            connectionString = "Server=LAPTOP-9HNHD1IK\\SQLEXPRESS01; DataBase=RedUrbanaVIal;integrated security = true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
