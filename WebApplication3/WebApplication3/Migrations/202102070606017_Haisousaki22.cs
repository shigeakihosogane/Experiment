namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Haisousaki22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haisousaki2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ZyuusyorokuId = c.Int(nullable: false),
                        EriaId = c.Int(nullable: false),
                        DennwaBanngou_Id = c.Int(),
                        FaxBanngou_Id = c.Int(),
                        MeisyouRyaku_Id = c.Int(),
                        MeisyouSei_Id = c.Int(),
                        Zyuusyo1_Id = c.Int(),
                        Zyuusyo2_Id = c.Int(),
                        Zyuusyo3_Id = c.Int(),
                        Zyuusyo4_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.DennwaBanngou_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.FaxBanngou_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.MeisyouRyaku_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.MeisyouSei_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.Zyuusyo1_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.Zyuusyo2_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.Zyuusyo3_Id)
                .ForeignKey("dbo.Zyuusyorokus", t => t.Zyuusyo4_Id)
                .Index(t => t.DennwaBanngou_Id)
                .Index(t => t.FaxBanngou_Id)
                .Index(t => t.MeisyouRyaku_Id)
                .Index(t => t.MeisyouSei_Id)
                .Index(t => t.Zyuusyo1_Id)
                .Index(t => t.Zyuusyo2_Id)
                .Index(t => t.Zyuusyo3_Id)
                .Index(t => t.Zyuusyo4_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Haisousaki2", "Zyuusyo4_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "Zyuusyo3_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "Zyuusyo2_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "Zyuusyo1_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "MeisyouSei_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "MeisyouRyaku_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "FaxBanngou_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousaki2", "DennwaBanngou_Id", "dbo.Zyuusyorokus");
            DropIndex("dbo.Haisousaki2", new[] { "Zyuusyo4_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "Zyuusyo3_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "Zyuusyo2_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "Zyuusyo1_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "MeisyouSei_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "MeisyouRyaku_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "FaxBanngou_Id" });
            DropIndex("dbo.Haisousaki2", new[] { "DennwaBanngou_Id" });
            DropTable("dbo.Haisousaki2");
        }
    }
}
