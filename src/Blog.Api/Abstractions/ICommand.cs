using Blog.Api.Models.Shared;
using MediatR;

namespace Blog.Api.Abstractions;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}