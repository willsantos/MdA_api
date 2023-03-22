using Mda.Domain.Entities;
using Mda.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Repository.Context
{
    public class MdaContext : DbContext
    {
        
        public MdaContext(DbContextOptions options) : base(options)
        {
        }

        public MdaContext()
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Roda> Rodas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(new UsuarioEntityMap().Configure);
            modelBuilder.Entity<Roda>(new RodaEntityMap().Configure);
        }
    }
}
