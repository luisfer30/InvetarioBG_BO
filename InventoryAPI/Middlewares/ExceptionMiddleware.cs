using InventoryModels;
using InventoryRepository.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception) 
        { 
            var statusCode = exception switch 
            { 
                NotFoundException => StatusCodes.Status404NotFound, 
                ValidationException => StatusCodes.Status400BadRequest, 
                _ => StatusCodes.Status500InternalServerError 
            }; 
            _logger.LogError(exception, "Excepción no controlada. Path: {Path}, TraceId: {TraceId}", context.Request.Path, context.TraceIdentifier); 
            var response = new Response<ErrorModel> 
            { 
                Success = false,  
                Message = statusCode == 500 ? "Ocurrió un error interno en el servidor." : exception.Message, 
                Data = new ErrorModel
                {
                    StatusCode = statusCode,
                    TraceId = context.TraceIdentifier
                }                 
            }; 
            context.Response.StatusCode = statusCode; 
            context.Response.ContentType = "application/json"; 
            await context.Response.WriteAsJsonAsync(response); 
        }
    }
}
