using Microsoft.EntityFrameworkCore;

namespace Atolla.Core.BaseRepository
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
