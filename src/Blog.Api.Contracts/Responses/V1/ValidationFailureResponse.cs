namespace Blog.Api.Contracts.Responses.V1;

public class ValidationFailureResponse
{
    public IEnumerable<ValidationResponse> Errors { get; set; }
}

public class ValidationResponse 
{
    public required string PropertyName { get; init; }
    
    public required string Message { get; init; }
}