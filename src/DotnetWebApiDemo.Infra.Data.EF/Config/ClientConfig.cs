using DotnetWebApiDemo.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DotnetWebApiDemo.Infra.Data.EF.Config
{
    public class ClientConfig : EntityTypeConfiguration<Client>
    {
        public ClientConfig()
        {
            HasKey(x => x.ClientId);
            Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            Property(x => x.LastName).IsRequired().HasMaxLength(60);
            Property(x => x.Email).IsRequired().HasMaxLength(60);
            Property(x => x.Phone).IsRequired().HasMaxLength(16);
            Property(x => x.Gender).IsRequired();
        }
    }
}
