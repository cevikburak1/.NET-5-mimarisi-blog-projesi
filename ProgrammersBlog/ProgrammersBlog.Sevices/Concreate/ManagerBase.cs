using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Sevices.Concreate
{
   public class ManagerBase
    {
        protected IUnitOfWork UnitofWork { get; }
        protected IMapper Mapper { get; }

      
        public ManagerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitofWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
