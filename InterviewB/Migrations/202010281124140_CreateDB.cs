namespace InterviewB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BASIC_INFO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        STD_NO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STD_KIND_CODE = c.Decimal(nullable: false, precision: 18, scale: 2),
                        STD_KIND = c.String(),
                        STD_NAME = c.String(),
                        NATIONAL_ID = c.String(),
                        BIRTH_DATE = c.DateTime(),
                        CALCDATE = c.String(),
                        PLACE_CODE = c.Short(),
                        PLACE = c.String(),
                        SCN_CODE = c.Decimal(precision: 18, scale: 2),
                        SCN = c.String(),
                        SHOPA_CODE = c.Decimal(precision: 18, scale: 2),
                        SHOPA = c.String(),
                        SCN_NAME = c.String(),
                        PERS = c.Decimal(precision: 18, scale: 2),
                        COLLEGE_CODE = c.Decimal(precision: 18, scale: 2),
                        COLLEGE = c.String(),
                        GRADUATION_CODE = c.Decimal(precision: 18, scale: 2),
                        GRADUATION = c.String(),
                        POST_GRADUATION_CODE = c.Decimal(precision: 18, scale: 2),
                        POST_GRADUATION = c.String(),
                        GRADE_CODE = c.Decimal(precision: 18, scale: 2),
                        GRADE = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(),
                        PASSWORD = c.String(),
                        PRIORITY = c.Int(nullable: false),
                        ISLOGGED = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Qualification = c.String(),
                        Grade = c.String(),
                        Center = c.String(),
                        Governorate = c.String(),
                        Address = c.String(),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        FatherJob = c.String(),
                        Fitness = c.Double(nullable: false),
                        GeneralLook = c.Double(nullable: false),
                        CulturalLevel = c.Double(nullable: false),
                        TransportationOpinion = c.Double(nullable: false),
                        TrainingStaffOpinion = c.Double(nullable: false),
                        AttendanceDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student");
            DropTable("dbo.USER");
            DropTable("dbo.BASIC_INFO");
        }
    }
}
