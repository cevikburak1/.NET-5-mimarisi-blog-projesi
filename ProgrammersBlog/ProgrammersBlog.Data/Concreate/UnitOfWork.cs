using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concreate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository _articleRepositroy;
        private EfCategoryRepository _categoryRepositroy;
        private EfCommentRepository _commentRepositroy;
      

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        public IarticleRepositroy Articles => _articleRepositroy ?? new EfArticleRepository(_context);//Eger elimizde articlerepositroy varsa bunu dönüyoruz ancak bu deger yoksa veyahut null
                                                                                                      //ise yeni bir articlerepository oluşturarak kullanıcıya gönderiyoruz

        public ICategoryRepository Categories => _categoryRepositroy ?? new EfCategoryRepository(_context);

        public ICommentRepositroy Comments => _commentRepositroy ?? new EfCommentRepository(_context);

      

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
