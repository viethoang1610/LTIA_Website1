using System.ComponentModel.DataAnnotations;

namespace LTIA_website.Models
{
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Tên hãng")]
        public string Name { get; set; } = default!;

        [Required, Display(Name = "Mã hãng")]
        public string Code { get; set; } = default!;

        [Required, Display(Name = "Quốc gia")]
        public string Country { get; set; } = default!;
    }
}
