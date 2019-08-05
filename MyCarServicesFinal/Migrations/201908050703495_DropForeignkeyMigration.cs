namespace MyCarServicesFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropForeignkeyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
        }
        
        public override void Down()
        {
        }
    }
}
