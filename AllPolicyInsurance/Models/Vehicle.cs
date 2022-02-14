using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllPolicyInsurance.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(4)]
        public string Year { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Make { get; set; }
        
        public int InsurancePolicyId { get; set; }

        [ForeignKey("InsurancePolicyId")]
        public virtual InsurancePolicy InsurancePolicy { get; set; }

        //public string Manufactor { get; set; }
    }
}