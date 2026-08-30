using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCommuteTracker
{
    public static class DatabaseHelper
    {
        
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EcoCommuteDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}