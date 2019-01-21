using Abp.Dependency;
using Hangfire;
using NetCore.Module.Post;
using NetCore.Module.Post.Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.BackgroundJobs
{
	public class MyAppBackgroundJob
	{
		public static void RegisterBackgroundJobs()
		{
			//Configure job
			var postService = IocManager.Instance.Resolve<IPostAppService>();
            //var commentService = IocManager.Instance.Resolve<ICommentAppService>();

            //3 giờ 1 lần
            RecurringJob.AddOrUpdate("TestJob", ()
				=> (new TestJob(postService)).Execute(0), "*/1 * * * *", TimeZoneInfo.Local);

            //RecurringJob.AddOrUpdate("TestEmail", () => (new TestEmail(commentService)).Execute(0), "* * * * *", TimeZoneInfo.Local);
        }
	}
}
