// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using TTADotNetCore.ConsoleApp;

//Console.WriteLine("Hello, World!");
//Console.WriteLine();
//Console.ReadLine();
//Console.ReadKey();

//markdown
//Day-1 ( Finish )
//7.9.2024
//Day-2 Start

//string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123;";
//SqlConnection connetion = new SqlConnection(connectionString);

//Console.WriteLine("Connection string is : "+ connetion);
//Console.WriteLine("Connetion opening ...........");
//connetion.Open();
//Console.WriteLine("Connetion opened!");

//string query = @"SELECT [BlogId]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//      ,[DeleteFlag]
//  FROM [dbo].[Tbl_Blog] WHERE DeleteFlag=0";

//SqlCommand cmd = new SqlCommand(query,connetion);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt=new DataTable();
//adapter.Fill(dt);

//SqlDataReader reader = cmd.ExecuteReader();
//while (reader.Read())
/*{
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

*/
//Console.WriteLine("--- Blog Insert Form ---");
//Console.WriteLine("Blog Title : ");
//string title=Console.ReadLine();

//Console.WriteLine("Blog Author: ");
//string author=Console.ReadLine();

//Console.WriteLine("Blog Content: ");
//string content=Console.ReadLine();

//string connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
//SqlConnection connection=new SqlConnection(connectionString);
//connection.Open();
//string insertQuery = $@"INSERT INTO [dbo].[Tbl_Blog]
//           ([BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent]
//           ,[DeleteFlag])
//     VALUES
//           (@BlogTitle
//           ,@BlogAuthor
//           ,@BlogContent
//           ,0)";
//SqlCommand cmd=new SqlCommand(insertQuery, connection);
//cmd.Parameters.AddWithValue("@BlogTitle", title);
//cmd.Parameters.AddWithValue("@BlogAuthor",author);
//cmd.Parameters.AddWithValue("@BlogContent",content);
////SqlDataAdapter adapter = new SqlDataAdapter(cmd);
////DataTable dt=new DataTable();
////adapter.Fill(dt);

//int result=cmd.ExecuteNonQuery();
////if(result==1)
////{
////    Console.WriteLine("Saving successfully.");
////}
////else
////{
////    Console.WriteLine("Saving failed.");
////}

//Console.WriteLine(result==1 ? "Saving successfuly.":"Saving failed.");
//connection.Close();

AdoDotNetExample adoDotNetExample=new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
adoDotNetExample.Delete();