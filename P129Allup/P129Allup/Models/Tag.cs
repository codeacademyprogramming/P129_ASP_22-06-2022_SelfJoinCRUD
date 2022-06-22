using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P129Allup.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [StringLength(maximumLength:255)]
        [Required]
        public string Name { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }
    }
}
