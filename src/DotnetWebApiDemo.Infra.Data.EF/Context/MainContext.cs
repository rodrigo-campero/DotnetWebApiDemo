using DotnetWebApiDemo.Domain.Entities;
using DotnetWebApiDemo.Infra.Data.EF.Config;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DotnetWebApiDemo.Infra.Data.EF.Context
{
    public class MainContext : DbContext
    {
        public MainContext() : base("DefaultConnection") { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(150));
            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties().Where(x => x.ReflectedType + "Id" == x.Name).Configure(x => x.IsKey());

            modelBuilder.Configurations.Add(new ClientConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
