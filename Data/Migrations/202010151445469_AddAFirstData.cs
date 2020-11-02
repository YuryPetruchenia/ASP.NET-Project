namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAFirstData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false),
                        AlbumTitle = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Genres", t => t.AlbumId)
                .ForeignKey("dbo.SongWriters", t => t.AlbumId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SongWriter_SongWriterId = c.Int(),
                    })
                .PrimaryKey(t => t.GenreId)
                .ForeignKey("dbo.SongWriters", t => t.SongWriter_SongWriterId)
                .Index(t => t.SongWriter_SongWriterId);
            
            CreateTable(
                "dbo.SongWriters",
                c => new
                    {
                        SongWriterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.SongWriterId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId)
                .ForeignKey("dbo.Users", t => t.SubscriptionId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        SongTitle = c.String(nullable: false, maxLength: 30),
                        Album_AlbumId = c.Int(nullable: false),
                        Genre_GenreId = c.Int(nullable: false),
                        SongWriter_SongWriterId = c.Int(nullable: false),
                        Subscription_SubscriptionId = c.Int(),
                    })
                .PrimaryKey(t => t.TrackId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_GenreId, cascadeDelete: true)
                .ForeignKey("dbo.SongWriters", t => t.SongWriter_SongWriterId, cascadeDelete: true)
                .ForeignKey("dbo.Subscriptions", t => t.Subscription_SubscriptionId)
                .Index(t => t.Album_AlbumId)
                .Index(t => t.Genre_GenreId)
                .Index(t => t.SongWriter_SongWriterId)
                .Index(t => t.Subscription_SubscriptionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SubscriptionTracks",
                c => new
                    {
                        Subscription_SubscriptionId = c.Int(nullable: false),
                        Track_TrackId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscription_SubscriptionId, t.Track_TrackId })
                .ForeignKey("dbo.Subscriptions", t => t.Subscription_SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_TrackId, cascadeDelete: true)
                .Index(t => t.Subscription_SubscriptionId)
                .Index(t => t.Track_TrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "SubscriptionId", "dbo.Users");
            DropForeignKey("dbo.Tracks", "Subscription_SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.SubscriptionTracks", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.SubscriptionTracks", "Subscription_SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.Tracks", "SongWriter_SongWriterId", "dbo.SongWriters");
            DropForeignKey("dbo.Tracks", "Genre_GenreId", "dbo.Genres");
            DropForeignKey("dbo.Tracks", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "AlbumId", "dbo.SongWriters");
            DropForeignKey("dbo.Genres", "SongWriter_SongWriterId", "dbo.SongWriters");
            DropForeignKey("dbo.Albums", "AlbumId", "dbo.Genres");
            DropIndex("dbo.SubscriptionTracks", new[] { "Track_TrackId" });
            DropIndex("dbo.SubscriptionTracks", new[] { "Subscription_SubscriptionId" });
            DropIndex("dbo.Tracks", new[] { "Subscription_SubscriptionId" });
            DropIndex("dbo.Tracks", new[] { "SongWriter_SongWriterId" });
            DropIndex("dbo.Tracks", new[] { "Genre_GenreId" });
            DropIndex("dbo.Tracks", new[] { "Album_AlbumId" });
            DropIndex("dbo.Subscriptions", new[] { "SubscriptionId" });
            DropIndex("dbo.Genres", new[] { "SongWriter_SongWriterId" });
            DropIndex("dbo.Albums", new[] { "AlbumId" });
            DropTable("dbo.SubscriptionTracks");
            DropTable("dbo.Users");
            DropTable("dbo.Tracks");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.SongWriters");
            DropTable("dbo.Genres");
            DropTable("dbo.Albums");
        }
    }
}
