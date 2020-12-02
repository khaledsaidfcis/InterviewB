namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPsychologicaltostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Psychological", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Psychological");
        }
    }
}
