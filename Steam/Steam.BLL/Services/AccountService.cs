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
    public class AccountService : IService<AccountDTO>
    {
        IRepository<Account> repository;
        IMapper mapper;
        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
            MapperConfiguration mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<Account, AccountDTO>();
                x.CreateMap<AccountDTO, Account>();
            });
            mapper = new Mapper(mapperConfiguration);
        }

        public AccountDTO Get(int accountId)
        {
            return mapper.Map<Account, AccountDTO>(repository.Get(accountId));
        }

        public IEnumerable<AccountDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(repository.GetAll());
        }

        public void CreateOrUpdate(AccountDTO accountDTO)
        {
            repository.CreateOrUpdate(mapper.Map<AccountDTO, Account>(accountDTO));
            repository.SaveChanges();
        }

        public AccountDTO Delete(AccountDTO accountDTO)
        {
            repository.Delete(mapper.Map<AccountDTO, Account>(accountDTO));
            repository.SaveChanges();
            return accountDTO;
        }

        

        
    }
}
