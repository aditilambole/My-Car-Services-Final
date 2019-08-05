namespace MyCarServicesFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAllValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Company", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Style", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Details", c => c.String());
            AlterColumn("dbo.Cars", "Color", c => c.String());
            AlterColumn("dbo.Cars", "Style", c => c.String());
            AlterColumn("dbo.Cars", "Model", c => c.String());
            AlterColumn("dbo.Cars", "Company", c => c.String());
        }
    }
}
