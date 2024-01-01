using Atolla.Core.BaseRepository;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Atolla.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        ITransaction BeginTransaction();
        void Commit();
        Task CommitAsync();
    }
}
