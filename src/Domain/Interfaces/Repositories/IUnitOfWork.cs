using System.Threading.Tasks;

namespace CDNConverter.API.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
