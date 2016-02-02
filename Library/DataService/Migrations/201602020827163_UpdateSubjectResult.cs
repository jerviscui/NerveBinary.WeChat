namespace DataService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubjectResult : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectResult", "CreateOnUtc", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectResult", "CreateOnUtc");
        }
    }
}
