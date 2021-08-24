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
        // public List<Claim> _claimsRepo = new List<Claim>();

        //public List<Claim> SeeAllClaims()
        //{
        //DataTable claimsTable = new DataTable("Claims");

        //DataColumn claimId = new DataColumn("Claim ID");
        //claimId.DataType = typeof(int);
        //DataColumn claimType = new DataColumn("Type");
        //claimType.DataType = typeof(string);
        //DataColumn description = new DataColumn("Description");
        //description.DataType = typeof(string);
        //DataColumn amount = new DataColumn("Amount");
        //amount.DataType = typeof(decimal);
        //DataColumn dateOfIncident = new DataColumn("Date of Incident");
        //dateOfIncident.DataType = typeof(DateTime);
        //DataColumn dateOfClaim = new DataColumn("Date of Claim");
        //dateOfClaim.DataType = typeof(DateTime);
        //DataColumn isValid = new DataColumn("Is Valid");
        //isValid.DataType = typeof(bool);

        //return;
        //}

        
        Queue<string> _claimsQueue = new Queue<string>();
        public Claim GetClaimByClaimId(int claimId)
        {
            return Queue.Dequeue( claimId);
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
                _claimsQueue.Enqueue(claim);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
