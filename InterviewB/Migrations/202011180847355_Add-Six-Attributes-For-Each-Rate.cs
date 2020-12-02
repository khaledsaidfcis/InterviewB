namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSixAttributesForEachRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "GeneralLook2", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "GeneralLook3", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "GeneralLook4", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "GeneralLook5", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "GeneralLook6", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "CulturalLevel2", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "CulturalLevel3", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "CulturalLevel4", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "CulturalLevel5", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "CulturalLevel6", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "TrainingStaffOpinion2", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "TrainingStaffOpinion3", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "TrainingStaffOpinion4", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "TrainingStaffOpinion5", c => c.Double(nullable: false));
            AddColumn("dbo.Student", "TrainingStaffOpinion6", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "TrainingStaffOpinion6");
            DropColumn("dbo.Student", "TrainingStaffOpinion5");
            DropColumn("dbo.Student", "TrainingStaffOpinion4");
            DropColumn("dbo.Student", "TrainingStaffOpinion3");
            DropColumn("dbo.Student", "TrainingStaffOpinion2");
            DropColumn("dbo.Student", "CulturalLevel6");
            DropColumn("dbo.Student", "CulturalLevel5");
            DropColumn("dbo.Student", "CulturalLevel4");
            DropColumn("dbo.Student", "CulturalLevel3");
            DropColumn("dbo.Student", "CulturalLevel2");
            DropColumn("dbo.Student", "GeneralLook6");
            DropColumn("dbo.Student", "GeneralLook5");
            DropColumn("dbo.Student", "GeneralLook4");
            DropColumn("dbo.Student", "GeneralLook3");
            DropColumn("dbo.Student", "GeneralLook2");
        }
    }
}
