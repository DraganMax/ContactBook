namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactAdresses", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ContactPhones", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ContactAdresses", new[] { "Contact_Id" });
            DropIndex("dbo.ContactEmails", new[] { "Contact_Id" });
            DropIndex("dbo.ContactPhones", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.ContactAdresses", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.ContactEmails", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.ContactPhones", name: "Contact_Id", newName: "ContactId");
            AlterColumn("dbo.ContactAdresses", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactPhones", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactAdresses", "ContactId");
            CreateIndex("dbo.ContactEmails", "ContactId");
            CreateIndex("dbo.ContactPhones", "ContactId");
            AddForeignKey("dbo.ContactAdresses", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactAdresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactPhones", new[] { "ContactId" });
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            DropIndex("dbo.ContactAdresses", new[] { "ContactId" });
            AlterColumn("dbo.ContactPhones", "ContactId", c => c.Int());
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int());
            AlterColumn("dbo.ContactAdresses", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.ContactPhones", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.ContactEmails", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.ContactAdresses", name: "ContactId", newName: "Contact_Id");
            CreateIndex("dbo.ContactPhones", "Contact_Id");
            CreateIndex("dbo.ContactEmails", "Contact_Id");
            CreateIndex("dbo.ContactAdresses", "Contact_Id");
            AddForeignKey("dbo.ContactPhones", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.ContactAdresses", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
