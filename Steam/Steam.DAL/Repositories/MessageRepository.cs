using Steam.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.DAL.Repositories
{
    public class MessageRepository : GenericRepository<Message>
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }
        public void ReadAll()
        {
            try
            {
                Message m = context.Set<Message>().Include(c => c.Sender).ToList()[0];
            }
            catch { }
        }
    }
}
