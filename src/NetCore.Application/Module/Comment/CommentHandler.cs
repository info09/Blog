using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Net.Mail;
using NetCore.Models;
using NetCore.Module.Comment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Module.Comment
{
    public class CommentHandler : IEventHandler<EntityDeletedEventData<Models.Comment>>, 
                                    ITransientDependency, 
                                    IDomainService
    {
        private readonly IRepository<Models.Comment> _commentRepository;

        public CommentHandler(IRepository<Models.Comment> commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        public void HandleEvent(EntityDeletedEventData<Models.Comment> eventData)
        {
            if (eventData.Entity.PostId == 1)
            {
                _commentRepository.Insert(new Models.Comment
                {
                    PostId = 1,
                    Content = eventData.Entity.Content,
                    Status = true
                });
            }

            
        }
    }
}
