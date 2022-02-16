using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllPolicyInsurance.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public int InsurancePolicyId { get; set; }

        [ForeignKey("InsurancePolicyId")]
        public  virtual InsurancePolicy InsurancePolicy { get; set; }

    }
}