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
    public class ProjetoEntityMap
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder
                .HasOne(p => p.Objetivo)
                .WithMany(p => p.Projetos)
                .HasForeignKey(p => p.ObjetivoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
