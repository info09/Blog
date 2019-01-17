using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using NetCore.Module.Comment.Dto;
using NetCore.Module.Comment.Event;

namespace NetCore.Module.Comment
{
    public class CommentAppService : NetCoreAppServiceBase, ICommentAppService
    {
        private readonly IRepository<Models.Comment> _commentRepository;
        public IEventBus eventBus;

        public CommentAppService(IRepository<Models.Comment> commentRepository)
        {
            this._commentRepository = commentRepository;
            eventBus = NullEventBus.Instance;
        }

        public async Task Create(CommentCreate input)
        {
            var comment = input.MapTo<Models.Comment>();
            comment.Status = true;
            await _commentRepository.InsertAsync(comment);
            eventBus.Trigger(new CommentCompletedEventData { Id = 2 });
        }

        public async Task Delete(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public List<CommentDto> GetAll(CommentFilter filter)
        {
            var comment = _commentRepository.GetAll();

            if (filter.PostId != null)
            {
                comment = comment.Where(i => i.PostId == filter.PostId);
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                comment = comment.Where(i => i.Content.Contains(filter.Search));
            }

            var output= comment.Skip(filter.pageSize.Value * (filter.pageNum.Value - 1)).Take(filter.pageSize.Value);
            return output.MapTo<List<CommentDto>>();
        }

        public async Task<CommentDto> GetById(int id)
        {
            var comment = await _commentRepository.FirstOrDefaultAsync(id);
            return comment.MapTo<CommentDto>();
        }

        public List<CommentDto> GetByPostId(int id)
        {
            var post = _commentRepository.GetAll().Where(i => i.PostId == id);
            return post.MapTo<List<CommentDto>>();
        }

        public async Task Update(CommentUpdate input)
        {
            var post = input.MapTo<Models.Comment>();
            post.Status = true;
            await _commentRepository.UpdateAsync(post);
        }
    }
}
