using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
  public  class EmailSendDto
    {
        [DisplayName("Ad-Soyad")]
        [Required(ErrorMessage ="{0} Alanı boş geçilemez")]
        [MaxLength(60,ErrorMessage ="{0} Alanı en fazla {1} Karakterden Oluşmalıdır")]
        [MinLength(2,ErrorMessage ="{0} Alanı en az {1} Karakterden Oluşmalıdır")]
        public string Name { get; set; }

        [DisplayName("E-Posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Alanı boş geçilemez")]
        [MaxLength(500, ErrorMessage = "{0} Alanı en fazla {1} Karakterden Oluşmalıdır")]
        [MinLength(2, ErrorMessage = "{0} Alanı en az {1} Karakterden Oluşmalıdır")]
        public string EMail { get; set; }

        [DisplayName("Konu")]
        [Required(ErrorMessage = "{0} Alanı boş geçilemez")]
        [MaxLength(100, ErrorMessage = "{0} Alanı en fazla {1} Karakterden Oluşmalıdır")]
        [MinLength(2, ErrorMessage = "{0} Alanı en az {1} Karakterden Oluşmalıdır")]
        public string Subjet { get; set; }

        [DisplayName("Message")]
        [Required(ErrorMessage = "{0} Alanı boş geçilemez")]
        [MaxLength(1500, ErrorMessage = "{0} Alanı en fazla {1} Karakterden Oluşmalıdır")]
        [MinLength(2, ErrorMessage = "{0} Alanı en az {1} Karakterden Oluşmalıdır")]
        public string Message { get; set; }
    }
}
