namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStudentIDToNotAcceptNullInStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "StudentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "StudentID", c => c.Int());
        }
    }
}
