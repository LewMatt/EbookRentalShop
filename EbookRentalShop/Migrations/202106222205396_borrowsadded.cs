namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        BorrowID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        EbookID = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowID);
            
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        SuggestionID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.SuggestionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suggestions");
            DropTable("dbo.Borrows");
        }
    }
}
