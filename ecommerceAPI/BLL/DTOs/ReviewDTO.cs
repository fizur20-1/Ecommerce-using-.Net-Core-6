using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Rating { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }

        public string Suggestion { get; set; }
    }
}
