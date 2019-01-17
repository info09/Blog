using Microsoft.AspNetCore.Mvc;
using NetCore.Module.Post;
using NetCore.Module.Post.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Controllers
{
    [Route("api/Post")]
    public class PostController:NetCoreControllerBase
    {
        private readonly IPostAppService _postAppService;

        public PostController(IPostAppService postAppService)
        {
            this._postAppService = postAppService;
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll(PostFilter filter)
        {
            var post = _postAppService.GetAll(filter);
            return Ok(post);
        }

        [HttpGet,Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postAppService.GetById(id);
            return Ok(post);
        }

        [HttpPost,Route("Create")]
        public IActionResult Create([FromBody]PostCreate input)
        {
            var post = _postAppService.Create(input);
            return Ok("Tạo thành công");
        }

        [HttpPut,Route("Update")]
        public IActionResult Update([FromBody]PostUpdate input)
        {
            var post = _postAppService.Update(input);
            return Ok("Thành công");
        }

        [HttpDelete,Route("Delete")]
        public IActionResult Delete(int id)
        {
            var post = _postAppService.Delete(id);
            return Ok("Thành công");
        }
    }
}
