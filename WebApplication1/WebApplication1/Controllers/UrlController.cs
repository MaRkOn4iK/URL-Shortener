using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class UrlController : Controller
    {
        private IUrlService _urlService;
        private IUserService _userService;
        public UrlController(IUrlService urlService, IUserService userService)
        {
            _urlService = urlService;
            _userService = userService;
        }
        public async Task<IActionResult> UrlTable()
        {
            var role = await _userService.GetRolesByEmail(this.User.Identity.Name);
            var urls = _urlService.GetAllUrls();
            return View(new UrlListWithRoleModel { UrlModels = urls, CurrentRole = role});
        }
    }
}
