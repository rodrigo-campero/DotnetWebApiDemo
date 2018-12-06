using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Domain.Interfaces;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.Dapper;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.EF;
using DotnetWebApiDemo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotnetWebApiDemo.Domain.Services
{
    public class ClientService : Service, IClientService
    {
        private readonly IClientRepositoryEF _clientRepositoryEF;
        private readonly IClientRepositoryDapper _clientRepositoryDapper;

        public ClientService(IUnitOfWork uow, IClientRepositoryEF clientRepositoryEF, IClientRepositoryDapper clientRepositoryDapper) : base(uow)
        {
            _clientRepositoryEF = clientRepositoryEF;
            _clientRepositoryDapper = clientRepositoryDapper;
        }

        public Client Add(Client entity)
        {
            BeginTransaction();
            entity = _clientRepositoryEF.Add(entity);
            Commit();
            return entity;
        }

        public Client Update(Client entity)
        {
            BeginTransaction();
            entity = _clientRepositoryEF.Update(entity);
            Commit();
            return entity;
        }

        public void Remove(int id)
        {
            BeginTransaction();
            _clientRepositoryEF.Remove(_clientRepositoryEF.GetById(id));
            Commit();
        }

        public Client GetById(int id)
        {
            return _clientRepositoryDapper.GetById(id);
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate)
        {
            return _clientRepositoryEF.Search(predicate);
        }

        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate, int? pageNumber, int? pageSize)
        {
            return _clientRepositoryEF.Search(predicate, pageNumber, pageSize);
        }

        public void Dispose()
        {
            _clientRepositoryEF.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
