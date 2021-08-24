using System;
using System.Collections.Generic;
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
        public List<Claim> _claimsRepo = new List<Claim>();

        public List<Claim> SeeAllClaims()
        {
            return _claimsRepo;
        }

        public Claim GetClaimByClaimId(int claimId)
        {
            return _claimsRepo.FindLast(c => c.ClaimID == claimId);
        }

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
                _claimsRepo.Add(claim);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Queue<> = new Queue<>;
        
    }
}
