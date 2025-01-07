using TTADotNetCore.Database.Models;

namespace TTADotNetCore.Domain.Features.Blog
{
    public interface IBlogV2Service
    {
        TblBlog CreateBlog(TblBlog blog);
        bool DeleteBlog(int id);
        List<TblBlog> GetBlogs();
        TblBlog GetById(int id);
        TblBlog UpdateBlog(int id, TblBlog blog);
    }
}