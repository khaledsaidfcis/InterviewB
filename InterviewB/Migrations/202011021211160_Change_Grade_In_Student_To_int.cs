namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Grade_In_Student_To_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "Grade", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "Grade", c => c.String());
        }
    }
}
