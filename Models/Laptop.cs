using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Models
{
    public class Laptop
    {
        public int laptopId { get; set; }

        [Required]
        [Display(Name = "Laptop Name")]
        public string laptopName { get; set; }
        
        [Required]
        [Display(Name = "Laptop Price")]
        public float laptopPrice { get; set; }

        [Required]
        [Display(Name = "Laptop Quantity")]
        public int laptopQuantity { get; set; }

        [Required]
        [Display(Name = "Laptop Specification")]
        [MaxLength(5000)]
        public string laptopSpecification { get; set; }

        [Required]
        [Display(Name = "Laptop Display Image Link")]
        public string laptopImageLink { get; set; }

    }
}
