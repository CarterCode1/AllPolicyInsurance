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

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DriversLicenseNumber { get; set; }

        public decimal PremiumPrice { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual Address Address { get; set; }
    }
}
