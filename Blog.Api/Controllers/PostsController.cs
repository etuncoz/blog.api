using Blog.Api.Data;
using Blog.Api.Mapping;
using Blog.Api.Models.Posts;
using Blog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/v1/posts")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postRepository.GetPostsAsync();

        var postModels = posts.Select(p => p.ToModel());
        
        return Ok(postModels);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        
        var postModel = post.ToModel();
        
        return Ok(postModel);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdatePostRequest request)
    {
        var post = request.ToDomain();

        if (post is null)
            return BadRequest();
        
        await _postRepository.UpdatePostAsync(id, post);
        return Ok();
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody]CreatePostRequest request)
    {
        var post = request.ToDomain();

        if (post is null)
            return BadRequest();
        
        await _postRepository.AddPostAsync(post);
        return Ok();
    }
}