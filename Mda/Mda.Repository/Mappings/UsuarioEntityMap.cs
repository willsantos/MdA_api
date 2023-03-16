using Mda.Domain.Entities;
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
            /*builder
                .Property(prop => prop.Role)
                .HasConversion(
                    prop => prop.ToString(),
            prop => (EnumRole)Enum.Parse(typeof(EnumRole), prop)
            );*/ //vamos trabalhar com níveis de acesso?

            builder.HasIndex(prop => prop.Email).IsUnique();
        }
    }
}
