using AllPolicyInsurance.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllPolicyInsurance.Models
{
    public class InsurancePolicy
    {

        public InsurancePolicy()
        {
            Vehicles = new List<Vehicle>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        [Range(0, Int64.MaxValue, ErrorMessage = "{0} should only contain number values")]
        [StringLength(8, ErrorMessage = "Invalid {0} format")]
        public string DriversLicenseNumber { get; set; }

        [Required]
        public decimal PremiumPrice { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual Address Address { get; set; }
    }
}
