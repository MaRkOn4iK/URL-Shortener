using WebApplication1.Interfaces;
using WebApplication1.Models.Entities;

namespace WebApplication1.Data.Repository
{
    public class UrlModelRepository : IUrlModelRepository
    {
        private readonly ApplicationDbContext context;
        public UrlModelRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(UrlModel entity)
        {
            _ = context.UrlModels.Add(entity);
        }

        public void DeleteById(int id)
        {
            try
            {
                UrlModel? tmp = context.UrlModels.FirstOrDefault(c => c.Id == id);
                if (tmp != null)
                {
                    _ = context.UrlModels.Remove(tmp);
                }
            }
            catch (Exception)
            {

            }

        }

        public IEnumerable<UrlModel> GetAll()
        {
            return context.UrlModels;
        }
    }
}
