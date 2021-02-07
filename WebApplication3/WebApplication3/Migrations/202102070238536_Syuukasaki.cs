namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Syuukasaki : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Syuukasakis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ZyuusyorokuId = c.Int(nullable: false),
                        EriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Syuukasakis");
        }
    }
}
