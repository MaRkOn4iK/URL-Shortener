using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UrlModel> UrlModels { get; set; }
    }
}
