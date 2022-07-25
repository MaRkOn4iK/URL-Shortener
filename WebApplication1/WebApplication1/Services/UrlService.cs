using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _alphabet;
        private readonly int _base;
        public UrlService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            _base = _alphabet.Length;
        }
        public async Task AddNewUrl(string fullUrl, string ApplicationUserId)
        {
            _unitOfWork.UrlModelRepository.Add(
                new UrlModel
                {
                    ApplicationUserId = ApplicationUserId,
                    LongUrl = fullUrl,
                    ShortUrl = @"https://localhost:44347/api/Url/Redirect/" + Encode(fullUrl).ToString()
                }
                );
            await _unitOfWork.SaveAsync();

        }

        // This method can decode int value(shortLink) back to string 
        /*private string Decode(int i)
        {
            if (i == 0)
            {
                return _alphabet[0].ToString();
            }

            string? s = string.Empty;

            while (i > 0)
            {
                s += _alphabet[i % _base];
                i /= _base;
            }

            return string.Join(string.Empty, s.Reverse());
        }*/

        /// <summary>
        /// This method from internet like a real link shortener alghorithm
        /// </summary>
        /// <param name="s">string for encoding</param>
        /// <returns>encoded int value(shortLink)</returns>
        private int Encode(string s)
        {
            int i = 0;

            foreach (char c in s)
            {
                i = (i * _base) + _alphabet.IndexOf(c);
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
