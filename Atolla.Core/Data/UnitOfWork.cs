using Microsoft.EntityFrameworkCore;
using Atolla.Core.BaseRepository;
using Atolla.Core.Infrastructure;
using System.Data;
using System.Threading.Tasks;

namespace Atolla.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        public ITransaction BeginTransaction()
        {
            return new DbTransaction(_context.Database.BeginTransaction());
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context = null;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return EngineContext.Current.Resolve<IRepository<T>>();
        }
    }
}
