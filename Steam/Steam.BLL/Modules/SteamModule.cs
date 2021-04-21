using Ninject.Modules;
using Steam.DAL.Context;
using Steam.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.Modules
{
    public class SteamModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<SteamContext>();
            Bind<IRepository<Account>>().To<AccountRepository>();
            Bind<IRepository<Chat>>().To<ChatRepository>();
            Bind<IRepository<Developer>>().To<DeveloperRepository>();
            Bind<IRepository<Game>>().To<GameRepository>();
            Bind<IRepository<Genre>>().To<GenreRepository>();
            Bind<IRepository<Message>>().To<MessageRepository>();
            Bind<IRepository<ProfileComment>>().To<ProfileCommentRepository>();
            Bind<IRepository<Screenshot>>().To<ScreenshotRepository>();
        }
    }
}
