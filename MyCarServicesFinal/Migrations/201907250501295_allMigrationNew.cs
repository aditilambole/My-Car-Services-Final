namespace MyCarServicesFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allMigrationNew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
