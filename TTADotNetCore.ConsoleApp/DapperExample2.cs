using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTADotNetCore.ConsoleApp.Models;
using TTADotNetCore.Shared;

namespace TTADotNetCore.ConsoleApp
{
    public class DapperExample2
    {
        private readonly string _connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123;TrustServerCertificate=True;";

        private readonly DapperService _dapperService;
        public DapperExample2()
        {
            _dapperService=new DapperService(_connectionString);
        }
        public void Read()
        {
            string query = "select * from tbl_blog where DeleteFlag=0;";
            var lst = _dapperService.Query<BlogDapperDataModel>(query).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
        public void Edit(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_Blog where DeleteFlag=0 and BlogId=@BlogId;";
                var item = db.QueryFirstOrDefault<BlogDapperDataModel>(query, new BlogDapperDataModel
                {
                    BlogId = id
                });
                if(item is null)
                {
                    Console.WriteLine("No Data Found!");
                    return;
                }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
        public void Create(string title, string author, string content)
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

            
                int result = _dapperService.Execute(query, new BlogDapperDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Saving successful." : "Saving failed.");
            

        }
    }
}

