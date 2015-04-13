namespace CollegeReviewMVC_API.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Colleges", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reviews", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "IsDeleted");
            DropColumn("dbo.Colleges", "IsDeleted");
        }
    }
}
