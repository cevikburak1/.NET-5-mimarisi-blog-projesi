using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntitiyFreamWork;
using ProgrammersBlog.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concreate
{
 public  class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepositroy
    {
        public EfCommentRepository(DbContext context) : base(context)
        {

        }
    }
}
