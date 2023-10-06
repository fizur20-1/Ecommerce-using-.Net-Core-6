using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDTO
    {
        [Key]
        public int Id { get; set; }
 
        public DateTime CreatedDate { get; set; }
        public bool Ordered { get; set; }
        public int Customer_Id { get; set; }
        


    }
}
