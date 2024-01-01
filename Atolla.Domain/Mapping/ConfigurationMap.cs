using Atolla.Core.BaseRepository;
using Atolla.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Domain.Mapping
{
    public class ConfigurationMap : EntityMappingConfiguration<Configuration>
    {
        public override void Configure(EntityTypeBuilder<Configuration> builder)
        {
            base.Configure(builder);
        }
    }
}
