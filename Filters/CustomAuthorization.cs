using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace CoreAPI.Filters
{
    public class CustomAuthorization : ActionFilterAttribute
    {
        private readonly MyAppSettings _appSettings;

        public CustomAuthorization(IOptions<MyAppSettings> appSettings): base()
        {
            _appSettings = appSettings.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            bool isAuthorized = false;
            var authKeyName = "ApiKey";
            var allowedAuthKeys = _appSettings.ApiKey;

            var allowedKeysList = allowedAuthKeys.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if(headers.Keys.Contains(authKeyName) && allowedKeysList.Any())
            {
                var header = headers.FirstOrDefault(x => x.Key == authKeyName).Value.FirstOrDefault();
                if(header !=null)
                {
                    isAuthorized = Array.Exists(allowedKeysList, key => key.Equals(header));
                }
            }

            if (!isAuthorized)
            {
                context.Result = new ContentResult()
                {
                    Content = "## Authorization has beed denied. ##",
                    ContentType = "text/plain",
                    StatusCode = 401
                };

            }
        }
    }
}
