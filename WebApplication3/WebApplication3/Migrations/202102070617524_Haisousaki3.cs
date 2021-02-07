namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Haisousaki3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haisousaki3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ZyuusyorokuId = c.Int(nullable: false),
                        EriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.ZyuusyorokuId, cascadeDelete: true)
                .Index(t => t.ZyuusyorokuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Haisousaki3", "ZyuusyorokuId", "dbo.Zyuusyorokus");
            DropIndex("dbo.Haisousaki3", new[] { "ZyuusyorokuId" });
            DropTable("dbo.Haisousaki3");
        }
    }
}
