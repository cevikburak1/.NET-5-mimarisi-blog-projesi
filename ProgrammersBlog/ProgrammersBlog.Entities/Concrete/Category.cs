using ProgrammersBlog.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
   public class Category : EntityBase,IEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public  ICollection<Article> Articles { get; set; }

    }
}
