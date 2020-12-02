namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_od_NationalID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.String());
        }
    }
}
