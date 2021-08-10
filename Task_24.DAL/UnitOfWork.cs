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
    public class UnitOfWork : IUnitOfWork {

        private readonly DataContext _context = new DataContext();
        private IGenericRepository<News> _newsRepository;
        private IGenericRepository<Comment> _commentsRepository;
        private IGenericRepository<Article> _articlesRepository;
        private IGenericRepository<Genre> _genresRepository;
        private IGenericRepository<Author> _authorsRepository;
        private IGenericRepository<Answer> _answersRepository;

        /// <summary>
        /// Repository property to access news
        /// </summary>
        public IGenericRepository<News> NewsRepository => _newsRepository ?? (_newsRepository = new GenericRepository<News>(_context));
        /// <summary>
        /// Repository property to access comments
        /// </summary>
        public IGenericRepository<Comment> CommentsRepository => _commentsRepository ?? (_commentsRepository = new GenericRepository<Comment>(_context));
        /// <summary>
        /// Repository property to access genres
        /// </summary>
        public IGenericRepository<Genre> GenresRepository => _genresRepository ?? (_genresRepository = new GenericRepository<Genre>(_context));
        /// <summary>
        /// Repository property to access authors
        /// </summary>
        public IGenericRepository<Author> AuthorsRepository => _authorsRepository ?? (_authorsRepository = new GenericRepository<Author>(_context));
        /// <summary>
        /// Repository property to access articles
        /// </summary>
        public IGenericRepository<Article> ArticlesRepository => _articlesRepository ?? (_articlesRepository = new GenericRepository<Article>(_context));
        /// <summary>
        /// Repository property to access answers
        /// </summary>
        public IGenericRepository<Answer> AnswersRepository => _answersRepository ?? (_answersRepository = new GenericRepository<Answer>(_context));

        /// <summary>
        /// Method for saving changes
        /// </summary>
        public void Save() {
            _context.SaveChanges();
        }

        private bool _disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
