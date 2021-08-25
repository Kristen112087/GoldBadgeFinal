using _03_Badges_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_App
{
    public class BadgesUI
    {
        BadgesRepo _BadgesRepo = new BadgesRepo();

        public void Run()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin! What would you like to do?\n\n1. Add a badge.\n2. Edit a badge.\n3. List all Badges.");
            var securityAdminInput = Console.ReadLine();
            ProcessMenuChoice(securityAdminInput);
        }

        public void ProcessMenuChoice(string securityAdminInput)
        {
            switch (securityAdminInput)
            {
                case "1":
                    AddABadgeToDictionary();
                    break;
                case "2":
                    EditABadge();
                    break;
                case "3":
                    GetAllBadges();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option\nPress any key to continue");
                    Console.ReadLine();
                    break;
            }
        }

        public void AddABadgeToDictionary()
        {
            Console.Clear();
            _BadgesRepo.CreateNewBadge(1234);
            Console.WriteLine("What is the number on the Badge you would like to add?");
            var badgeNum = Console.ReadLine();

            Console.WriteLine("List a door it needs access to:");
            var doorAccess = Console.ReadLine();

            Console.WriteLine("Does this badge need access to any other doors? (y/n)");
            var yesOrNoAddABadge = Console.ReadLine();

            if (yesOrNoAddABadge)
            {

            }
            AddDoorsToBadge();
            // if/ else OR switch case?
            // Y/yes = ask above question again
            // N/No = back to main menu
            

            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();
        }

        public void AddAnotherDoorToBadge()
        {
            
            _BadgesRepo.AddDoorsToBadge(badgeNum, List<door>);
        }
        public void EditABadge()
        {
            Console.Clear();
            _BadgesRepo.GetBadgeByBadgeId(badgeNum);
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();

        }
        public void GetAllBadges()
        {
            Console.Clear();
            var allBadges = _BadgesRepo.GetAllBadges();
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();

        }

    }
}
