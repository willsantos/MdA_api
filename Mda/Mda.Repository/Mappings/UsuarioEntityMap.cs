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
    public class UsuarioEntityMap
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .Property(prop => prop.Role)
                .HasConversion(
                    prop => prop.ToString(),
            prop => (EnumAcesso)Enum.Parse(typeof(EnumAcesso), prop)
            ); 

            builder.HasIndex(prop => prop.Email).IsUnique();
        }
    }
}
