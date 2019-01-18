using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NetCore.Module.Post.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Module.Post
{
    public class PostAppService : ApplicationService, IPostAppService
    {
        private readonly IRepository<Models.Post> _postRepository;

        public PostAppService(IRepository<Models.Post> postRepository)
        {
            this._postRepository = postRepository;
        }

        public async Task Create(PostCreate input)
        {
            var post = input.MapTo<Models.Post>();
            await _postRepository.InsertAsync(post);
        }

        public async Task Delete(int id)
        {
            await _postRepository.DeleteAsync(id);
        }

        public List<PostDto> GetAll(PostFilter filter)
        {
            var posts = _postRepository.GetAll();

            if (filter.PostCategoryId != null)
            {
                posts = posts.Where(i => i.PostCategoryId == filter.PostCategoryId);
            }

            if (!string.IsNullOrEmpty(filter.Search))
            {
                posts = posts.Where(i => i.Title.Contains(filter.Search));
            }

            var output = posts.Include(i=>i.Comments).Skip(filter.pageSize.Value * (filter.pageNum.Value - 1)).Take(filter.pageSize.Value);
            return output.MapTo<List<PostDto>>();
        }

        public List<PostDto> GetAll()
        {
            var post = _postRepository.GetAll().ToList();
            return post.MapTo<List<PostDto>>();
        }

        public async Task<PostDto> GetById(int id)
        {
            var post = await _postRepository.GetAll().Include(i => i.Comments).FirstOrDefaultAsync(i => i.Id == id);
            return post.MapTo<PostDto>();
        }

        public async Task Update(PostUpdate input)
        {
            var post = input.MapTo<Models.Post>();
            await _postRepository.UpdateAsync(post);
        }
    }
}
