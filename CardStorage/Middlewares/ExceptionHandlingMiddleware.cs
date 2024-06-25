using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace CardStorage.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (NotFoundException ex)
            {
                await HandleException(context, ex, HttpStatusCode.NotFound);
            }
            catch (BadRequestException ex)
            {
                await HandleException(context, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, HttpStatusCode.InternalServerError);
            }
        }
        private Task HandleException<T>(HttpContext context, T ex, HttpStatusCode statusCode) where T : Exception
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                errorMessage = ex.Message,
                sourse = ex.Source
            }));
        }
    }
}
