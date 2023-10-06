
using System.ComponentModel.DataAnnotations;


namespace DAL.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public Customer()
        {
            Reviews = new List<Review>();
            //Orders = new List<Order>();
            Carts = new List<Cart>();
        }
    }
}
