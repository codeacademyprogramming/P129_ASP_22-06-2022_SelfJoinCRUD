using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace P129Allup.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:255)]
        public string Image { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
