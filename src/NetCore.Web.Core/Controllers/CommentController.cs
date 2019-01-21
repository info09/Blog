using Microsoft.AspNetCore.Mvc;
using NetCore.Module.Comment;
using NetCore.Module.Comment.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [Route("api/Comment")]
    public class CommentController : NetCoreControllerBase
    {
        private readonly ICommentAppService _commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            this._commentAppService = commentAppService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll(CommentFilter filter)
        {
            var cmt = _commentAppService.GetAll(filter);
            return Ok(cmt);
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int id)
        {
            var cmt = _commentAppService.GetById(id);
            if (cmt == null)
            {
                throw new Exception("Không có Id=" + id + " trong cơ sở dữ liệu");
            }
            else
            {
                return Ok(cmt);
            }
        }

        [HttpGet, Route("GetByPostId")]
        public IActionResult GetByPostId(int id)
        {
            var cmt = _commentAppService.GetByPostId(id);
            return Ok(cmt);
        }

        [HttpPost, Route("Create")]
        public IActionResult Create([FromBody]CommentCreate input)
        {
            var cmt = _commentAppService.Create(input);
            return Ok();
        }

        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody]CommentUpdate input)
        {
            var a = _commentAppService.GetById(input.Id);
            if (a == null)
            {
                throw new Exception("Không tồn tại comment để update");
            }
            else
            {
                var cmt = _commentAppService.Update(input);
                return Ok();
            }
        }

        [HttpDelete, Route("Delete")]
        public IActionResult Delte(int id)
        {
            if (_commentAppService.GetById(id) == null)
            {
                throw new Exception("Không tồn tại Id");
            }
            else
            {
                var cmt = _commentAppService.Delete(id);
                return Ok();
            }
        }
    }
}
