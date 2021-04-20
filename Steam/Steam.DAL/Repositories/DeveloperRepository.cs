using Steam.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Repositories
{
    public class DeveloperRepository : GenericRepository<Developer>
    {
        public DeveloperRepository(DbContext context) : base(context)
        {
        }
    }
}
