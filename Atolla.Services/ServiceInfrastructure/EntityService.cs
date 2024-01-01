using Atolla.Core.BaseRepository;
using Atolla.Core.Caching;
using Atolla.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Atolla.Services.ServiceInfrastructure
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        readonly IUnitOfWork _unitOfWork;
        public IStaticCacheManager _staticCacheManager;
        protected bool IsCacheEnable => IsCacheEnabled() && !string.IsNullOrEmpty(GetCacheName());

        public EntityService(IUnitOfWork unitOfWork, IStaticCacheManager staticCacheManager)
        {
            _unitOfWork = unitOfWork;
            _staticCacheManager = staticCacheManager;
        }
        public virtual bool IsCacheEnabled()
        {
            return false;
        }

        public virtual string GetCacheName()
        {
            return string.Empty;
        }

        public IRepository<T> CurrentRepository => _unitOfWork.GetRepository<T>();

        public void Delete(T entity)
        {
            CurrentRepository.Delete(entity);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            CurrentRepository.Delete(entities);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }

        public T GetById(object id)
        {
            if (IsCacheEnable && _staticCacheManager.IsSet(GetCacheName()))
                return _staticCacheManager.Get<List<T>>(GetCacheName()).FirstOrDefault(s => s.Id == id);
            return CurrentRepository.GetById(id);
        }

        public void Insert(T entity)
        {
            CurrentRepository.Insert(entity);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }

        public void Insert(IEnumerable<T> entities)
        {
            CurrentRepository.Insert(entities);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }

        public void Update(T entity)
        {
            CurrentRepository.Update(entity);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            CurrentRepository.Update(entities);
            if (IsCacheEnable)
            {
                _staticCacheManager.Reload(GetCacheName(), this.CurrentRepository.Table.ToList());
            }
        }
    }
}
