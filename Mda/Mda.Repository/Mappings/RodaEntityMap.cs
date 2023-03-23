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
    public class RodaEntityMap
    {
        public void Configure(EntityTypeBuilder<Roda> builder)
        {
            builder
                .Property(prop => prop.Tipo)
                .HasConversion(
                    prop => prop.ToString(),
            prop => (TipoArea)Enum.Parse(typeof(TipoArea), prop)
            );
                           
        }
    }
}
