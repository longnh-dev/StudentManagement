using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class DataConnection
    {
        public string conString;

        public DataConnection()
        {
            conString = "Server=DESKTOP-FF1278R;Database=QLSV;Trusted_Connection=True;MultipleActiveResultSets=true"; //ten server name
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conString);
        }
    }
}