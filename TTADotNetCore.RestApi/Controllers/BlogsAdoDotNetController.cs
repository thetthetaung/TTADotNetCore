using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TTADotNetCore.Database.Models;
using TTADotNetCore.RestApi.ViewModels;

namespace TTADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=THETTHETAUN8E36\\TTASQLEXPRESS;Initial Catalog=TTADotNetCoreDB;User ID=sa;Password=sa@123;TrustServerCertificate=true";

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogViewModel> lst = new List<BlogViewModel>();
            SqlConnection connection=new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
            ,[BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent]
            ,[DeleteFlag]
            ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var item = new BlogViewModel
                    {
                    Id = Convert.ToInt32(reader["BlogId"]),
                    Title = Convert.ToString(reader["BlogTitle"]),
                    Content = Convert.ToString(reader["BlogContent"]),
                    Author = Convert.ToString(reader["BlogAuthor"]),
                    DeleteFlag = Convert.ToBoolean(reader["BlogId"]),

                };
                lst.Add(item);
                
            }
            connection.Close();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {

            return Ok(new BlogViewModel { Id = id });
        }
        ////[HttpPost("{id}")]
        //public IActionResult CreateBlog(TblBlog blog)
        //{


        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateBlog(int id, TblBlog blog)
        //{

        //}

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogViewModel blog)
        {
            string conditions = "";
            if(!string.IsNullOrEmpty(blog.Title))
            {
                conditions += " [BlogTitle]=@BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                conditions += " [BlogAuthor]=@BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                conditions += " [BlogContent]=@BlogContent, ";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("Invalid parameter");
            }

            conditions=conditions.Substring(0,conditions.Length-2);

            SqlConnection connection=new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId=@BlogId";
            SqlCommand cmd=new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if(!string.IsNullOrEmpty(blog.Title))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.Title);
            }
            if (!string.IsNullOrEmpty(blog.Author))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.Author);
            }
            if (!string.IsNullOrEmpty(blog.Content))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.Content);

            }

            int result= cmd.ExecuteNonQuery();
            connection.Close();
            return Ok(result>0? "Updating succesful":"Updating failed.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
          

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET [DeleteFlag] = 1
            WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();


            Console.WriteLine(result == 1 ? "Deleting successfuly." : "Deleting failed.");
            connection.Close();
            return Ok(result);
        }
    }
}
