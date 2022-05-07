using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHanddlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHanddlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";
                var responseModel = ResponseDto<string>.Fail(error.Message, error.StackTrace);

                switch (error)
                {
                    case CustomException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }

           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHanddlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHanddlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHanddlerMiddleware>();
        }
    }
}
