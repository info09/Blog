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

        CommentDto GetById(int id);

        List<CommentDto> GetByPostId(int id);

        Task Create(CommentCreate input);

        Task Update(CommentUpdate input);

        Task Delete(int id);

        //void Assign();
    }
}
