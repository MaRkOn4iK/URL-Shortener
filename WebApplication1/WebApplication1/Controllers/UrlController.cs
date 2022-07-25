using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;
        private readonly IUserService _userService;
        public UrlController(IUrlService urlService, IUserService userService)
        {
            _urlService = urlService;
            _userService = userService;
        }

        [HttpGet("GetUrls/{username}")]
        public async Task<IActionResult> UrlTable(string username)
        {
            try
            {

                string? role = await _userService.GetRolesByEmail(username);
                IEnumerable<Models.Entities.UrlModel>? urls = _urlService.GetAllUrls();
                return Ok(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("CreateUrl/{username}")]

        public async Task<IActionResult> CreateUrl(string username, [FromBody] EmptyUrlModel url)
        {
            try
            {

                await _urlService.AddNewUrl(url.url, await _userService.GetIdByEmail(username));


                string? role = await _userService.GetRolesByEmail(username);
                IEnumerable<Models.Entities.UrlModel>? urls = _urlService.GetAllUrls();
                return Ok(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteUrl/{username}/{urlId}")]
        public async Task<IActionResult> DeleteUrl(string username, int urlId)
        {
            try
            {
                await _urlService.DeleteUrl(urlId);


                string? role = await _userService.GetRolesByEmail(username);
                IEnumerable<Models.Entities.UrlModel>? urls = _urlService.GetAllUrls();
                return Ok(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Redirect/{shortUrl}")]
        public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
        {
            try
            {
                IEnumerable<Models.Entities.UrlModel>? urls = _urlService.GetAllUrls();
                foreach (var item in urls)
                {
                    if (@"https://localhost:44347/api/Url/Redirect/" + shortUrl == item.ShortUrl)
                    {
                      return  Redirect(item.LongUrl);
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
