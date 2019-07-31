using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace CoreAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly MyAppSettings _appSettings;
        IHostingEnvironment _env;

        public CustomExceptionFilter(IOptions<MyAppSettings> appSettings, IHostingEnvironment env): base()
        {
            _appSettings = appSettings.Value;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var errorResponse = new ErrorResponseMessage()
            {
                Message = context.Exception.Message,
                FriendlyMessage = "## Error Found - CustomExceptionFilter ##"
            };

            if(!_env.IsProduction())
            {
                errorResponse.StackTrace = context.Exception.StackTrace;
            }

            context.Result = new ObjectResult(errorResponse);
            
        }
    }
}
