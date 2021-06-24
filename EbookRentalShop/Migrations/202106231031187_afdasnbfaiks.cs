namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afdasnbfaiks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Borrows", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Borrows", "UserID", c => c.Int(nullable: false));
        }
    }
}
