using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_24.DAL.Entities;

namespace Task_24.DAL.Data {
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext> {

        private static IEnumerable<News> GetNews() {
            return new News[] {
                new News() {
                    Id = 1,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new News() {
                    Id = 2,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new News() {
                    Id = 3,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
            };
        }

        private static IEnumerable<Article> GetArticles() {
            return new Article[] {
                new Article() {
                    Id = 1,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new Article() {
                    Id = 2,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new Article() {
                    Id = 3,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new Article() {
                    Id = 4,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
                new Article() {
                    Id = 5,
                    Title = "Lorem ipsum dolor sit amet",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    ImagePath = "../../Content/img/17909.jpg",
                    PublicationDate = DateTime.Now
                },
            };
        }

        private static IEnumerable<Genre> GetGenres() {
            return new Genre[] {
                new Genre() {Name = "Novel"},
                new Genre() {Name = "Poem"},
                new Genre() {Name = "Epic"},
            };
        }

        private static IEnumerable<Author> GetAuthors() {
            return new Author[] {
                new Author() {Name = "Tolstoy"},
                new Author() {Name = "Chekhov"},
                new Author() {Name = "London"},
            };
        }

        private static IEnumerable<Comment> GetComments() {
            return new Comment[] {
                new Comment() {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    UserName = "User1",
                    PublicationDate = DateTime.Now
                },
                new Comment() {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    UserName = "User2",
                    PublicationDate = DateTime.Now
                },
                new Comment() {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    UserName = "User3",
                    PublicationDate = DateTime.Now
                },
                new Comment() {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    UserName = "User4",
                    PublicationDate = DateTime.Now
                },
                new Comment() {
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    UserName = "User5",
                    PublicationDate = DateTime.Now
                },
            };
        }

        protected override void Seed(DataContext db) {

            base.Seed(db);
            db.Authors.AddRange(GetAuthors());
            db.Genres.AddRange(GetGenres());
            db.Comments.AddRange(GetComments());
            db.Article.AddRange(GetArticles());
            db.News.AddRange(GetNews());


            db.SaveChanges();
        }
    }
}
