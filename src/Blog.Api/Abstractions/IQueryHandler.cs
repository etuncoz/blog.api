using Blog.Api.Models.Shared;
using MediatR;

namespace Blog.Api.Abstractions;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}