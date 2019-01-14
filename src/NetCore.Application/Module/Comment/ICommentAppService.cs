using Abp.Application.Services;
using NetCore.Module.Comment.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Module.Comment
{
    public interface ICommentAppService:IApplicationService
    {
        List<CommentDto> GetAll(CommentFilter filter);
        Task<CommentDto> GetById(int id);
        Task Create(CommentCreate input);
        Task Update(CommentUpdate input);
        Task Delete(int id);
    }
}
