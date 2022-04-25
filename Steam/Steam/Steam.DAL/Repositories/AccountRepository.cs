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
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }
        public void ReadAll()
        {
            try
            {
                Account g = context.Set<Account>().Include(c => c.Games)
                                                  .Include(c => c.Basket)
                                                  .Include(c => c.AccountFriends)
                                                  .Include(c => c.Messages)
                                                  .Include(c => c.Chats).ToList()[0];
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
