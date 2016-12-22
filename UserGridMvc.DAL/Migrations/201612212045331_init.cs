namespace UserGridMvc.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 200),
                        PostAddress = c.String(nullable: false),
                        Description = c.String(maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 200),
                        Mail = c.String(nullable: false),
                        Description = c.String(maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 200),
                        Number = c.Int(nullable: false),
                        Description = c.String(maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Phones", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Emails", "User_Id", "dbo.Users");
            DropIndex("dbo.Phones", new[] { "User_Id" });
            DropIndex("dbo.Emails", new[] { "User_Id" });
            DropIndex("dbo.Addresses", new[] { "User_Id" });
            DropTable("dbo.Phones");
            DropTable("dbo.Emails");
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
