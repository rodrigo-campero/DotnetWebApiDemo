using DotnetWebApiDemo.Domain.Interfaces;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.Dapper;
using DotnetWebApiDemo.Domain.Interfaces.Repositories.EF;
using DotnetWebApiDemo.Domain.Interfaces.Services;
using DotnetWebApiDemo.Domain.Services;
using DotnetWebApiDemo.Infra.Data.Dapper.Repositories;
using DotnetWebApiDemo.Infra.Data.EF.Context;
using DotnetWebApiDemo.Infra.Data.EF.Repositories;
using DotnetWebApiDemo.Infra.Data.EF.UoW;
using SimpleInjector;

namespace DotnetWebApiDemo.Infra.CrossCutting
{
    public class Bootstrap
    {
        public static void RegisterServices(Container container)
        {
            // Domain
            container.Register<IClientService, ClientService>(Lifestyle.Scoped);

            // Infra Data
            container.Register<IClientRepositoryEF, ClientRepositoryEF>(Lifestyle.Scoped);
            container.Register<IClientRepositoryDapper, ClientRepositoryDapper>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<MainContext>(Lifestyle.Scoped);
        }
    }
}
