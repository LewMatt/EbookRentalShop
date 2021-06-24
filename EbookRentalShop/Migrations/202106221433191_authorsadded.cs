namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PublisherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Publishers");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
        }
    }
}
