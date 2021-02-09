namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRole1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserWithRoleInfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RoleInfoes",
                c => new
                    {
                        RoleName = c.String(nullable: false, maxLength: 128),
                        IsInThisRole = c.Boolean(nullable: false),
                        UserWithRoleInfo_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleName)
                .ForeignKey("dbo.UserWithRoleInfoes", t => t.UserWithRoleInfo_UserId)
                .Index(t => t.UserWithRoleInfo_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleInfoes", "UserWithRoleInfo_UserId", "dbo.UserWithRoleInfoes");
            DropIndex("dbo.RoleInfoes", new[] { "UserWithRoleInfo_UserId" });
            DropTable("dbo.RoleInfoes");
            DropTable("dbo.UserWithRoleInfoes");
        }
    }
}
