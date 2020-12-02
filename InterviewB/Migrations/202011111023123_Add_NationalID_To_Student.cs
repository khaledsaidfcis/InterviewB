namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_NationalID_To_Student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "NationalID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "NationalID");
        }
    }
}
