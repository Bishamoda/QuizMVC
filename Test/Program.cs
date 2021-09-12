using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=True;";


            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
            }

        }
    }
}
