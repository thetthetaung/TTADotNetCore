﻿using Microsoft.AspNetCore.Mvc;
using TTADotNetCore.CoreMVCApp.Models;
using TTADotNetCore.Database.Models;
using TTADotNetCore.Domain.Features.Blog;

namespace TTADotNetCore.CoreMVCApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogAjaxController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        // CRUD
        // Read
        [ActionName("Index")]
        public IActionResult BlogList()
        {
            var lst=_blogService.GetBlogs();
            return View("BlogList",lst);
        }

        [ActionName("List")]
        public IActionResult BlogListAjax()
        {
            var lst = _blogService.GetBlogs();
            return Json(lst);
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
            MessageModel model;
            try
            {
                _blogService.CreateBlog(new TblBlog
                {
                    BlogAuthor = requestModel.Author,
                    BlogTitle = requestModel.Title,
                    BlogContent = requestModel.Content
                });
                
                TempData["IsSuccess"]=true;
                TempData["Message"] = "Blog Created Successfully!";

                model = new MessageModel(true,"Blog Ajax successfully created!");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"]=false;
                TempData["Message"] = ex.ToString();

                model=new MessageModel(false,ex.ToString());
                //throw;
            }
            return Json(model);

        }

        public class MessageModel
        {
            public MessageModel() { }
            public MessageModel(bool isSuccess, string message)
            {
                IsSuccess = isSuccess;
                Message = message;
            }

            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult BlogDelete(BlogRequestModel requestModel)
        {
            MessageModel model;

            try
            {
                _blogService.DeleteBlog(requestModel.Id);
                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog deleted Successfully!";

                model = new MessageModel(true, "Blog Ajax successfully deleted!");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();

                model = new MessageModel(false, ex.ToString());
                //throw;
            }
            return Json(model);
        }

        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var blog = _blogService.GetById(id);
            BlogRequestModel blogRequestModel = new BlogRequestModel
            {
                Id=blog.BlogId,
                Author=blog.BlogAuthor,
                Title=blog.BlogTitle,
                Content=blog.BlogContent,
            };
            return View("BlogEdit",blogRequestModel);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id,BlogRequestModel requestModel)
        {
            MessageModel model;

            try
            {
                _blogService.UpdateBlog(id,new TblBlog
                {
                    BlogAuthor = requestModel.Author,
                    BlogTitle = requestModel.Title,
                    BlogContent = requestModel.Content
                });

                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog Updated Successfully!";

                model = new MessageModel(true, "Blog Ajax successfully updated!");
            }
            catch (Exception ex)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();

                model = new MessageModel(false, ex.ToString());
                //throw;
            }
            return Json(model);


        }
    }
}
