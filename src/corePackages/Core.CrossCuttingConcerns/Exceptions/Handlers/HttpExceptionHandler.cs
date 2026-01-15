

using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;

        public HttpResponse httpResponse
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        protected override Task HandleException(BusinessException businessException)
        {
            httpResponse.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return httpResponse.WriteAsync(details);
        }

        protected override Task HandleException(Exception businessException)
        {
            httpResponse.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerProblemDetails(businessException.Message).AsJson();
            return httpResponse.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            httpResponse.StatusCode = StatusCodes.Status400BadRequest;
            string details = new ValidationProblemDetail(validationException.Errors).AsJson();
            return httpResponse.WriteAsync(details);
        }
    }
}