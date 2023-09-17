using Blog.Api.Models.Socials;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
public class SocialsController : ControllerBase
{
    [HttpGet(ApiEndpoints.V1.Socials.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var socials = new List<SocialModel>()
        {
            new(Guid.Empty, "GitHub", "https://github.com/etuncoz"),
            new(Guid.Empty, "Twitter", "https://twitter.com/etuncoz"),
            new(Guid.Empty, "Instagram", "https://instagram.com/etuncoz"),
        };

        return Ok(await Task.FromResult(socials));
    }
}