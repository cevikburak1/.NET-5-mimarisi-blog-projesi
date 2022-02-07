using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
  public  interface IUnitOfWork:IAsyncDisposable
    {
        IarticleRepositroy Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepositroy Comments { get; }
     
        Task<int> SaveAsync();
    }
}
