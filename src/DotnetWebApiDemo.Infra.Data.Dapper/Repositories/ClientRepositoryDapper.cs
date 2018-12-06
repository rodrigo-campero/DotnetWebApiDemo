using Dapper;
using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.Dapper;
using System.Data;
using System.Linq;

namespace DotnetWebApiDemo.Infra.Data.Dapper.Repositories
{
    public class ClientRepositoryDapper : Connection, IClientRepositoryDapper
    {
        public Client GetById(int id)
        {
            using (IDbConnection connection = DefaultConnection)
            {
                return connection.Query<Client>("SELECT ClientId, FirstName, LastName, Phone, Gender, Email FROM Client WHERE ClientId = @ClientId;", new { ClientId = id }).SingleOrDefault();
            }
        }
    }
}
