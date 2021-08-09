using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task_24.DAL.Entities;

namespace Task_24.DAL.Repositories {
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity {

        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);
        void Remove(TEntity item);
        void Remove(object id);
        void Update(TEntity item);
    }
}
