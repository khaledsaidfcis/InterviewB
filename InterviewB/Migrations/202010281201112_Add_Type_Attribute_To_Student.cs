namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Type_Attribute_To_Student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Type");
        }
    }
}
