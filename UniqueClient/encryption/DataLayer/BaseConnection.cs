using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace encryption
{
    class BaseConnection
    {
        public const string SQLCONNECTION = "Data Source=DESKTOP-VP6C354\\SQLEXPRESS;Initial Catalog=securecloud;Integrated Security=True";
        public SqlConnection opencon()
        {
            SqlConnection con=new SqlConnection(SQLCONNECTION);
            con.Open();
            return con;
        }
    }
}
