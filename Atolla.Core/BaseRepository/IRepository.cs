using System.Collections.Generic;
using System.Linq;

namespace Atolla.Core.BaseRepository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(object id);

        void Insert(TEntity entity);


        void Insert(IEnumerable<TEntity> entities);


        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);


        void Delete(TEntity entity);


        void Delete(IEnumerable<TEntity> entities);


        IQueryable<TEntity> Table { get; }


        IQueryable<TEntity> TableNoTracking { get; }

    }
}