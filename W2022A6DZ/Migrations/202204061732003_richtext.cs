namespace W2022A6DZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class richtext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Background", c => c.String());
            AddColumn("dbo.Artists", "Portrayal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Portrayal");
            DropColumn("dbo.Albums", "Background");
        }
    }
}
