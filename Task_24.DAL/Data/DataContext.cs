using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_24.DAL.Entities;

namespace Task_24.DAL.Data {
    public class DataContext : DbContext {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        static DataContext() {
            Database.SetInitializer<DataContext>(new DataContextInitializer());
        }

        public DataContext() : base("name=DataContext") {
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AuthorAnswer> AuthorAnswers { get; set; }
        public DbSet<GenreAnswer> GenreAnswers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
    }
}
