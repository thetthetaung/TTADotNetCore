using Microsoft.EntityFrameworkCore;
using TTADotNetCore.Database.Models;

namespace TTADotNetCore.Domain.Features.Blog
{
    public class BlogV2Service:IBlogService
    {
        //private readonly AppDbContext _db = new AppDbContext();

        private readonly AppDbContext _db;
        private readonly IBlogService _blogService;

        public BlogV2Service(AppDbContext db, IBlogService blogService)
        {
            _db = db;
            _blogService = blogService;
        }

        public List<TblBlog> GetBlogs()
        {
            var model = _db.TblBlogs.AsNoTracking().ToList();
            return model;
        }

        public TblBlog CreateBlog(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
            return blog;
        }

        public TblBlog GetById(int id)
        {
            var item = _db.TblBlogs
                    .AsNoTracking()
                    .FirstOrDefault(x => x.BlogId == id);

            return item;
        }

        public TblBlog UpdateBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return null;
            }
            item.BlogId = blog.BlogId;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return item;
        }

        public bool DeleteBlog(int id)
        {
            var item = _db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return false;
            }
            _db.Entry(item).State = EntityState.Deleted;
            int result = _db.SaveChanges();
            return result > 0;

        }
    }
}
