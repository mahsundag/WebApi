using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atolla.Core.BaseRepository
{
    public class EntityMappingConfiguration<T> : IMappingConfiguration, IEntityTypeConfiguration<T> where T : class
    {
        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

        }

    }
}
