﻿using Microsoft.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
