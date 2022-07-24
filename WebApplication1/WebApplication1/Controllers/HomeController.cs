using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;
        private IAboutPageService _aboutPageService;
        public HomeController(IUserService userService, IAboutPageService aboutPageService)
        {
            _userService = userService;
            _aboutPageService = aboutPageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
            var text = _aboutPageService.GetAboutText();
            var role = await _userService.GetRolesByEmail(this.User.Identity.Name);
            return View(new AboutModel { RoleName = role, AboutText = text});
        }

        public async Task<IActionResult> AboutChange(string TxtArea)
        {
            _aboutPageService.SetAboutText(TxtArea);

            var textFromfile = _aboutPageService.GetAboutText();
            var role = await _userService.GetRolesByEmail(this.User.Identity.Name);
            return View("About", new AboutModel { RoleName = role, AboutText = textFromfile });
        }
        public async Task<IActionResult> UrlTable()
        {
            return Redirect($@"http://localhost:4200/?name={this.User.Identity.Name}");
        }
    }
}
