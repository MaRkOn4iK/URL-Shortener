using WebApplication1.Models.Entities;

namespace WebApplication1.Interfaces
{
    public interface IUrlService
    {
        IEnumerable<UrlModel> GetAllUrls();
        Task AddNewUrl(string fullUrl,int ApplicationUserId);
        Task DeleteUrl(string fullUrl);
    }
}
