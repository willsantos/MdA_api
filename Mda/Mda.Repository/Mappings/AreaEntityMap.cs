using Mda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
                .HasOne(p => p.Roda)
                .WithMany(p => p.Areas)
                .HasForeignKey(p => p.RodaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
