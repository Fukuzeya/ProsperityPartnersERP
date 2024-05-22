using Microsoft.AspNetCore.Diagnostics;
using ProsperityPartners.Domain.Contracts;
using ProsperityPartners.Domain.ErrorModel;
using ProsperityPartners.Domain.Exceptions;
using System.Net;

namespace ProsperityPartners.Presentation.API
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerManager _loggerManager;
        public GlobalExceptionHandler(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            
            var contextFeature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                httpContext.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };
                _loggerManager.LogError($"Something went wrong: {exception.Message}");
                await httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = contextFeature.Error.Message,
                }.ToString());
            }
            return true;
        }
    }
}
