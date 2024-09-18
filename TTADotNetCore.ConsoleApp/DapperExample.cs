using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TTADotNetCore.ConsoleApp.Models;

namespace TTADotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123";
        public void Read()
        {
            //using (IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where DeleteFlag=0;";
            //    var lst=db.Query(query).ToList();
            //    foreach (var item in lst) 
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag=0;";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine("\n");
                    Console.Write(item.BlogId);
                    Console.Write(item.BlogTitle);
                    Console.Write(item.BlogAuthor);
                    Console.Write(item.BlogContent);
                }
            }
            //DTO - Data Transfer Object
        }

        public void Create(string title,string author,string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
            VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result=db.Execute(query,new BlogDataModel
                {
                    BlogTitle=title,
                    BlogAuthor=author,
                    BlogContent=content,
                });
                Console.WriteLine(result==1? "Saving successful.":"Saving failed.");
            }

        }

        public void Edit(int id)
        {
        
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag=0 and BlogId=@BlogId;";
                var item = db.Query<BlogDataModel>(query,new
                {
                    BlogId=id
                }).FirstOrDefault();
                //if (item != null)
                if(item is null)
                {
                    Console.WriteLine("No Data Found.");
                    return;
                }
                
                    Console.WriteLine("\n");
                    Console.Write(item.BlogId);
                    Console.Write(item.BlogTitle);
                    Console.Write(item.BlogAuthor);
                    Console.Write(item.BlogContent);
                
            }
            //DTO - Data Transfer Object
        }

        public void Update()
        {
            Console.WriteLine("*** Update Form to fill ***");
            Console.Write("Enter Blog Id - ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("New Blog Author: ");
            string author = Console.ReadLine();

            Console.Write("New Blog Content: ");
            string content = Console.ReadLine();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET [BlogTitle] = @BlogTitle
                ,[BlogAuthor] = @BlogAuthor
                ,[BlogContent] = @BlogContent
                ,[DeleteFlag] = 0
            WHERE DeleteFlag=0 and BlogId=@BlogId";


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId=id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Updating successful." : "Updating failed.");

            }
        }

        public void Delete()
        {
            Console.WriteLine("*** Delete Form to fill ***");
            Console.Write("Enter Blog Id - ");
            int id = Convert.ToInt32(Console.ReadLine());

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET DeleteFlag=1
                         WHERE DeleteFlag=0 and BlogId=@BlogId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {

                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                });
                Console.WriteLine(result == 1 ? "Deleting successful." : "Deleting failed.");

            }
            //DTO - Data Transfer Object
        }


    }

}
