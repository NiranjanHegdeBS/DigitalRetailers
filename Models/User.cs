using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Models
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public string userType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime userAdded { get; set; }
    }
}
