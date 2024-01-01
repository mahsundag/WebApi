using Atolla.Core.BaseRepository;
using System.Collections.Generic;

namespace Atolla.Services.ServiceInfrastructure
{
    public interface IEntityService<TEntity> : IService where TEntity : BaseEntity
    {
        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        IRepository<TEntity> CurrentRepository { get; }
    }
}
