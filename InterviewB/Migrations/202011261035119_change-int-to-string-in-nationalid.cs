namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinttostringinnationalid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.Int(nullable: false));
        }
    }
}
