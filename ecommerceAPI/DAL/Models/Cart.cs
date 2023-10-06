using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool Ordered { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }//might delete
        public virtual Customer Customer { get; set; }

       
        public virtual ICollection<CartItem> CartItems { get; set; }
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

    }
}
