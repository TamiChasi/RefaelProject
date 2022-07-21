namespace Application.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandlerErrorsMiddleware
    {
        private RequestDelegate _next;
        private ILogger<HandlerErrorsMiddleware> _ILogger;

        public HandlerErrorsMiddleware(RequestDelegate next, ILogger<HandlerErrorsMiddleware> ILogger)
        {
            _next = next;
            _ILogger = ILogger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                if (httpContext.Response.StatusCode > 400 && httpContext.Response.StatusCode < 500)
                {
                    throw new Exception("Not Found");
                }
            }
            catch (Exception ex)
            {
                _ILogger.Log(LogLevel.Error, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandlerErrorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandlerErrorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandlerErrorsMiddleware>();
        }
    }
}