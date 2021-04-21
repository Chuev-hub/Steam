using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.BLL.Services
{
    public interface IService<TDTO> where TDTO : class
    {
        TDTO Get(int sectionId);

        IEnumerable<TDTO> GetAll();

        TDTO Delete(TDTO sectionDTO);

        void CreateOrUpdate(TDTO sectionDTO);
    }
}
