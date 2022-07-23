using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddNewUrl(string fullUrl, int ApplicationUserId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUrl(string fullUrl)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UrlModel> GetAllUrls()
        {
            return _unitOfWork.UrlModelRepository.GetAll();
        }
    }
}
