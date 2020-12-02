namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentIDToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "StudentID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "StudentID");
        }
    }
}
