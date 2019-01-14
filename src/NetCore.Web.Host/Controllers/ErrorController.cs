using System;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Abp.Events.Bus.Handlers;
using Abp.Events.Bus.Exceptions;
using Abp.UI;

namespace MyApp.Web.Host.Controllers
{
    public class ErrorController : AbpController, 
        IEventHandler<AbpHandledExceptionData>
    {
        private readonly IErrorInfoBuilder _errorInfoBuilder;

        public ErrorController(IErrorInfoBuilder errorInfoBuilder)
        {
            _errorInfoBuilder = errorInfoBuilder;
        }

        public void HandleEvent(AbpHandledExceptionData eventData)
        {
            if(eventData.Exception.Message== "Current user did not login to the application!")
            {
                //Trả về lỗi khi người dùng chưa đăng nhập: Unauthorized
                throw new UserFriendlyException(401, eventData.Exception.Message);
            }

            
            throw new UserFriendlyException(500, eventData.Exception.Message);
        }

        public ActionResult Index()
        {
            var exHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var exception = exHandlerFeature != null
                                ? exHandlerFeature.Error
                                : new Exception("Unhandled exception!");

            var code = 500;

            try
            {
                if (((dynamic)exception).Code != null)
                {
                    code = ((dynamic)exception).Code;
                    if (code == 0) code = 500;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            try
			{ 
                var errors = ((dynamic)exception).ValidationErrors;
				return StatusCode(code, new { message = exception.Message, errors, innerException = exception.InnerException, exception.StackTrace });
			}
			catch (Exception)
			{
                var message = exception.Message;
                if(message == "One or more errors occurred.")
                {
                    message = exception.InnerException.InnerException.Message;
                }

                return StatusCode(code, new { message = message, innerException = exception.InnerException });
			}

			//return View(
			//	"Error",
			//	new ErrorViewModel(
			//		_errorInfoBuilder.BuildForException(exception),
			//		exception
			//	)
			//);
		}
    }
}