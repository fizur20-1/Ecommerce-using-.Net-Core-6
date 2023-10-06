using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? price { get; set; }
        [Required]
        public int?  quantity { get; set; }
        [Required]
        public string? Description { get; set; }
        
        public string? ImageUrl { get; set; }
        [ForeignKey("Category")]
        public  int Category_Id { get; set; }

        [ForeignKey("Offer")]
        public int Offer_Id { get; set; }

        public virtual Category Category { get; set; }
        public virtual Offer Offer { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
       
        public Product() {
            Reviews = new List<Review>();
          
        }
        
      

    }
}
