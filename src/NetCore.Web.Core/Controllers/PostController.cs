using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using NetCore.Module.Comment;
using NetCore.Module.Post;
using NetCore.Module.Post.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [Route("api/Post")]
    public class PostController : NetCoreControllerBase
    {
        private readonly IPostAppService _postAppService;
        private readonly ICommentAppService _commentAppService;

        public PostController(IPostAppService postAppService, ICommentAppService commentAppService)
        {
            this._postAppService = postAppService;
            this._commentAppService = commentAppService;
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll(PostFilter filter)
        {
            var post = _postAppService.GetAll(filter);
            return Ok(post);
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int id)
        {
            var post = _postAppService.GetById(id);
            if (post == null)
            {
                throw new Exception("Không tồn tại id= " + id + " trong cơ sở dữ liệu");
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpPost, Route("Create")]
        public IActionResult Create([FromBody]PostCreate input)
        {
            var post = _postAppService.Create(input);
            return Ok("Tạo thành công");
        }

        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody]PostUpdate input)
        {
            var a = _postAppService.GetById(input.Id);
            if (a == null)
            {
                throw new Exception("Không tồn tại Post để update");
            }
            else
            {
                var post = _postAppService.Update(input);
                return Ok("Thành công");
            }

        }

        [HttpDelete, Route("Delete")]
        public IActionResult Delete(int id)
        {
            var cmt = _commentAppService.GetByPostId(id);
            if (_postAppService.GetById(id) == null)
            {
                throw new Exception("Không tồn tại Id");
            }
            else
            {
                if (cmt == null)
                {
                    var post = _postAppService.Delete(id);
                    return Ok();
                }
                else
                {
                    throw new Exception("PosId bên bảng comment tồn tại");
                }
            }
        }
    }
}
