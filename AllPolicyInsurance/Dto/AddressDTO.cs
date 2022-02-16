using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Dto
{
    public class AddressDTO
    {
        //[Required, RegularExpression(@"\d +[ ](?:[A - Za - z0 - 9.-] +[ ] ?)+(?:Avenue|Lane|Road|Boulevard|Drive|Street|Ave|Dr|Rd|Blvd|Ln|St)\.?",
        //    ErrorMessage = "Invalid {0} format")]
        [Required]
        public string Street { get; set; }

        [Required, RegularExpression(@"(?:[A-Z][a-z.-]+[ ]?)+",
            ErrorMessage = "Invalid {0} format")]
        public string City { get; set; }

        [Required, RegularExpression(@"AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI
                                        |ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT
                                        |NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI
                                        |SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY",
                                    ErrorMessage = "Invalid {0} format")]
        public string State { get; set; }

        [Required, RegularExpression(@"\b\d{5}(?:-\d{4})?\b",
                ErrorMessage = "Invalid {0} format")]
        public string PostalCode { get; set; }
    }
}
