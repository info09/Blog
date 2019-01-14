using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Comment.Event
{
    public class CommentCompletedEventData:EventData
    {
        public int Id { get; set; }
    }
}
