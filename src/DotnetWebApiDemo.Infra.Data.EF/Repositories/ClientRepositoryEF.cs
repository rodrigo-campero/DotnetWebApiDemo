using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.EF;
using DotnetWebApiDemo.Infra.Data.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotnetWebApiDemo.Infra.Data.EF.Repositories
{
    public class ClientRepositoryEF : Repository<Client>, IClientRepositoryEF
    {
        public ClientRepositoryEF(MainContext context) : base(context) { }
        public IEnumerable<Client> Search(Expression<Func<Client, bool>> predicate, int? pageNumber, int? pageSize)
        {
            return DbSet.Where(predicate).OrderBy(x => x.FirstName).Skip(pageNumber ?? 0 * pageSize ?? 0).Take(pageSize ?? 10);
        }
    }
}
