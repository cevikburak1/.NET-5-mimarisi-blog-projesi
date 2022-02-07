using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
  public class AboutUsPageInfo
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string Header { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(1500, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string Content { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Tagları")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string SeoTags { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez")]
        [MaxLength(60, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz")]
        public string SeoAuthor { get; set; }


    }
}
