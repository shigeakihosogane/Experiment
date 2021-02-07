namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Haisousaki2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Haisousakis", "DennwaBanngou_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "FaxBanngou_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "MeisyouRyaku_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "MeisyouSei_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "Zyuusyo1_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "Zyuusyo2_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "Zyuusyo3_Id", c => c.Int());
            AddColumn("dbo.Haisousakis", "Zyuusyo4_Id", c => c.Int());
            CreateIndex("dbo.Haisousakis", "DennwaBanngou_Id");
            CreateIndex("dbo.Haisousakis", "FaxBanngou_Id");
            CreateIndex("dbo.Haisousakis", "MeisyouRyaku_Id");
            CreateIndex("dbo.Haisousakis", "MeisyouSei_Id");
            CreateIndex("dbo.Haisousakis", "Zyuusyo1_Id");
            CreateIndex("dbo.Haisousakis", "Zyuusyo2_Id");
            CreateIndex("dbo.Haisousakis", "Zyuusyo3_Id");
            CreateIndex("dbo.Haisousakis", "Zyuusyo4_Id");
            AddForeignKey("dbo.Haisousakis", "DennwaBanngou_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "FaxBanngou_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "MeisyouRyaku_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "MeisyouSei_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "Zyuusyo1_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "Zyuusyo2_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "Zyuusyo3_Id", "dbo.Zyuusyorokus", "Id");
            AddForeignKey("dbo.Haisousakis", "Zyuusyo4_Id", "dbo.Zyuusyorokus", "Id");
            DropColumn("dbo.Haisousakis", "MeisyouRyaku");
            DropColumn("dbo.Haisousakis", "MeisyouSei");
            DropColumn("dbo.Haisousakis", "Zyuusyo1");
            DropColumn("dbo.Haisousakis", "Zyuusyo2");
            DropColumn("dbo.Haisousakis", "Zyuusyo3");
            DropColumn("dbo.Haisousakis", "Zyuusyo4");
            DropColumn("dbo.Haisousakis", "DennwaBanngou");
            DropColumn("dbo.Haisousakis", "FaxBanngou");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Haisousakis", "FaxBanngou", c => c.String());
            AddColumn("dbo.Haisousakis", "DennwaBanngou", c => c.String());
            AddColumn("dbo.Haisousakis", "Zyuusyo4", c => c.String());
            AddColumn("dbo.Haisousakis", "Zyuusyo3", c => c.String());
            AddColumn("dbo.Haisousakis", "Zyuusyo2", c => c.String());
            AddColumn("dbo.Haisousakis", "Zyuusyo1", c => c.String());
            AddColumn("dbo.Haisousakis", "MeisyouSei", c => c.String());
            AddColumn("dbo.Haisousakis", "MeisyouRyaku", c => c.String());
            DropForeignKey("dbo.Haisousakis", "Zyuusyo4_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "Zyuusyo3_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "Zyuusyo2_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "Zyuusyo1_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "MeisyouSei_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "MeisyouRyaku_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "FaxBanngou_Id", "dbo.Zyuusyorokus");
            DropForeignKey("dbo.Haisousakis", "DennwaBanngou_Id", "dbo.Zyuusyorokus");
            DropIndex("dbo.Haisousakis", new[] { "Zyuusyo4_Id" });
            DropIndex("dbo.Haisousakis", new[] { "Zyuusyo3_Id" });
            DropIndex("dbo.Haisousakis", new[] { "Zyuusyo2_Id" });
            DropIndex("dbo.Haisousakis", new[] { "Zyuusyo1_Id" });
            DropIndex("dbo.Haisousakis", new[] { "MeisyouSei_Id" });
            DropIndex("dbo.Haisousakis", new[] { "MeisyouRyaku_Id" });
            DropIndex("dbo.Haisousakis", new[] { "FaxBanngou_Id" });
            DropIndex("dbo.Haisousakis", new[] { "DennwaBanngou_Id" });
            DropColumn("dbo.Haisousakis", "Zyuusyo4_Id");
            DropColumn("dbo.Haisousakis", "Zyuusyo3_Id");
            DropColumn("dbo.Haisousakis", "Zyuusyo2_Id");
            DropColumn("dbo.Haisousakis", "Zyuusyo1_Id");
            DropColumn("dbo.Haisousakis", "MeisyouSei_Id");
            DropColumn("dbo.Haisousakis", "MeisyouRyaku_Id");
            DropColumn("dbo.Haisousakis", "FaxBanngou_Id");
            DropColumn("dbo.Haisousakis", "DennwaBanngou_Id");
        }
    }
}
