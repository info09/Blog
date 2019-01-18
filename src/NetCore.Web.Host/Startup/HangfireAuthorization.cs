using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MyApp.Web.Host.Startup
{
    public class HangfireAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            var task = httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            task.Wait();
            var result= task.Result;

            return result.Principal.IsInRole("Admin");
        }
    }
}
