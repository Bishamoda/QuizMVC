using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebQz
{
    public static class DBConnection
    {
        
       public static SqlConnection connection = new SqlConnection("Server=localhost;Database=TestDB;Trusted_Connection=True;");
        
    }
}
