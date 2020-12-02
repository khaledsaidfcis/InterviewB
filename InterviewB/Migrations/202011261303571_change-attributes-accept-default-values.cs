namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeattributesacceptdefaultvalues : DbMigration
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
