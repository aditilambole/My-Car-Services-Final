namespace MyCarServicesFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.Long(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
