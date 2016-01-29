namespace DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FirstCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picture",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Url = c.String(nullable: false),
                    FileName = c.String(),
                    FileType = c.String(),
                    Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    IsValid = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SubjectInfo",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    Description = c.String(nullable: false),
                    Order = c.Int(nullable: false),
                    AdditionNum = c.Int(nullable: false),
                    ResultTitle = c.String(),
                    PictureId = c.Int(nullable: false),
                    ResultPictureId = c.Int(nullable: false),
                    Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    IsValid = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Picture", t => t.PictureId, cascadeDelete: false)
                .ForeignKey("dbo.Picture", t => t.ResultPictureId, cascadeDelete: false);

            CreateTable(
                "dbo.SubjectOption",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ResultType = c.Int(nullable: false),
                    ContentExt = c.String(),
                    Content = c.String(nullable: false),
                    Order = c.Int(nullable: false),
                    SubjectId = c.Int(nullable: false),
                    Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    IsValid = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectInfo", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);

            CreateTable(
                "dbo.SubjectResult",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Key = c.String(nullable: false, maxLength: 10),
                    SubjectId = c.Int(nullable: false),
                    ResultPictureId = c.Int(nullable: false),
                    Timespan = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    IsValid = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Picture", t => t.ResultPictureId, cascadeDelete: false)
                .ForeignKey("dbo.SubjectInfo", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => new { t.SubjectId, t.Key });

            CreateTable(
                "dbo.ResultOptionMapping",
                c => new
                {
                    ResultId = c.Int(nullable: false),
                    OptionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ResultId, t.OptionId })
                .ForeignKey("dbo.SubjectResult", t => t.ResultId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectOption", t => t.OptionId, cascadeDelete: false)
                .Index(t => t.ResultId)
                .Index(t => t.OptionId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.SubjectResult", "SubjectId", "dbo.SubjectInfo");
            DropForeignKey("dbo.SubjectResult", "ResultPictureId", "dbo.Picture");
            DropForeignKey("dbo.ResultOptionMapping", "OptionId", "dbo.SubjectOption");
            DropForeignKey("dbo.ResultOptionMapping", "ResultId", "dbo.SubjectResult");
            DropForeignKey("dbo.SubjectInfo", "ResultPictureId", "dbo.Picture");
            DropForeignKey("dbo.SubjectInfo", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.SubjectOption", "SubjectId", "dbo.SubjectInfo");
            DropIndex("dbo.ResultOptionMapping", new[] { "OptionId" });
            DropIndex("dbo.ResultOptionMapping", new[] { "ResultId" });
            DropIndex("dbo.SubjectResult", new[] { "SubjectId" });
            DropIndex("dbo.SubjectResult", new[] { "SubjectId", "Key" });
            DropIndex("dbo.SubjectOption", new[] { "SubjectId" });
            DropTable("dbo.ResultOptionMapping");
            DropTable("dbo.SubjectResult");
            DropTable("dbo.SubjectOption");
            DropTable("dbo.SubjectInfo");
            DropTable("dbo.Picture");
        }
    }
}
