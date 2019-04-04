namespace Test1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MEMBER", "COMMENT", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MEMBER", "COMMENT");
        }
    }
}
