using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
  public  class CategoryUpdateDto
    {
        [Required]
        public int ıd { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} {1} Karakterden Büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük olamaz")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük olamaz")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} Karakterden Büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Küçük olamaz")]
        public string Note { get; set; }

        [DisplayName("Aktif mi ?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi mi ?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        public bool IsDeleted { get; set; }
    }
}
