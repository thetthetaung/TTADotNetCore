using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTADotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123;";

        public void Read()
        {
            Console.WriteLine("Connection string:"+ _connectionString);
            SqlConnection connection=new SqlConnection( _connectionString );

            Console.WriteLine("Connection opening.....");
            connection.Open();
            Console.WriteLine("Connection opened.");

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand( query, connection );
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }
            Console.WriteLine("Connection closing...");
            connection.Close();
            Console.WriteLine("Connection closed.");
        }
    }
}
