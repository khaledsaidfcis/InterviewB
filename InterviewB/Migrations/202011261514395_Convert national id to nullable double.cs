namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Convertnationalidtonullabledouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Student", "NationalID", c => c.Double(nullable: false));
        }
    }
}
