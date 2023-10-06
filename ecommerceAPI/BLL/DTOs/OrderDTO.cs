using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
    
        public DateTime OrderDate { get; set; }
     
        public int Cart_Id { get; set; }

    }
}
