using System;
using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Dto
{
    public class AddressDTO
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Invalid {0} format")]
        public string State { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid {0}. Numbers only required")]
        [StringLength(5, ErrorMessage = "Invalid {0} format")]
        public string PostalCode { get; set; }
    }
}
