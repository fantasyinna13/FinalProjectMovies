namespace FinalProjectMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Films : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenresID = c.Int(nullable: false, identity: true),
                        GenresName = c.String(),
                    })
                .PrimaryKey(t => t.GenresID);
            
            CreateTable(
                "dbo.MovieToGenres",
                c => new
                    {
                        MovieToGenresID = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        GenresID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieToGenresID)
                .ForeignKey("dbo.Genres", t => t.GenresID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.GenresID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieToGenres", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.MovieToGenres", "GenresID", "dbo.Genres");
            DropIndex("dbo.Tickets", new[] { "MovieID" });
            DropIndex("dbo.MovieToGenres", new[] { "GenresID" });
            DropIndex("dbo.MovieToGenres", new[] { "MovieID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieToGenres");
            DropTable("dbo.Genres");
        }
    }
}
