namespace Bidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES(1, 'Womens'' Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(2, 'Mens Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(3, 'Boys Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(4, 'Girls Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(5, 'Babies Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES(6, 'Pets Clothing')");
        }
        
        public override void Down()
        {
        }
    }
}
