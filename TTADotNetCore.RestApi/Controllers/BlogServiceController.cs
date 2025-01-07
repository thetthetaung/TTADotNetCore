using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTADotNetCore.Database.Models;
using TTADotNetCore.Domain.Features.Blog;

namespace TTADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogServiceController : ControllerBase
    {
        public readonly IBlogService _service;

        public BlogServiceController(IBlogService service)
        {
            _service = service;
        }

        //public BlogServiceController()
        //{
        //    _service = new BlogService();
        //}
        [HttpGet]
        public ActionResult GetBlogs()
        {
            var lst=_service.GetBlogs();
            return Ok(lst);
        }
        [HttpPost("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item=_service.GetById(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreatePost(TblBlog blog)
        {
            var model=_service.CreateBlog(blog);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,TblBlog blog)
        {
            var item=_service.UpdateBlog(id,blog);
            if(item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPatch("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item=_service.DeleteBlog(id);
            if(item is false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
