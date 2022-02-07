using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Complex_Type
{
    public enum  OrderBy
    {
        [Display(Name = "Tarih")]
        Date = 1,
        [Display(Name = "Okunma Saysı")]
        ViewCount = 2,
        [Display(Name = "Yorum Sayısı")]
        CommentCount = 3,
    }
}
