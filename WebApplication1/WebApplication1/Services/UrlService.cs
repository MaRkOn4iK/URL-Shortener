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
        public async Task AddNewUrl(string fullUrl, string ApplicationUserId)
        {
            _unitOfWork.UrlModelRepository.Add(
                new UrlModel
                {
                    ApplicationUserId = ApplicationUserId,
                    LongUrl = fullUrl,
                    ShortUrl = fullUrl
                }
                );
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteUrl(int id)
        {
            _unitOfWork.UrlModelRepository.DeleteById(id);
            await _unitOfWork.SaveAsync();
        }

        public IEnumerable<UrlModel> GetAllUrls()
        {
            return _unitOfWork.UrlModelRepository.GetAll();
        }
    }
}
