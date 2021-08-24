using _02_Claims_ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_App
{
    public class ClaimsUI
    {
        ClaimsRepo _claimsRepo = new ClaimsRepo();
        public void Run()
        {
            SeedClaim();
            ClaimsAgentMenu();
        }

        public void SeedClaim()
        {
            Console.WriteLine("Seeding Claims...");

            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 464", 400.00m, new DateTime(2018,2,25), new DateTime(2018, 2, 26));
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen", 40000.00m, new DateTime(2018, 2, 25), new DateTime(2018, 2, 26));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00m, new DateTime(2018, 2, 25), new DateTime(2018, 2, 26));
            _claimsRepo.CreateNewClaim(claim1);
            _claimsRepo.CreateNewClaim(claim2);
            _claimsRepo.CreateNewClaim(claim3);

        }
        public void ClaimsAgentMenu()
        {
            Console.Clear();
            Console.WriteLine("Please choose from the below items:\n\n1. See all claims\n2. Take care of next claim\n3. Enter a new claim.");
            var agentInput = Console.ReadLine();
            ProcessMenuChoice(agentInput);
        }
         public void ProcessMenuChoice(string agentChoice)
        {
            switch (agentChoice)
            {
                case "1":
                    SeeAllClaims();
                    break;
                case "2":
                    NextClaim();
                    break;
                case "3":
                    AddClaimToQueue();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection\nPress any key to continue");
                    Console.ReadLine();
                    break;
            }
         }

        public void SeeAllClaims()
        {
            
            Console.Clear();
            var allClaims = _claimsRepo.AllClaims();

            Console.WriteLine($"{"ClaimID".PadRight(10)}{"Type".PadRight(8)}{"Description".PadRight(30)}{"Amount".PadLeft(10)}{"Date Of Incident".PadLeft(20)}{"Date Of Claim".PadLeft(20)}{"Is Valid".PadLeft(12)}\n");
            foreach (var claim in allClaims)
            {
                Console.WriteLine($"{claim.ClaimID.ToString().PadRight(10)}{claim.ClaimType.ToString().PadRight(8)}{claim.Description.PadRight(30)}{string.Format("{0:c}",claim.ClaimAmount).PadLeft(10)}{claim.DateOfIncident.ToString("MM/dd/yyyy").PadLeft(20)}{claim.DateOfClaim.ToString("MM/dd/yyyy").PadLeft(20)}{claim.IsValid.ToString().PadLeft(12)}");
            }



            Console.WriteLine("\n\nPress any key to return to main menu");
            Console.ReadLine();
            ClaimsAgentMenu();
        }

        public void NextClaim()
        {
            Console.Clear();
            var nextClaim = _claimsRepo.SeeNextInQ();
            Console.WriteLine("Here are the details for the next claim to be handled:\n\n");
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}");
            Console.WriteLine($"Claim Type: {nextClaim.ClaimType}");
            Console.WriteLine($"Claim Description: {nextClaim.Description}");
            Console.WriteLine($"Claim Amount: {string.Format("{0:c}", nextClaim.ClaimAmount)}");
            Console.WriteLine($"Date of Incident: {nextClaim.DateOfIncident.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Date of Claim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Is Valid: {nextClaim.IsValid}\n\n");
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");

            var agentAnswer = Console.ReadLine();
            //if (agentAnswer = "y")
            //{
            //    return _claimsRepo.WorkOnNextClaim();
            //}
            //else
            //{
            //    ClaimsAgentMenu();
            //}
            //// If no, back to main menu
            //Console.ReadKey();
            //ClaimsAgentMenu();

            switch (agentAnswer)
            {
                case "y":
                    _claimsRepo.WorkOnNextInQ();
                    ClaimsAgentMenu();
                    break;
                case "n":
                    Console.WriteLine("Press any key to go to main menu");
                    ClaimsAgentMenu();
                    break;
            }
            
        }

        public void AddClaimToQueue()
        {
            Console.Clear();

            Claim newclaim = new Claim();

            Console.WriteLine("Claim ID:");
            var claimId = Console.ReadLine();

            Console.WriteLine("Claim Type: Please choose from the following:\nCar\nHome\nTheft");
            string typeOfClaim = Console.ReadLine();

            Console.WriteLine("Detailed description of claim:");
            string description = Console.ReadLine();

            Console.WriteLine("Claim amount:");
            var claimAmount = Console.ReadLine();

            Console.WriteLine("Date of incident:");
            var dateOfIncident = Console.ReadLine();

            Console.WriteLine("Date of Claim:");
            var dateOfClaim = Console.ReadLine();

            
            try
            {
                ClaimType claimType = ClaimType.Car;
                if (typeOfClaim.ToLower() == "car")
                {
                    claimType = ClaimType.Car;
                }
                else if (typeOfClaim.ToLower() == "home")
                {
                    claimType = ClaimType.Home;
                }
                else if (typeOfClaim.ToLower() == "theft")
                {
                    claimType = ClaimType.Theft;
                }
                var claim = new Claim(Convert.ToInt32(claimId), claimType, description, Convert.ToDecimal(claimAmount), Convert.ToDateTime(dateOfIncident), Convert.ToDateTime(dateOfClaim));

                var success = _claimsRepo.CreateNewClaim(claim);

                if (success == true)
                {
                    Console.WriteLine("Claim has been added successfully. Press any key to return to main menu.");
                }
                else
                {
                    Console.WriteLine("Claim has NOT been added!! Press any key to return to main menu and try again.");
                }
            }
            catch
            {
                Console.WriteLine("Something was wrong with your inut. Please check that Claim ID is a unique number, and that the Claim Amount has no dollar signs.");
            }

            
            Console.ReadKey();
            ClaimsAgentMenu();



        }
    }
}
