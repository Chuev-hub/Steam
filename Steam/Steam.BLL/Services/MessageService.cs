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
    public class MessageService : IService<MessageDTO>
    {
        IRepository<Message> repository;
        IMapper mapper;
        public MessageService(IRepository<Message> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Message, MessageDTO>();
                x.CreateMap<MessageDTO, Message>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public MessageDTO Get(int messageId)
        {
            return mapper.Map<Message, MessageDTO>(repository.Get(messageId));
        }

        public IEnumerable<MessageDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(MessageDTO messageDTO)
        {
            repository.CreateOrUpdate(mapper.Map<MessageDTO, Message>(messageDTO));
            repository.SaveChanges();
        }

        public MessageDTO Delete(MessageDTO messageDTO)
        {
            repository.Delete(mapper.Map<MessageDTO, Message>(messageDTO));
            repository.SaveChanges();
            return messageDTO;
        }




    }
}
