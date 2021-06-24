namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ebooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ebooks",
                c => new
                    {
                        EbookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        PublisherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EbookID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ebooks");
        }
    }
}
