using Abp.Application.Services;
using NetCore.Module.Post.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Module.Post
{
    public interface IPostAppService:IApplicationService
    {
        List<PostDto> GetAll(PostFilter filter);
        Task<PostDto> GetById(int id);
        Task Create(PostCreate input);
        Task Update(PostUpdate input);
        Task Delete(int id);
    }
}
