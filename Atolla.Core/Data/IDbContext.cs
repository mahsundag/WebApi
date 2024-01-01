using Microsoft.EntityFrameworkCore;
using Atolla.Core.BaseRepository;
using System.Linq;

namespace Atolla.Core.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    
        int SaveChanges();

        IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class;

        IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity;

        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;

    }
}