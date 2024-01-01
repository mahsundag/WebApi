using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atolla.Core.BaseRepository;
using Atolla.Domain.General;

namespace Atolla.Domain.Mapping
{
    public class GroupMap : EntityMappingConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            base.Configure(builder);
        }
    }
}
