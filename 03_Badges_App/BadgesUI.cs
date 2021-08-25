﻿using _03_Badges_ClassLibrary;
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
            Console.WriteLine("What is the number of the Badge you would like to add?");
            var badgeNum = Console.ReadLine();

            Console.WriteLine("List a door it needs access to:");
            var doorAccess = Console.ReadLine().ToLower();

            Console.WriteLine("Does this badge need access to any other doors? (y/n)");
            var yesOrNoAddABadge = Console.ReadLine();

            bool addDoorToBadge = true;
            while (addDoorToBadge)
            {
                switch (yesOrNoAddABadge)
                {
                    case "y":
                    case "yes":
                        AddAnotherDoorToBadge(); // <-- not doing anything after...?
                        break;
                    case "n":
                    case "no":
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();
        }

        public void AddAnotherDoorToBadge()
        {
            BadgesRepo badges = new BadgesRepo(); // <---here is where i need to list out the badge info from line 67 for securityAdmin to update......
            badges.AddAnotherDoorToBadge(); // <--- not sure whats wrong? 

            // badges.GetBadgeByBadgeId(1234);
            // badges.UpdateBadge();
        }

        public void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you'd like to update?");
            var badgeNum = Console.ReadLine();
            // GetBadgeById();\n
            // show badge information
            Console.WriteLine("What would you like to do?\n1. Remove a door\n2. Add a door.");
            var whatToUpdate = Console.ReadLine();
            switch (whatToUpdate)
            {
                case "1":
                    // RemoveDoorOnBadge();
                    break;
                case "2":
                    AddAnotherDoorToBadge();
                    break;
                default:
                    Console.WriteLine("Please make a valid selection. Press any key to continue");
                    break;
            }
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();
        }
        //public void RemoveDoorOnBadge()
        //{
        //    Console.Clear();

        //    Get

        //    var badgeNum = _BadgesRepo.RemoveDoorFromBadge();
        //}
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
