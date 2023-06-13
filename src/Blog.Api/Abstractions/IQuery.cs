using Blog.Api.Models.Shared;
using MediatR;

namespace Blog.Api.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}