using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_ClassLibrary1
{                               // CRUD goes here:
                                //   create new claim
                                //   read claims (see all)
                                //   update claims -- dont need
                                //   delete claims -- dont need
    public class ClaimsRepo
    {
        Queue<Claim> claimsQ = new Queue<Claim>();
        public bool CreateNewClaim(Claim claim)
        {
            try
            {
                var existingClaim = GetClaimByClaimId(claim.ClaimID);
                if (existingClaim != null)
                {
                    Console.WriteLine("This Claim ID already exisis.");
                    return false;
                }
                claimsQ.Enqueue(claim);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Queue<Claim> AllClaims()
        {
            return claimsQ;
        }
        public Claim GetClaimByClaimId(int claimId)
        {
            return claimsQ.Where(c => c.ClaimID == claimId).FirstOrDefault();
        }
        public Claim SeeNextInQ()
        {
            return claimsQ.Peek();
        }
        public Claim WorkOnNextInQ()
        {
            return claimsQ.Dequeue();
        }
    }
}
