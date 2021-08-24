using _02_Claims_ClassLibrary1;
using System;
using System.Collections.Generic;
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
            // SeedClaim();
            ClaimsAgentMenu();
        }

        //public void SeedClaim()
        //{
        //    Console.WriteLine("Seeding Claims...");

        //    Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 464", 400.00m, 4.25.2018, 4.27.2018);
        //    Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen", 40000.00m, 4.11.2018, 4.12.2018 );
        //    Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00m 4.27.2018, 6.1.2018);
        //}
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
                    EnterNewClaim();
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
            foreach (Claim claim in _claimsRepo.SeeAllClaims())
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\nClaim Type: {claim.ClaimType}\nDescription: {claim.Description}\nClaim Amount:{string.Format("{0:c}", claim.ClaimAmount)}\nDate Of Incident:{claim.DateOfIncident}\nDate Of Claim:{claim.DateOfClaim}\n\n");
            }
        }

        public void NextClaim()
        {
            Console.Clear();
            
        }

        public void EnterNewClaim()
        {
            Console.Clear();

            Claim newclaim = new Claim();

            //Claim ID
            Console.WriteLine("Claim ID:");
            var claimId = Console.ReadLine();

            //ClaimType
            Console.WriteLine("Claim Type: Please choose from the following:\nCar\nHome\nTheft");
            string typeOfClaim = Console.ReadLine();

            //Description
            Console.WriteLine("Detailed description of claim:");
            string description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("Claim amount:");
            var claimAmount = Console.ReadLine();

            //Date of incident
            Console.WriteLine("Date of incident:");
            var dateOfIncident = Console.ReadLine();

            //date of claim
            Console.WriteLine("Date of Claim:");
            var dateOfClaim = Console.ReadLine();

            ClaimsAgentMenu();
            Console.ReadKey();

            try
            {
                var claim = new Claim(Convert.ToInt32(claimId), ClaimType, description, Convert.ToDecimal(claimAmount), Convert.ToDateTime(dateOfIncident), Convert.ToDateTime(dateOfClaim));

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
                Console.WriteLine("Something was wrong with your inut. Please check that Claim ID is a unique number, and that the Claim Amount has no dollar signs. ");
            }




        }
    }
}
