using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartItemDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; }
    }
}
