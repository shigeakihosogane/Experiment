namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRole2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleModels",
                c => new
                    {
                        Role = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Role);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleModels");
        }
    }
}
