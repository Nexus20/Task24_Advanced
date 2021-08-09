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
    /// Unit of work pattern implementation
    /// </summary>
    public interface IUnitOfWork : IDisposable {

        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<News> NewsRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<Comment> CommentsRepository { get; }
        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<Genre> GenresRepository { get; }
        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<Author> AuthorsRepository { get; }
        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<Article> ArticlesRepository { get; }
        /// <summary>
        /// 
        /// </summary>
        IGenericRepository<Answer> AnswersRepository { get; }

        /// <summary>
        /// 
        /// </summary>
        void Save();
    }
}
