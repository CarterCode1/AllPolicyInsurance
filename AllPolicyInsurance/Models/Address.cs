﻿using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Models
{
    public class Address
    {
        [Key]
        public byte AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

    }
}