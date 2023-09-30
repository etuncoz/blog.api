using Blog.Api.Contracts.Responses.V1;
using Blog.Application.Common.Validation;

namespace Blog.Api.Mapping;

public static class ValidationMapper
{
    public static ValidationFailureResponse MapToResponse(this ValidationFailed validationFailed)
    {
        var destination = new ValidationFailureResponse
        {
            Errors = validationFailed.Errors.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };

        return destination;
    }
}