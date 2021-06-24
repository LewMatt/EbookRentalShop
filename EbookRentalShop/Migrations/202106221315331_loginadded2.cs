﻿namespace EbookRentalShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginadded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Login", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Login");
        }
    }
}
