using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Saving_Easy.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new
            {
                StatusCode = context.Exception.Message,
                Message = context.Exception.Message
            };

            context.Result = new JsonResult(error) { StatusCode = 500 };
        }
    }
}
