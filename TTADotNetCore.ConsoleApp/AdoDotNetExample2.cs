﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTADotNetCore.Shared;

namespace TTADotNetCore.ConsoleApp
{
    class AdoDotNetExample2
    {
        private readonly string _connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123;";
        private readonly AdoDotNetService _adoDotNetService;
        public AdoDotNetExample2()
        {
            _adoDotNetService=new AdoDotNetService(_connectionString);
        }
        public void Read()
        {
            string query = @"SELECT [@BlogId],
                            @BlogTitle,
                            @BlogAuthor,
                            @BlogContent,
                            @DeleteFlag
                            FROM [ado].[Tbl.Blog] where DeleteFlag=0
                            ";
            var dt=_adoDotNetService.Query(query);
            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }
        public void Edit()
        {
            Console.Write("Blog Id : ");
            string id=Console.ReadLine()!;
            string query = @"SELECT [@BlogId],
                            @BlogTitle,
                            @BlogAuthor,
                            @BlogContent,
                            @DeleteFlag
                            FROM [ado].[Tbl.Blog] where BlogId=@BlogId
                            ";
            //SqlParameterModel[] sqlParameterModels = new SqlParameterModel[1];
            //sqlParameterModels[0] = new SqlParameterModel
            //{
            //    Name="@BlogId",
            //    Value=id
            //};
            //var dt = _adoDotNetService.Query(query,sqlParameterModels);

            var dt = _adoDotNetService.Query(query, new SqlParameterModel
                                                    ("@BlogId", id));
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
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



            int result = _adoDotNetService.Execute(query,
                new SqlParameterModel("@BlogTitle", title),
                new SqlParameterModel("@BlogAuthor", author),
                new SqlParameterModel("@BlogContent", content));
           

            Console.WriteLine(result == 1 ? "Saving successfuly." : "Saving failed.");
        }

    }
}
