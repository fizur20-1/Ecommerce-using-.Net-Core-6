using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public DateTime OrderDate { get; set; }

        // jst delete cUSTOMER id which was one of the foreign key here 
 
        
        [ForeignKey("Cart")]
        public int Cart_Id { get; set; }
        public virtual Cart Cart { get; set; }


       


    }
}
