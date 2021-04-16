namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactId_not_null : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactEmails", "ContactId");
            AddForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            AlterColumn("dbo.ContactEmails", "ContactId", c => c.Int());
            CreateIndex("dbo.ContactEmails", "ContactId");
            AddForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts", "Id");
        }
    }
}
