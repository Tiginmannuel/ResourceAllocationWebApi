namespace ResourceAllocationWebApi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        NoOfResources = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.ResourceAllocations",
                c => new
                    {
                        ResourceAllocationID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        ResourceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceAllocationID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ResourceID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.ResourceID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Threshold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceAllocations", "ResourceID", "dbo.Resources");
            DropForeignKey("dbo.ResourceAllocations", "ProjectID", "dbo.Projects");
            DropIndex("dbo.ResourceAllocations", new[] { "ResourceID" });
            DropIndex("dbo.ResourceAllocations", new[] { "ProjectID" });
            DropTable("dbo.Resources");
            DropTable("dbo.ResourceAllocations");
            DropTable("dbo.Projects");
        }
    }
}
