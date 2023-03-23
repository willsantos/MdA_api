using Mda.Domain.Entities;
using Mda.Domain.Interfaces;
using Mda.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mda.Repository.Repositories
{
    public class RodaRepository : BaseRepository<Roda>, IRodaRepository
    {
        public RodaRepository(MdaContext context) : base(context)
        {
        }
    }
}
