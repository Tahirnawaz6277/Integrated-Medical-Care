using System.Net;

namespace imc_web_api.middle
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //string errorMessage;
                //int statusCode;

                //switch (ex)
                //{
                //    case   NotFoundException:
                //        errorMessage = "Resource not found.";
                //        statusCode = (int)HttpStatusCode.NotFound;
                //        break;

                //    case ValidationException validationException:
                //        errorMessage = "Validation failed.";
                //        statusCode = (int)HttpStatusCode.BadRequest;

                //        break;

                //    default:
                //        errorMessage = "Something went wrong.";
                //        statusCode = (int)HttpStatusCode.InternalServerError;
                //        break;
                //}

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync($"Something Went Wrong");
            }
        }
    }
}