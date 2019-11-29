namespace ContactBookService.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdressUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContactAdresses", "Apartment");
            DropColumn("dbo.ContactAdresses", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactAdresses", "Region", c => c.String());
            AddColumn("dbo.ContactAdresses", "Apartment", c => c.String());
        }
    }
}
