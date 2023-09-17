using Blog.Api.Data;
using Blog.Api.Features.Posts.CreatePost;
using Blog.Api.Features.Posts.GetPost;
using Blog.Api.Features.Posts.GetPosts;
using Blog.Api.Features.Posts.UpdatePost;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiEndpoints.V1.Posts.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPostsQuery();
        var results = await _mediator.Send(query);

        var postModels = results.Select(p => p.MapToModel());
        
        return Ok(postModels);
    }
    
    [HttpGet(ApiEndpoints.V1.Posts.Get)]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var query = new GetPostByIdQuery(id);
        var result = await _mediator.Send(query);
        
        var postModel = result.MapToModel();

        return postModel is null ? NotFound() : Ok(postModel);
    }
    
    [HttpPut(ApiEndpoints.V1.Posts.Update)]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(id, request.Title, request.Description);

        await _mediator.Send(command);
        
        return Ok();
    }
    
    [HttpPost(ApiEndpoints.V1.Posts.Create)]
    public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
    {
        var command = new CreatePostCommand(request.Title, request.Description);

        var result = await _mediator.Send(command); 
        
        return CreatedAtAction(nameof(Get), new {id = result});
    }
}