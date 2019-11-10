namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateContacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Company = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Adress = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
