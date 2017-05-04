namespace eleven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        content = c.String(),
                        project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.project_Id)
                .Index(t => t.project_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.owner_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.owner_Id);
            
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Files", "project_Id", "dbo.Projects");
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "owner_Id" });
            DropIndex("dbo.Projects", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Files", new[] { "project_Id" });
            DropColumn("dbo.AspNetUsers", "Project_Id");
            DropTable("dbo.Projects");
            DropTable("dbo.Files");
        }
    }
}
