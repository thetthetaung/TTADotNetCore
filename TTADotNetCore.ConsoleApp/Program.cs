// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.WriteLine();
Console.ReadLine();
//Console.ReadKey();

//markdown
//Day-1 ( Finish )
//7.9.2024
//Day-2 Start

string connectionString = "Data Source=.;Initial Catalog=DotNetCore;User ID=sa;Password=sa@123;";
SqlConnection connetion = new SqlConnection(connectionString);

Console.WriteLine("Connection string is : "+connectionString);
Console.WriteLine("Connetion opening ...........");
connetion.Open();
Console.WriteLine("Connetion opened!");

string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] WHERE DeleteFlag=0";

SqlCommand cmd = new SqlCommand(query,connetion);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt=new DataTable();
//adapter.Fill(dt);

SqlDataReader reader = cmd.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine(reader["BlogId"]);
    Console.WriteLine(reader["BlogTitle"]);
    Console.WriteLine(reader["BlogAuthor"]);
    Console.WriteLine(reader["BlogContent"]);
    Console.WriteLine(reader["DeleteFlag"]);
}

//dt = adapter.Execute();
//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//    Console.WriteLine(dr["DeleteFlag"]);
//}

Console.WriteLine("Connection is closing.....");
connetion.Close();
Console.WriteLine("Connection closed!");

//DataSet ->DataTable->DataRow->DataColumn

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]); 
//    Console.WriteLine(dr["BlogContent"]);
//    Console.WriteLine(dr["DeleteFlag"]);
//}
//foreach loop is okay after closing connection beacuse we already have all the data in the datatable
//If we want to get row by row data, foreach is okay to place before closing connection