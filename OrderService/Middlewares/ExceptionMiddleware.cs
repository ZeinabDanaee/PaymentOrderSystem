using OrderService.Api.Models;
using OrderService.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace OrderService.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
             

                var response = ex switch
                {
                    ValidationException validationException =>
                        new ErrorResponse(
                            StatusCodes.Status400BadRequest,
                            validationException.Message,
                            validationException.Errors),

                    _ =>
                        new ErrorResponse(
                            StatusCodes.Status500InternalServerError,
                            "Internal Server Error")
                };

                context.Response.StatusCode = response.StatusCode;

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}