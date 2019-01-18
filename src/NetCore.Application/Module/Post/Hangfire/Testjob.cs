using Abp.BackgroundJobs;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Module.Post.Hangfire
{
    public class TestJob : BackgroundJob<int>
    {
        private readonly IPostAppService _postAppService;
        public TestJob(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        public override void Execute(int args)
        {
            _postAppService.GetAll();
        }
    }
}
