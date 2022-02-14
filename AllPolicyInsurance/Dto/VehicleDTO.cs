using System;
using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Dto
{
    public class VehicleDTO
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid {0}. Numbers only required")]
        [StringLength(4, ErrorMessage = "Invalid {0} format")]
        public string Year { get; set; }
        
        [Required]
        public string Model { get; set; }

        [Required]
        public string Make { get; set; }
    }
}
