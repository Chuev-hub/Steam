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
    public class DeveloperService : IService<DeveloperDTO>
    {
        IRepository<Developer> repository;
        IMapper mapper;
        public DeveloperService(IRepository<Developer> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Developer, DeveloperDTO>();
                x.CreateMap<DeveloperDTO, Developer>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public DeveloperDTO Get(int developerId)
        {
            return mapper.Map<Developer, DeveloperDTO>(repository.Get(developerId));
        }

        public IEnumerable<DeveloperDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(DeveloperDTO developerDTO)
        {
            repository.CreateOrUpdate(mapper.Map<DeveloperDTO, Developer>(developerDTO));
            repository.SaveChanges();
        }

        public DeveloperDTO Delete(DeveloperDTO developerDTO)
        {
            repository.Delete(mapper.Map<DeveloperDTO, Developer>(developerDTO));
            repository.SaveChanges();
            return developerDTO;
        }




    }
}
