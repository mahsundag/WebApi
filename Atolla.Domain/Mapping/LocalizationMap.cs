using Atolla.Core.BaseRepository;
using Atolla.Domain.General;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Domain.Mapping
{
    public class LocalizationMap : EntityMappingConfiguration<Localization>
    {
        public override void Configure(EntityTypeBuilder<Localization> builder)
        {
            base.Configure(builder);
        }
    }
}
