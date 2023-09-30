using Blog.Api.Contracts.Responses.V1.Social;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
public class SocialsController : ControllerBase
{
    [HttpGet(ApiEndpoints.V1.Socials.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var socials = new List<SocialResponse>()
        {
            new SocialResponse {Id = Guid.Empty, Name = "GitHub", Url = "https://github.com/etuncoz"},
            new SocialResponse {Id = Guid.Empty, Name = "Twitter", Url = "https://twitter.com/etuncoz"},
            new SocialResponse {Id = Guid.Empty, Name = "Instagram", Url = "https://instagram.com/etuncoz"}
        };

        return Ok(await Task.FromResult(socials));
    }
}