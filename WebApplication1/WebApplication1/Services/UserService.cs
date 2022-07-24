using Microsoft.AspNetCore.Identity;
using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;
using WebApplication1.Validation;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetIdByEmail(string email)
        {
            try
            {

                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                return user.Id;

            }
            catch (Exception ex)
            {
                throw new UserException(ex.Message);
            }
        }

        public async Task<string> GetRolesByEmail(string email)
        {
            try
            {

                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                IList<string>? role = await _userManager.GetRolesAsync(user);
                return role.FirstOrDefault();

            }
            catch (Exception)
            {
                return "guest";
            }
        }
    }
}
