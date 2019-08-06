using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoreAPI.Middlewares
{
    public class MyLoggerMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger _logger;

        public MyLoggerMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("MyLoggerMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("################MyLoggerMiddleware executing....##############");

            //await _next(httpContext);

            //Log the response

            var bodyStream = httpContext.Response.Body;
            var responseBodyStream = new MemoryStream();
            httpContext.Response.Body = responseBodyStream;

            await _next(httpContext); // calling next middleware
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = new StreamReader(responseBodyStream).ReadToEnd();

            var responseCode = httpContext.Response.StatusCode;
            var requestPath = httpContext.Request.Path;
            var requestMethod = httpContext.Request.Method;

            _logger.LogInformation($"@timestamp: {DateTime.Now}, @site:{"learn-dotnetcore"}, @level:info, @threadid: {Thread.CurrentThread.ManagedThreadId}, @message:logger middleware response - {responseBody}, requestURL : {requestPath}, requestpath: {requestPath} ");

            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(bodyStream);




        }
    }


    public static class MyLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyLoggerMiddleware>();
        }
    }
}
