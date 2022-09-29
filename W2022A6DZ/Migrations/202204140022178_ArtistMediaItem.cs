namespace W2022A6DZ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistMediaItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistMediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(nullable: false, maxLength: 100),
                        StringId = c.String(nullable: false, maxLength: 100),
                        Timestamp = c.DateTime(nullable: false),
                        ContentType = c.String(maxLength: 200),
                        Content = c.Binary(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArtistMediaItems", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.ArtistMediaItems", new[] { "Artist_Id" });
            DropTable("dbo.ArtistMediaItems");
        }
    }
}
