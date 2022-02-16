using AllPolicyInsurance.Models;
using System;
using System.Collections.Generic;

namespace AllPolicyInsurance.Core
{
    public abstract class RegulatoryManager
    {

        public RegulatoryManager()
        {
            StateRegulatoryCode = new Dictionary<int, string>()
            {
                { 0, "You drive too slow for our liking." },
                { 1, "Unable provide insurance due to multiple moving violations."},
                { 2, "Suspended Drivers license." },
                { 3, "Delay In Reporting Accident." },
                { 4, "Driving Outside Geographical Area." },
                { 5, "Providing incorrect information." },
                { 6, "Cannot insure due to child support deliquency." },
                { 7, "You should own a bicycle." },
                { 8, "Unable to verify Drivers license through Department of Motor Vehicles." },
                { 9, "Person is deceased." }
            };
        }

        public string  DeclinedExplanation { get; set; }

        public Dictionary<int, string> StateRegulatoryCode { get; set; }

        public bool VerifyStateRegulations(InsurancePolicy insurancePolicy)
        {
            // If the drivers license is even, our stubbing logic will approve state regulations
            if(int.Parse(insurancePolicy.DriversLicenseNumber) % 2 == 0)
            {
                return true;
            }
            else
            {
                var random = new Random();
                DeclinedExplanation = StateRegulatoryCode[random.Next(10)];

                return false;
            }
        }
    }
}
