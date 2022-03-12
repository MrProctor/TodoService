using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Churchbooking.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                
                var result = JsonSerializer.Serialize(new { error.Message, error.StackTrace });
                _logger.LogError(error, "Todo list Error");
                
                await response.WriteAsync(result);
            }
        }
    }
}