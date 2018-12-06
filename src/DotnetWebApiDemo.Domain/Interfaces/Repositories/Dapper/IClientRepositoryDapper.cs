using DotnetWebApiDemo.Domain.Entities;

namespace DotnetWebApiDemo.Domain.Interfaces.Repositories.Dapper
{
    public interface IClientRepositoryDapper
    {
        Client GetById(int id);
    }
}
