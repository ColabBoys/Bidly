namespace Bidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimePickerANDupdatingPostDbObject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Address", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Address", c => c.String(nullable: false));
        }
    }
}
