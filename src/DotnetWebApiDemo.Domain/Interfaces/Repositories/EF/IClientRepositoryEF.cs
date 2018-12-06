using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DotnetWebApiDemo.Domain.Entities;

namespace DotnetWebApiDemo.Domain.Interfaces.Repositories.EF
{
    public interface IClientRepositoryEF : IRepository<Client>
    {
        IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate, int? pageNumber, int? pageSize);
    }
}