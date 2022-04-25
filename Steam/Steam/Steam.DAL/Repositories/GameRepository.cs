using Steam.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Steam.DAL.Repositories
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(DbContext context) : base(context)
        {

        }
        public void ReadAll()
        {
            try
            {
                Game g = context.Set<Game>().Include(c => c.Screenshots).Include(c => c.Baskets).ToList()[0];
            }
            catch 
            {
              //  MessageBox.Show("ReadAll GameRep");
            }
        }
    }
}
