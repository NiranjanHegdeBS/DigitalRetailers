using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Models
{
    public class Transaction
    {
        public int transactionId { get; set; }

        [Required]
        public string fullName { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string address2 { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string zip { get; set; }

        [Required]
        public string cc_number { get; set; }

        public float total { get; set; }

        public string purchasedItems { get; set; }

        public ICollection<Laptop> laptops { get; set; }

        public int userId { get; set; }

    }
}
