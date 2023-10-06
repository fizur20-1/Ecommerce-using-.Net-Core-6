using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTO
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? category { get; set; }
        [Required]
        public string? SubCategory { get; set; }
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool IsDeleted { get; set; }



    }
}