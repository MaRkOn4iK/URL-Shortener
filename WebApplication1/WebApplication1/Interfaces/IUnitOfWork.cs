namespace WebApplication1.Interfaces
{
    public interface IUnitOfWork
    {
        IUrlModelRepository UrlModelRepository { get; }
        Task SaveAsync();
    }
}
