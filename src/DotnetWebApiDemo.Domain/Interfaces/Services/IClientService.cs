using DotnetWebApiDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotnetWebApiDemo.Domain.Interfaces.Services
{
    public interface IClientService : IDisposable
    {
        Client Add(Client entity);
        Client Update(Client entity);
        void Remove(int id);
        Client GetById(int id);
        IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate);
        IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate, int? pageNumber, int? pageSize);
    }
}