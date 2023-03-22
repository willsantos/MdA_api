using Mda.Domain.Entities;
using Mda.Domain.Entities.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Repository.Mappings
{
    public class AreaEntityMap
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder
                .Property(prop => prop.Tipo)
                .HasConversion(
                    prop => prop.ToString(),
            prop => (AreaDaVida)Enum.Parse(typeof(AreaDaVida), prop)
            );
        }
    }
}
