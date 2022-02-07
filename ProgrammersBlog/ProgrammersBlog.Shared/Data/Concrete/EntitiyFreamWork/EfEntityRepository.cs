using ProgrammersBlog.Shared.Entities.Abstrack;

namespace ProgrammersBlog.Shared.Data.Concrete.EntitiyFreamWork
{
    public class EfEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
    }
}