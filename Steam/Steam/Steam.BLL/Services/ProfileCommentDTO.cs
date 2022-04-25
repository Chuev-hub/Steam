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
    public class ProfileCommentService : IService<ProfileCommentDTO>
    {
        IRepository<ProfileComment> repository;
        IMapper mapper;
        public ProfileCommentService(IRepository<ProfileComment> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<ProfileComment, ProfileCommentDTO>();
                x.CreateMap<ProfileCommentDTO, ProfileComment>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public ProfileCommentDTO Get(int profileCommentId)
        {
            return mapper.Map<ProfileComment, ProfileCommentDTO>(repository.Get(profileCommentId));
        }

        public IEnumerable<ProfileCommentDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ProfileComment>, IEnumerable<ProfileCommentDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(ProfileCommentDTO profileCommentDTO)
        {
            repository.CreateOrUpdate(mapper.Map<ProfileCommentDTO, ProfileComment>(profileCommentDTO));
            repository.SaveChanges();
        }

        public ProfileCommentDTO Delete(ProfileCommentDTO profileCommentDTO)
        {
            repository.Delete(mapper.Map<ProfileCommentDTO, ProfileComment>(profileCommentDTO));
            repository.SaveChanges();
            return profileCommentDTO;
        }




    }
}
