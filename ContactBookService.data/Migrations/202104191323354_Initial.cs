namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        House = c.String(),
                        City = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            AddColumn("dbo.Contacts", "Birthday", c => c.DateTime());
            DropColumn("dbo.Contacts", "Phone");
            DropColumn("dbo.Contacts", "Email");
            DropColumn("dbo.Contacts", "Adress");
            DropColumn("dbo.Contacts", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "Adress", c => c.String());
            AddColumn("dbo.Contacts", "Email", c => c.String());
            AddColumn("dbo.Contacts", "Phone", c => c.String());
            DropForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactAddresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactPhones", new[] { "ContactId" });
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            DropIndex("dbo.ContactAddresses", new[] { "ContactId" });
            DropColumn("dbo.Contacts", "Birthday");
            DropTable("dbo.ContactPhones");
            DropTable("dbo.ContactEmails");
            DropTable("dbo.ContactAddresses");
        }
    }
}
