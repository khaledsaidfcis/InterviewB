namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNAMEToUSER : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER", "NAME", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USER", "NAME");
        }
    }
}
