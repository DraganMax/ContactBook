namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactAdresses", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactAdresses", new[] { "ContactId" });
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            DropIndex("dbo.ContactPhones", new[] { "ContactId" });
            RenameColumn(table: "dbo.ContactAdresses", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.ContactEmails", name: "ContactId", newName: "Contact_Id");
            RenameColumn(table: "dbo.ContactPhones", name: "ContactId", newName: "Contact_Id");
            AlterColumn("dbo.ContactAdresses", "Contact_Id", c => c.Int());
            AlterColumn("dbo.ContactEmails", "Contact_Id", c => c.Int());
            AlterColumn("dbo.ContactPhones", "Contact_Id", c => c.Int());
            CreateIndex("dbo.ContactAdresses", "Contact_Id");
            CreateIndex("dbo.ContactEmails", "Contact_Id");
            CreateIndex("dbo.ContactPhones", "Contact_Id");
            AddForeignKey("dbo.ContactAdresses", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.ContactPhones", "Contact_Id", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPhones", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.ContactAdresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ContactPhones", new[] { "Contact_Id" });
            DropIndex("dbo.ContactEmails", new[] { "Contact_Id" });
            DropIndex("dbo.ContactAdresses", new[] { "Contact_Id" });
            AlterColumn("dbo.ContactPhones", "Contact_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactEmails", "Contact_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactAdresses", "Contact_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ContactPhones", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.ContactEmails", name: "Contact_Id", newName: "ContactId");
            RenameColumn(table: "dbo.ContactAdresses", name: "Contact_Id", newName: "ContactId");
            CreateIndex("dbo.ContactPhones", "ContactId");
            CreateIndex("dbo.ContactEmails", "ContactId");
            CreateIndex("dbo.ContactAdresses", "ContactId");
            AddForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ContactAdresses", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
