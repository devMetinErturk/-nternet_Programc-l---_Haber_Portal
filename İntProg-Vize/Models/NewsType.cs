using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IntProg_Vize.Models
{
    public class NewsType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Haber Türü 25 karakterden uzun ve boş olamaz!")]
        [MaxLength(25)]
        [DisplayName("Haber Türü :")]
        public string Name { get; set; }
    }
}
 