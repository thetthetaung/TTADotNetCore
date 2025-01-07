﻿

using Microsoft.AspNetCore.Mvc;
using TTADotNetCore.Database.Models;

namespace TTDotNetCore.MinimalApi.Endpoints.Blog
{
    public static class BlogEndpoint
    {
        //public static string Test(this string i)
        //{
        //    return i.ToString();
        //}

        public static void UseBlogEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/blogs", ([FromServices] AppDbContext db) =>
            {
                //AppDbContext db = new AppDbContext();
                var model = db.TblBlogs.AsNoTracking().ToList();
                return Results.Ok(model);

            })
            .WithName("GetBlogs")
            .WithOpenApi();

            app.MapGet("/blogs/{id}", ([FromServices] AppDbContext db,int id) =>
            {
                //AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is not null)
                {
                    return Results.BadRequest("No Data Found");
                }

                return Results.Ok(item);

            })
            .WithName("GetBlog")
            .WithOpenApi();

            app.MapPost("/blogs", ([FromServices] AppDbContext db,TblBlog blog) =>
            {
                //AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            })
            .WithName("CreateBlog")
            .WithOpenApi();

            app.MapPut("/blogs/{id}", ([FromServices] AppDbContext db,int id, TblBlog blog) =>
            {
                //AppDbContext db = new AppDbContext();
                var item = db.TblBlogs
                        .AsNoTracking()
                        .FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
                return Results.Ok(blog);
            })
            .WithName("UpdateBlog")
            .WithOpenApi();

            app.MapDelete("/blogs/{id}", ([FromServices] AppDbContext db,int id) =>
            {
                //AppDbContext db = new AppDbContext();
                var item = db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No Data found");
                }

                db.Entry(item).State = EntityState.Deleted;
                db.SaveChanges();
                return Results.Ok();
            })
            .WithName("DeleteBlog")
            .WithOpenApi();
        }
    }
}
