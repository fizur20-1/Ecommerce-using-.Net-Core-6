using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? price { get; set; }
        [Required]
        public int? quantity { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
     
        public int Category_Id { get; set; }
        public int Offer_Id { get;set; }
    }
}
