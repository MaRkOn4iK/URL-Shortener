using WebApplication1.Models.Entities;

namespace WebApplication1.Models.ViewModels
{
    public class UrlListWithRoleModel
    {
        public IEnumerable<UrlModel> UrlModels { get; set; }
        public string CurrentRole { get; set; }
    }
}
