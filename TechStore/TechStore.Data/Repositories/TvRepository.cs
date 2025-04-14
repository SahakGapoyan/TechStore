using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Data.DbContext;
using TechStore.Data.Entity;
using TechStore.Data.Interfaces;

namespace TechStore.Data.Repositories
{
    public class TvRepository : ProductRepository<Tv>, ITvRepository
    {
        public TvRepository(TechStoreDbContext context) : base(context)
        {

        }

    }
}
