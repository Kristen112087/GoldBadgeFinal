using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_ClassLibrary1
{
    public enum ClaimType { Car, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set;}
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        bool IsValid { 
            get {
                var timeSinceIncident = DateOfClaim - DateOfIncident;
                var daysSinceIncident = timeSinceIncident.Days;
                if(daysSinceIncident <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
        }
        public Claim() { }
        public Claim(int claimId, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimId;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        //public bool Valid
        //{
        //    if dateofclaim <= dateofincident+30
        //    {
        //    return true;
        //    }
        //    else
        //    {
        //    return false;
        //    }
        //}

    }
}
