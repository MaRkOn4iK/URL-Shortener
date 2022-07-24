using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : Controller
    {
        private IUrlService _urlService;
        private IUserService _userService;
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

            var role = await _userService.GetRolesByEmail(username);
            var urls = _urlService.GetAllUrls();
            return Ok(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role});

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("CreateUrl/{username}/{url}")]
        public async Task<IActionResult> CreateUrl(string username, string url)
        {
            try
            {
                await _urlService.AddNewUrl(url, await _userService.GetIdByEmail(username));


                var role = await _userService.GetRolesByEmail(username);
                var urls = _urlService.GetAllUrls();
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


                var role = await _userService.GetRolesByEmail(username);
                var urls = _urlService.GetAllUrls();
                return Ok(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
