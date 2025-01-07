using Microsoft.AspNetCore.Mvc;
using TTADotNetCore.CoreMVCApp.Models;
using TTADotNetCore.Database.Models;
using TTADotNetCore.Domain.Features.Blog;

namespace TTADotNetCore.CoreMVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var lst=_blogService.GetBlogs();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogRequestModel requestModel)
        {
            try
            {
                _blogService.CreateBlog(new TblBlog
                {
                    BlogAuthor = requestModel.Author,
                    BlogTitle = requestModel.Title,
                    BlogContent = requestModel.Content
                });
                
                //ViewBag.IsSuccess=true;
                //ViewBag.Message = "Blog Created Successfully!";

                TempData["IsSuccess"]=true;
                TempData["Message"] = "Blog Created Successfully!";
            }
            catch (Exception ex)
            {
                //ViewBag.IsSuccess=false;
                //ViewBag.Message = ex.ToString();

                TempData["IsSuccess"]=false;
                TempData["Message"] = ex.ToString();
                throw;
            }

            return RedirectToAction("Index");

            /*
            var lst=_blogService.GetBlogs();
            return View("Index",lst);
             * */

        }

        //public IActionResult BlogDelete(int blogId)
        //{
        //    _blogService.DeleteBlog(blogId);
        //    return RedirectToAction("Index");
        //}

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }
        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.GetById(id);
            BlogRequestModel blodRequestModel = new BlogRequestModel
            {
                Id=blog.BlogId,
                Author=blog.BlogAuthor,
                Title=blog.BlogTitle,
                Content=blog.BlogContent,
            };
            return View("BlogEdit",blog);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogRequestModel requestModel)
        {
            try
            {
                _blogService.UpdateBlog(id,new TblBlog
                {
                    BlogAuthor = requestModel.Author,
                    BlogTitle = requestModel.Title,
                    BlogContent = requestModel.Content
                });

                //ViewBag.IsSuccess=true;
                //ViewBag.Message = "Blog Created Successfully!";

                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog Updated Successfully!";
            }
            catch (Exception ex)
            {
                //ViewBag.IsSuccess=false;
                //ViewBag.Message = ex.ToString();

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
                throw;
            }

            return RedirectToAction("Index");

            /*
            var lst=_blogService.GetBlogs();
            return View("Index",lst);
             * */

        }
    }
}
