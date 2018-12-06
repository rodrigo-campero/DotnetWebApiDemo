using DotnetWebApiDemo.Domain.Interfaces;
using System.Threading.Tasks;

namespace DotnetWebApiDemo.Domain.Services
{
    public class Service
    {
        private readonly IUnitOfWork _uow;

        public Service(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _uow.CommitAsync();
        }
    }
}
