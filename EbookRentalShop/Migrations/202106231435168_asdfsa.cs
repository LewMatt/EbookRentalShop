namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfsa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suggestions", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suggestions", "UserID", c => c.Int(nullable: false));
        }
    }
}
