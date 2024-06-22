using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommWeb.Models
{
    [Table("Cart")]
    
    public class Cart
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }

    }

    public class CartProductView
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public string Category { get; set; }
        
       
        public string Company { get; set; }
     
        public string Country { get; set; }
    }

    
}
