using Atolla.Core.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Atolla.Domain.General;

namespace Atolla.Domain.Mapping
{
    public class ParameterMap : EntityMappingConfiguration<Parameter>
    {
        public override void Configure(EntityTypeBuilder<Parameter> builder)
        {
            base.Configure(builder);
        }

    }
}
