namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Convertnationalidtodouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.String());
        }
    }
}
