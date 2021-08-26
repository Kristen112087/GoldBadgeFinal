using _02_Claims_ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _02_Claims_UnitTests
{
    [TestClass]
    public class RepoTests
    {
        ClaimsRepo repo = new ClaimsRepo();
        [TestMethod]
        public void TestThatAddClaimToQueue_AddsClaimToQueueSuccessfully()
        {
            var claim = new Claim();
            claim.ClaimID = 1;
            claim.ClaimType = ClaimType.Car;
            claim.Description = "broken";
            claim.ClaimAmount = 500.00m;
            repo.CreateNewClaim(claim);
            var singleClaim = repo.GetClaimByClaimId(1);

            Assert.IsNotNull(claim);
        }
        [TestMethod]
        public void TestThatAllClaims_GetsAllClaims()
        {
            Claim claim;
            claim = new Claim();
            claim.ClaimID = 1;
            claim.ClaimType = ClaimType.Car;
            claim.Description = "broken";
            claim.ClaimAmount = 500.00m;
            repo.CreateNewClaim(claim);

            claim = new Claim();
            claim.ClaimID = 2;
            claim.ClaimType = ClaimType.Home;
            claim.Description = "broke AF";
            claim.ClaimAmount = 5000.00m;
            repo.CreateNewClaim(claim);

            Assert.IsTrue(repo.AllClaims().Count == 2);
        }
        [TestMethod]
        public void TestThatSeeNextInQ_DoesNotTakeClaimOutOfQ()
        {
            Claim claim;
            claim = new Claim();
            claim.ClaimID = 1;
            claim.ClaimType = ClaimType.Car;
            claim.Description = "broken";
            claim.ClaimAmount = 500.00m;
            repo.CreateNewClaim(claim);
            repo.SeeNextInQ();

            Assert.AreEqual(1, repo.AllClaims().Count);
        }
        [TestMethod]
        public void TestThatWorkOnNextInQ_TakesNextOutOfQ()
        {
            Claim claim;
            claim = new Claim();
            claim.ClaimID = 1;
            claim.ClaimType = ClaimType.Car;
            claim.Description = "broken";
            claim.ClaimAmount = 500.00m;
            repo.CreateNewClaim(claim);
            repo.WorkOnNextInQ();

            Assert.AreEqual(0, repo.AllClaims().Count);
        }
    }
}
