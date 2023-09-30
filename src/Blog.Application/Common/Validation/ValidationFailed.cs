using FluentValidation.Results;

namespace Blog.Application.Common.Validation;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
{
    public ValidationFailed(ValidationFailure error) : this(new[] { error })
    {
        
    }
}