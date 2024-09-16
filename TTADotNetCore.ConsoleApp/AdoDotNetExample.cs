using System;
using System.Collections.Generic;
using System.Data;
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

        public void Create()
        {
            Console.WriteLine("--- Blog Insert Form ---");
            Console.WriteLine("Blog Title : ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertQuery = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
            VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt=new DataTable();
            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();
            //if(result==1)
            //{
            //    Console.WriteLine("Saving successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Saving failed.");
            //}

            Console.WriteLine(result == 1 ? "Saving successfuly." : "Saving failed.");
            connection.Close();
        }

        public void Edit()
        {
            Console.WriteLine("-- Blog Edit Form --");
            Console.Write("Blog Id:");
            string id=Console.ReadLine();

            string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId=@BlogId;";

            SqlCommand cmd=new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId",id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0 )
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);

        }

        public void Update()
        {
            Console.WriteLine("*** Update Form to fill ***");
            Console.Write("Enter Blog Id - ");
            string id=Console.ReadLine() ;

            Console.Write("New Blog Title: ");
            string title=Console.ReadLine();

            Console.Write("New Blog Author: ");
            string author=Console.ReadLine();

            Console.Write("New Blog Content: ");
            string content=Console.ReadLine();

            

            string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertQuery = $@"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @BlogTitle
                ,[BlogAuthor] = @BlogAuthor
                ,[BlogContent] = @BlogContent
                ,[DeleteFlag] = 0
            WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            

            int result = cmd.ExecuteNonQuery();
            

            Console.WriteLine(result == 1 ? "Updating successfuly." : "Updating failed.");
            connection.Close();


        }

        public void Delete()
        {
            Console.WriteLine("*** Delete Blog Form ***");
            Console.Write("Enter Blog Id - ");
            string id = Console.ReadLine();

            string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string insertQuery = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(insertQuery, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            //cmd.Parameters.AddWithValue("@BlogTitle", title);
            //cmd.Parameters.AddWithValue("@BlogAuthor", author);
            //cmd.Parameters.AddWithValue("@BlogContent", content);


            int result = cmd.ExecuteNonQuery();


            Console.WriteLine(result == 1 ? "Deleting successfuly." : "Deleting failed.");
            connection.Close();


        }
    }
}
