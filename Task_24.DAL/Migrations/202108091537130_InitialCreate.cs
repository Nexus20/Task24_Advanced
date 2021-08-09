namespace Task_24.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 32),
                        Comment = c.String(),
                        SiteDesign = c.String(),
                        EaseOfUse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => new { t.AuthorId, t.AnswerId }, unique: true);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => new { t.GenreId, t.AnswerId }, unique: true);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        ImagePath = c.String(),
                        Text = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 32),
                        Text = c.String(maxLength: 300),
                        PublicationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImagePath = c.String(maxLength: 100),
                        Text = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreAnswers", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreAnswers", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.AuthorAnswers", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.AuthorAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.GenreAnswers", new[] { "GenreId", "AnswerId" });
            DropIndex("dbo.AuthorAnswers", new[] { "AuthorId", "AnswerId" });
            DropTable("dbo.News");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
            DropTable("dbo.Genres");
            DropTable("dbo.GenreAnswers");
            DropTable("dbo.Authors");
            DropTable("dbo.AuthorAnswers");
            DropTable("dbo.Answers");
        }
    }
}
