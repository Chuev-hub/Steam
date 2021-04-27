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
    public class ChatService : IService<ChatDTO>
    {
        IRepository<Chat> repository;
        IMapper mapper;
        public ChatService(IRepository<Chat> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Chat, ChatDTO>();
                x.CreateMap<ChatDTO, Chat>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public ChatDTO Get(int chatId)
        {
            return mapper.Map<Chat, ChatDTO>(repository.Get(chatId));
        }

        public IEnumerable<ChatDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Chat>, IEnumerable<ChatDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(ChatDTO chatDTO)
        {
            repository.CreateOrUpdate(mapper.Map<ChatDTO, Chat>(chatDTO));
            repository.SaveChanges();
        }

        public ChatDTO Delete(ChatDTO chatDTO)
        {
            repository.Delete(mapper.Map<ChatDTO, Chat>(chatDTO));
            repository.SaveChanges();
            return chatDTO;
        }
    }
}
