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

        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        
        public int InsurancePolicyId { get; set; }

        [ForeignKey("InsurancePolicyId")]
        public virtual InsurancePolicy InsurancePolicy { get; set; }

        //public string Manufactor { get; set; }
    }
}