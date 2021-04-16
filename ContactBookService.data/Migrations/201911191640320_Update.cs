namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.ContactEmails", new[] { "Contact_Id" });
            RenameColumn(table: "dbo.ContactEmails", name: "Contact_Id", newName: "ContactId");
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactEmails", "ContactId");
            AddForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int());
            RenameColumn(table: "dbo.ContactEmails", name: "ContactId", newName: "Contact_Id");
            CreateIndex("dbo.ContactEmails", "Contact_Id");
            AddForeignKey("dbo.ContactEmails", "Contact_Id", "dbo.Contacts", "Id");
        }
    }
}
