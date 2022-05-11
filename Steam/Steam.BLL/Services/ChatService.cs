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
        ChatRepository repository;
        IMapper mapper;
        public ChatService(IRepository<Chat> repository)
        {
            this.repository = repository as ChatRepository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Chat, ChatDTO>();
                x.CreateMap<ChatDTO, Chat>();
                x.CreateMap<Message, MessageDTO>();
                x.CreateMap<MessageDTO, Message>();
                x.CreateMap<Account, AccountDTO>();
                x.CreateMap<AccountDTO, Account>();
                x.CreateMap<Game, GameDTO>();
                x.CreateMap<GameDTO, Game>();
                x.CreateMap<Screenshot, ScreenshotDTO>();
                x.CreateMap<ScreenshotDTO, Screenshot>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public ChatDTO Get(int chatId)
        {
            repository.ReadAll();
            return mapper.Map<Chat, ChatDTO>(repository.Get(chatId));
        }

        public IEnumerable<ChatDTO> GetAll()
        {
            repository.ReadAll();
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
