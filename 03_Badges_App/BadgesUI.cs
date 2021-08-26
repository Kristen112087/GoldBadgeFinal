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
            Console.WriteLine("What is the number of the Badge you would like to add?");
            var badgeNum = Console.ReadLine();
            _BadgesRepo.CreateNewBadge(Convert.ToInt32(badgeNum));
            bool addDoorToBadge = true;
            var currentDoors = _BadgesRepo.GetDoorsByBadgeId(Convert.ToInt32(badgeNum));
            while (addDoorToBadge)
            {
                Console.WriteLine("List a door it needs access to:");
                var doorAccess = Console.ReadLine().ToLower();
                currentDoors.Add(doorAccess);
                Console.WriteLine("Does this badge need access to any other doors? (y/n)");
                var yesOrNoAddABadge = Console.ReadLine();
                
                switch (yesOrNoAddABadge)
                {
                    case "y":
                    case "yes":
                        continue;
                    case "n":
                    case "no":
                        addDoorToBadge = false;
                        break;
                    default:
                        continue;
                }
            }
            _BadgesRepo.UpdateBadge(Convert.ToInt32(badgeNum), currentDoors);
            Console.WriteLine("\nPress any key to return to Main Menu");
            Console.ReadKey();
            MainMenu();
        }
        public void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number you'd like to update?");
            var badgeNum = Console.ReadLine();
            Console.WriteLine($"{badgeNum} has access to doors {string.Join(" & ",_BadgesRepo.GetDoorsByBadgeId(Convert.ToInt32(badgeNum)))}");
            Console.WriteLine("What would you like to do?\n1. Remove a door\n2. Add a door.");
            var whatToUpdate = Console.ReadLine();
            switch (whatToUpdate)
            {
                case "1":
                    Console.WriteLine("What door would you like to remove?");
                    var door = Console.ReadLine();
                    var successfulRemove = _BadgesRepo.RemoveDoorFromBadge(Convert.ToInt32(badgeNum), door);
                    if (successfulRemove)
                    {
                        Console.WriteLine("Door removed!");
                    }
                    else
                    {
                        Console.WriteLine("Door was not removed. Please make sure you typed door name correctly.");
                    }
                    Console.WriteLine($"{badgeNum} has access to doors {string.Join(" & ", _BadgesRepo.GetDoorsByBadgeId(Convert.ToInt32(badgeNum)))}");
                    break;
                case "2":
                    Console.WriteLine("What door would you like to add?");
                    var door1 = Console.ReadLine();
                    var successfulAdd = _BadgesRepo.AddDoorToBadge(Convert.ToInt32(badgeNum), door1);
                    if (successfulAdd)
                    {
                        Console.WriteLine("Door added!");
                    }
                    else
                    {
                        Console.WriteLine("Door was not added. Please make sure you typed door name correctly.");
                    }
                    Console.WriteLine($"{badgeNum} has access to doors {string.Join(" & ", _BadgesRepo.GetDoorsByBadgeId(Convert.ToInt32(badgeNum)))}");
                    break;
                default:
                    Console.WriteLine("Please make a valid selection. Press any key to continue");
                    break;
            }
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
            MainMenu();
        }
        public void GetAllBadges()
        {
            Console.Clear();
            var allBadgeAndDoorList = _BadgesRepo.GetAllBadges();

            Console.Write("Badge #".PadRight(20));
            Console.WriteLine("Door Access");
            foreach (var badgeAndDoors in allBadgeAndDoorList)
            {
                Console.WriteLine($"{badgeAndDoors.Key.ToString().PadRight(20)}{string.Join(", ", badgeAndDoors.Value)}");
            }
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            MainMenu();
        }
    }
}
