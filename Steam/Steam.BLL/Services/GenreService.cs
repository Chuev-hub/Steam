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
    public class GenreService : IService<GenreDTO>
    {
        IRepository<Genre> repository;
        IMapper mapper;
        public GenreService(IRepository<Genre> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Genre, GenreDTO>();
                x.CreateMap<GenreDTO, Genre>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public GenreDTO Get(int genreId)
        {
            return mapper.Map<Genre, GenreDTO>(repository.Get(genreId));
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(GenreDTO genreDTO)
        {
            repository.CreateOrUpdate(mapper.Map<GenreDTO, Genre>(genreDTO));
            repository.SaveChanges();
        }

        public GenreDTO Delete(GenreDTO genreDTO)
        {
            repository.Delete(mapper.Map<GenreDTO, Genre>(genreDTO));
            repository.SaveChanges();
            return genreDTO;
        }




    }
}
