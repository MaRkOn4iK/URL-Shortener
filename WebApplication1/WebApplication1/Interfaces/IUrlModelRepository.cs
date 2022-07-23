using WebApplication1.Models.Entities;

namespace WebApplication1.Interfaces
{
    public interface IUrlModelRepository
    {
        IEnumerable<UrlModel> GetAll();
        void Add(UrlModel entity);
        void DeleteById(int id);
    }
}
