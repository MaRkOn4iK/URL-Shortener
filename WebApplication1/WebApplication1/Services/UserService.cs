using Microsoft.AspNetCore.Identity;
using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> GetRolesByEmail(string email)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(email);
                var role = await _userManager.GetRolesAsync(user);
                return role.FirstOrDefault();

            }
            catch (Exception)
            {
                return "guest";
            }
        }
    }
}
