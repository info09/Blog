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
    public class CommentController:NetCoreControllerBase
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

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var cmt = await _commentAppService.GetById(id);
            return Ok(cmt);
        }

        [HttpPost,Route("Create")]
        public IActionResult Create([FromBody]CommentCreate input)
        {
            var cmt = _commentAppService.Create(input);
            return Ok();
        }

        [HttpPut, Route("Update")]
        public IActionResult Update(CommentUpdate input)
        {
            var cmt = _commentAppService.Update(input);
            return Ok();
        }

        [HttpDelete,Route("Delete")]
        public IActionResult Delte(int id)
        {
            var cmt = _commentAppService.Delete(id);
            return Ok();
        }
    }
}
