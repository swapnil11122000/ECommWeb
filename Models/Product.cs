using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommWeb.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
