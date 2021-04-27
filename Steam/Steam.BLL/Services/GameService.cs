using AutoMapper;
using Steam.BLL.DTO;
using Steam.DAL.Context;
using Steam.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.Services
{
    public class GameService : IService<GameDTO>
    {
        GameRepository repository;
        IMapper mapper;
        public GameService(IRepository<Game> repository)
        {
            this.repository = (GameRepository)repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Game, GameDTO>();
                x.CreateMap<GameDTO, Game>();
                x.CreateMap<Screenshot, ScreenshotDTO>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public GameDTO Get(int gameId)
        {
            repository.ReadAll();
            return mapper.Map<Game, GameDTO>(repository.Get(gameId));
        }

        public IEnumerable<GameDTO> GetAll()
        {
            repository.ReadAll();
            return mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(GameDTO gameDTO)
        {
            repository.CreateOrUpdate(mapper.Map<GameDTO, Game>(gameDTO));
            repository.SaveChanges();
        }

        public GameDTO Delete(GameDTO gameDTO)
        {
            repository.Delete(mapper.Map<GameDTO, Game>(gameDTO));
            repository.SaveChanges();
            return gameDTO;
        }




    }
}
