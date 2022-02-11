using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }

        //public string Manufactor { get; set; }
    }
}