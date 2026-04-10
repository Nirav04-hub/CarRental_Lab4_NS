
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NS_CarRental.GlobalException
{
    public class NS_GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NS_GlobalExceptionMiddleware> _logger;
        public NS_GlobalExceptionMiddleware(RequestDelegate next, ILogger<NS_GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception for {Method} {Path}",
                context.Request?.Method, context.Request?.Path);
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsJsonAsync(new
                    {
                        error = "ServerError",
                        message = "An unexpected error occurred."
                    });
                }
            }
        }
    }
}
