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
    public class ScreenshotService : IService<ScreenshotDTO>
    {
        IRepository<Screenshot> repository;
        IMapper mapper;
        public ScreenshotService(IRepository<Screenshot> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Screenshot, ScreenshotDTO>();
                x.CreateMap<ScreenshotDTO, Screenshot>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public ScreenshotDTO Get(int screenshotId)
        {
            return mapper.Map<Screenshot, ScreenshotDTO>(repository.Get(screenshotId));
        }

        public IEnumerable<ScreenshotDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Screenshot>, IEnumerable<ScreenshotDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(ScreenshotDTO screenshotDTO)
        {
            repository.CreateOrUpdate(mapper.Map<ScreenshotDTO, Screenshot>(screenshotDTO));
            repository.SaveChanges();
        }

        public ScreenshotDTO Delete(ScreenshotDTO screenshotDTO)
        {
            repository.Delete(mapper.Map<ScreenshotDTO, Screenshot>(screenshotDTO));
            repository.SaveChanges();
            return screenshotDTO;
        }




    }
}
