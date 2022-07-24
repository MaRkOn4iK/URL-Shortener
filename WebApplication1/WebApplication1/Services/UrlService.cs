using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUnitOfWork _unitOfWork;
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        public static readonly int Base = Alphabet.Length;
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
                    ShortUrl = Encode(fullUrl).ToString()
                }
                );
            await _unitOfWork.SaveAsync();

        }
        private string Decode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }
        private int Encode(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            return i;
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
