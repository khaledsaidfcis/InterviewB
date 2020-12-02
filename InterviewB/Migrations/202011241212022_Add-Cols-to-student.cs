namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColstostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Job", c => c.String());
            AddColumn("dbo.Student", "Area", c => c.String());
            DropColumn("dbo.Student", "Grade");
            DropColumn("dbo.Student", "Center");
            DropColumn("dbo.Student", "Address");
            DropColumn("dbo.Student", "FatherJob");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "FatherJob", c => c.String());
            AddColumn("dbo.Student", "Address", c => c.String());
            AddColumn("dbo.Student", "Center", c => c.String());
            AddColumn("dbo.Student", "Grade", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "Area");
            DropColumn("dbo.Student", "Job");
        }
    }
}
