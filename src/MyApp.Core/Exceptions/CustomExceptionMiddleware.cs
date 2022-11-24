using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyApp.Exceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
                _logger.LogInformation($"Request: {context.Request.Method.ToUpper()} {context.Request.Path}, Status Code: {ex.StatusCode}, Message: {ex.Message}");
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
                _logger.LogError(exceptionObj.ToString());
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, CustomException exception)
        {
            string result;
            context.Response.ContentType = "application/json";
            if (exception is CustomException)
            {
                result = new ExceptionDetail
                {
                    Message = exception.Message,
                    StatusCode = exception.StatusCode,
                    Result = exception.Result
                }.ToString();
                context.Response.StatusCode = exception.StatusCode;
            }
            else
            {
                result = new ExceptionDetail
                {
                    Message = "Runtime Error",
                    StatusCode = (int)HttpStatusCode.BadRequest
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string result = new ExceptionDetail
            {
                Message = exception.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError
            }.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
