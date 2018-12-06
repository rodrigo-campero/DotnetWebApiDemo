using System.Threading.Tasks;

namespace DotnetWebApiDemo.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        Task<int> CommitAsync();
    }
}