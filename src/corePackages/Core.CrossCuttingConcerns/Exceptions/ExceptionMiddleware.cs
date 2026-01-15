
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _httpExceptionHandler = new HttpExceptionHandler();
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context.Response, ex);
            }
        }



        private Task HandleExceptionAsync(HttpResponse httpResponse, Exception exception)
        {
            httpResponse.ContentType = "application/json";
            _httpExceptionHandler.httpResponse = httpResponse;

            return _httpExceptionHandler.HandleExceptionAsync(exception);

        }


    }
}