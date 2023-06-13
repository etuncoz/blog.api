using Blog.Api.Commands;
using Blog.Api.Data;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Models.Shared;
using Blog.Api.Queries;
using Blog.Api.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPostsQuery();
        Result<PostModel[]> result = await _mediator.Send(query);
        return result.IsSuccess ? 
            Ok(result.Value) : 
            NotFound(result.Error);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var query = new GetPostByIdQuery(id);
        Result<PostModel> result = await _mediator.Send(query);
        return result.IsSuccess ?
            Ok(result.Value) : 
            NotFound(result.Error);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(id, request.ToDomain());
        var result = await _mediator.Send(command);
        return result.IsSuccess ? 
            Ok() :
            BadRequest(result.Error);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
    {
        var command = new CreatePostCommand(request.ToDomain());
        var result = await _mediator.Send(command);
        return result.IsSuccess ? 
            Ok() :
            BadRequest(result.Error);
    }
}