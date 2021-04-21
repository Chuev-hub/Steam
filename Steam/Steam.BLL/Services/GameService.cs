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
        IRepository<Game> repository;
        IMapper mapper;
        public GameService(IRepository<Game> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Game, GameDTO>();
                x.CreateMap<GameDTO, Game>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public GameDTO Get(int gameId)
        {
            return mapper.Map<Game, GameDTO>(repository.Get(gameId));
        }

        public IEnumerable<GameDTO> GetAll()
        {
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
