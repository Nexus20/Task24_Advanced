using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_24.DAL.Data;
using Task_24.DAL.Entities;
using Task_24.DAL.Repositories;

namespace Task_24.DAL {
    /// <summary>
    /// Interface for unit of work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable {

        /// <summary>
        /// Repository property to access news
        /// </summary>
        IGenericRepository<News> NewsRepository { get; }

        /// <summary>
        /// Repository property to access comments
        /// </summary>
        IGenericRepository<Comment> CommentsRepository { get; }
        /// <summary>
        /// Repository property to access genres
        /// </summary>
        IGenericRepository<Genre> GenresRepository { get; }
        /// <summary>
        /// Repository property to access authors
        /// </summary>
        IGenericRepository<Author> AuthorsRepository { get; }
        /// <summary>
        /// Repository property to access articles
        /// </summary>
        IGenericRepository<Article> ArticlesRepository { get; }
        /// <summary>
        /// Repository property to access answers
        /// </summary>
        IGenericRepository<Answer> AnswersRepository { get; }

        /// <summary>
        /// Method for saving changes
        /// </summary>
        void Save();
    }
}
