using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
   public interface ICommentRepositroy : IEntityRepository<Comment>
    {

    }
}
