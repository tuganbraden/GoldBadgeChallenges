using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repository
{
    public class Claim
    {
        public enum ClaimType
        {
            Car = 1,
            Home,
            Theft
        }

        public String ClaimID { get; set; }
        public ClaimType TypeofClaim { get; set; }
        public String Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        { 
            get
            {
                DateOfIncident.AddDays(30);
                if (DateTime.Compare(DateOfClaim, DateOfIncident) > 0 )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Claim() { }

        public Claim(String id, ClaimType type, String desc, decimal amount, DateTime incident, DateTime claim)
        {
            ClaimID = id;
            TypeofClaim = type;
            Description = desc;
            ClaimAmount = amount;
            DateOfIncident = incident;
            DateOfClaim = claim;
        }
    }
}
