using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTADotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;
        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<T> Query<T>(string query,object? param=null)
        {
            Console.WriteLine("Query is "+query);
            using IDbConnection db = new SqlConnection(_connectionString);
            
            var lst=db.Query<T>(query,param).ToList();
            return lst;
            //Instead of using T, all any other letter can be used. <> means annynomous.
        }
        public T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db=new SqlConnection(_connectionString);
            var item=db.QueryFirstOrDefault<T>(query,param);
            return item;
        }
        public int Execute(string query, object? param = null) 
        {
            using IDbConnection db=new SqlConnection(_connectionString);
            var result=db.Execute(query,param);
            return result;
        }
    }
}
