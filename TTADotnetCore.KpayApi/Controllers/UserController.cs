using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTADotNetCore.Database.Models;
using TTADotNetCore.Domain.Features.Kpay;

namespace TTADotnetCore.KpayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService _service;
        public UserController()
        {  _service = new UserService(); }

        
        [HttpGet]
        public ActionResult GetUsers()
        {
            var lst = _service.GetUsers();
            return Ok(lst);
        }
        [HttpPost("{id}")]
        public IActionResult GetUser(int id)
        {
            var item = _service.GetById(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreatePost(TblUser user)
        {
            var model = _service.CreateUser(user);
            return Ok(model);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, TblUser user)
        {
            var item = _service.UpdateBlog(id, user);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPatch("{id}")]
        public IActionResult DeleteUesr(int id)
        {
            var item = _service.DeleteUser(id);
            if (item is false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
