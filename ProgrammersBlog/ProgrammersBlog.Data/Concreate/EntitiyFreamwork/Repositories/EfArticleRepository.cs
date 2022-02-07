using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntitiyFreamWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concreate
{
    public class EfArticleRepository : EfEntityRepositoryBase<Article>, IarticleRepositroy
    {
        public EfArticleRepository(DbContext context) : base(context)
        {
            
        }
    }
}
