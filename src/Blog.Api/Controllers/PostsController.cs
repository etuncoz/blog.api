using Blog.Api.Contracts.Requests.V1.Post;
using Blog.Api.Contracts.Responses.V1;
using Blog.Api.Contracts.Responses.V1.Post;
using Blog.Api.Mapping;
using Blog.Application.Posts.CreatePost;
using Blog.Application.Posts.GetPost;
using Blog.Application.Posts.GetPosts;
using Blog.Application.Posts.UpdatePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

public class PostsController : BaseApiController
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiEndpoints.V1.Posts.GetAll)]
    [ProducesResponseType(typeof(PostsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllPostsQuery();
        var results = await _mediator.Send(query);

        var postModels = results.Select(p => p.MapToModel());
        
        return Ok(postModels);
    }
    
    [HttpGet(ApiEndpoints.V1.Posts.Get)]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var query = new GetPostByIdQuery(id);
        var result = await _mediator.Send(query);
        
        var postModel = result.MapToModel();

        return postModel is null ? NotFound() : Ok(postModel);
    }
    
    [HttpPut(ApiEndpoints.V1.Posts.Update)]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(id, request.Title, request.Description);

        await _mediator.Send(command);
        
        return Ok();
    }
    
    [HttpPost(ApiEndpoints.V1.Posts.Create)]
    [ProducesResponseType(typeof(PostResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
    {
        var command = new CreatePostCommand(request.Title, request.Description);

        var result = await _mediator.Send(command); 
        
        return CreatedAtAction(nameof(Get), new {id = result});
    }
}