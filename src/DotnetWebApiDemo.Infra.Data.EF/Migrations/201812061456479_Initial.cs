namespace DotnetWebApiDemo.Infra.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 60, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 16, unicode: false),
                        Email = c.String(nullable: false, maxLength: 60, unicode: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Client");
        }
    }
}
