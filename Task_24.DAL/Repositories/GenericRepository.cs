using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task_24.DAL.Entities;

namespace Task_24.DAL.Repositories {
    /// <summary>
    /// Implementation of the repository pattern
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity {

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database context object</param>
        public GenericRepository(DbContext context) {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Method for creating entity
        /// </summary>
        /// <param name="item"></param>
        public void Create(TEntity item) {
            _dbSet.Add(item);
        }

        /// <summary>
        /// Method for finding entity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindById(int id) {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Method for getting all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> Get() {
            return _dbSet.AsNoTracking().ToList();
        }

        /// <summary>
        /// Method for getting all entities according to filters, orders and optionally with additional properties
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null) {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        /// <summary>
        /// Method for removing entity by object
        /// </summary>
        /// <param name="item"></param>
        public void Remove(TEntity item) {
            if (_context.Entry(item).State == EntityState.Detached) {
                _dbSet.Attach(item);
            }
            _dbSet.Remove(item);
        }

        /// <summary>
        /// Method for removing entity by id
        /// </summary>
        /// <param name="id"></param>
        public void Remove(object id) {
            var entityToRemove = _dbSet.Find(id);
            Remove(entityToRemove);
        }

        /// <summary>
        /// Method for updating entity
        /// </summary>
        /// <param name="item"></param>
        public void Update(TEntity item) {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        //public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties) {
        //    return Include(includeProperties).ToList();
        //}

        //public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
        //    params Expression<Func<TEntity, object>>[] includeProperties) {
        //    var query = Include(includeProperties);
        //    return query.Where(predicate).ToList();
        //}

        //private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties) {
        //    IQueryable<TEntity> query = _dbSet.AsNoTracking();
        //    return includeProperties
        //        .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}

        /// <summary>
        /// Method for saving changes
        /// </summary>
        public void Save() {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        /// <summary>
        /// Implementation of IDisposable interface
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (!this._disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
