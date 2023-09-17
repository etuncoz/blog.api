using Blog.Api.Data;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet(ApiEndpoints.V1.Posts.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postRepository.GetPostsAsync();

        var postModels = posts.Select(p => p.MapToModel());
        
        return Ok(postModels);
    }
    
    [HttpGet(ApiEndpoints.V1.Posts.Get)]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        
        var postModel = post.MapToModel();
        
        return Ok(postModel);
    }
    
    [HttpPut(ApiEndpoints.V1.Posts.Update)]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdatePostRequest request)
    {
        var post = request.MapToDomain();

        if (post is null)
            return BadRequest();
        
        await _postRepository.UpdatePostAsync(id, post);
        return Ok();
    }
    
    [HttpPost(ApiEndpoints.V1.Posts.Create)]
    public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
    {
        var post = request.MapToDomain();

        if (post is null)
            return BadRequest();
        
        await _postRepository.AddPostAsync(post);
        return Ok();
    }
}