﻿using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TTADotNetCore.ConsoleApp3
{
    public interface IBlogApi
    {
        [Get("/api/blogs")]
        Task<List<BlogModel>> GetBlogs();
        Task<BlogModel> GetBlog(int id);
    }

    public class BlogModel
    {
        public int BlogId { get; set; }

        public string BlogTitle { get; set; } = null!;

        public string BlogAuthor { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public bool DeleteFlag { get; set; }
    }

}
