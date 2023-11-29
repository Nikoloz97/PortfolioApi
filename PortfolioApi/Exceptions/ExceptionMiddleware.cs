using Newtonsoft.Json;
using System.Net;

namespace PortfolioApi.Exceptions
{
    public class ExceptionMiddleware
    {
        // _next = represents the next middleware in the chain (i.e. according to program.cs -> app.UseHttpsRedirection()) 
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Essentially calling app.UseHttpsRedirection() here
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = exception switch
            {
                UsernameNotFoundException _ => new
                {
                    error = new
                    {
                        topic = "Invalid Credentials",
                        message = "The username entered does not exist. Please try again"
                    }
                },
                PasswordNotFoundException _ => new
                {
                    error = new
                    {
                        topic = "Invalid Credentials",
                        message = "The password for username entered does not exist. Please try again"
                    }
                },
                _ => new
                {
                    error = new
                    {
                        topic = "Error",
                        message = exception.Message
                    }
                },
            };

            var result = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(result);
        }
    }

}
