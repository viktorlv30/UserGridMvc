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
                        PostAddress = c.String(),
                        Description = c.String(maxLength: 300),
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(maxLength: 200),
                        Number = c.Int(nullable: false),
                        Description = c.String(maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Address_Id = c.Guid(),
                        Email_Id = c.Guid(),
                        Phone_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Emails", t => t.Email_Id)
                .ForeignKey("dbo.Phones", t => t.Phone_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Email_Id)
                .Index(t => t.Phone_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Phone_Id", "dbo.Phones");
            DropForeignKey("dbo.Users", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.Users", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Phone_Id" });
            DropIndex("dbo.Users", new[] { "Email_Id" });
            DropIndex("dbo.Users", new[] { "Address_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Phones");
            DropTable("dbo.Emails");
            DropTable("dbo.Addresses");
        }
    }
}
