namespace StudentInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "IsActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Students", "IsDeleted");
        }
    }
}
