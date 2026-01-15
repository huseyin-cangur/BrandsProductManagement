

using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetail : ProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; set; }


        public ValidationProblemDetail(IEnumerable<ValidationExceptionModel> errors)
        {
            Title = "Validation Error(s)";
            Detail = "One or more validation erros occured";
            Status = StatusCodes.Status400BadRequest;
            Type = "/probs/validation";
            Errors = errors;
        }

    }
}