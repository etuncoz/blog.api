using Blog.Api.Data;
using Blog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class PostsController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostsController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet("posts")]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postRepository.GetPostsAsync();
        return Ok(posts);
    }
    
    [HttpGet("posts/{id}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        var post = await _postRepository.GetPostByIdAsync(id);
        return Ok(post);
    }
    
    [HttpPut("posts/{id}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]Post post)
    { 
        await _postRepository.UpdatePostAsync(id, post);
        return Ok();
    }
    
    [HttpPost("posts")]
    public async Task<IActionResult> Create([FromBody]Post post)
    {
        await _postRepository.AddPostAsync(post);
        return Ok();
    }
}