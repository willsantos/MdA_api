using Mda.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Repository.Mappings
{
    public class ObjetivoEntityMap
    {
        public void Configure(EntityTypeBuilder<Objetivo> builder)
        {
            builder
                .HasOne(p => p.Area)
                .WithMany(p => p.Objetivos)
                .HasForeignKey(p => p.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
