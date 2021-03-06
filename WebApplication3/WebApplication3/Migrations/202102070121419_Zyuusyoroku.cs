namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zyuusyoroku : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zyuusyorokus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZyuusyorokuId = c.Int(nullable: false),
                        MeisyouRyaku = c.String(),
                        MeisyouSei = c.String(),
                        Zyuusyo1 = c.String(),
                        Zyuusyo2 = c.String(),
                        Zyuusyo3 = c.String(),
                        Zyuusyo4 = c.String(),
                        DennwaBanngou = c.String(),
                        FaxBanngou = c.String(),
                        EriaId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zyuusyorokus");
        }
    }
}
