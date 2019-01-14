using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using NetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Comment
{
    public class CommentHandler : IEventHandler<EntityCreatedEventData<Models.Comment>>, ITransientDependency
    {
        public void HandleEvent(EntityCreatedEventData<Models.Comment> eventData)
        {
            throw new NotImplementedException();
        }
    }
}
