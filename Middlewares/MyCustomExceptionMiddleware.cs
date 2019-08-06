using System.IO;
using System.Net;
using CoreAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoreAPI.Middlewares
{
    public static class MyCustomExceptionMiddleware
    {
        public static void UseMyCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var errorResponse = new ErrorResponseMessage()
                    {
                        Message = contextFeature.Error.Message,
                        FriendlyMessage = "## Error From Middleware MyCustomExceptionMiddleware ##",
                        StackTrace = contextFeature.Error.StackTrace
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
               });
            });
        }
    }
}
