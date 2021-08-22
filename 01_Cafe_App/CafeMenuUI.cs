using _01_Cafe_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_App
{
    public class CafeMenuUI
    {
        CafeMenuRepo _repo = new CafeMenuRepo();

        public void Run()
        {
            CafeConsoleMenu();
        }
        public void CafeConsoleMenu()
        {
            Console.Clear();
            Console.WriteLine("Would you like to:\n\n1. Create a new meal for the cafe menu\n2. See all meals on the menu\n3. Remove meal from Cafe menu");
            var userInput = Console.ReadLine();
            ProcessMenuChoice(userInput);
        }
        public void ProcessMenuChoice(string menuChoice)
        {
            switch (menuChoice)
            {
                case "1":
                    CreateNewItem();
                    break;
                case "2":
                    AllMenuItems();
                    break;
                case "3":
                    RemoveMealFromMenu();
                    break;
                default:
                    Console.WriteLine("Not a valid menu item, press [enter] key to try again");
                    Console.ReadLine();
                    CafeConsoleMenu();
                    break;
            }
        }

        public void CreateNewItem()
        {
            Console.Clear();

            CafeMenuItem items = new CafeMenuItem();

            //Meal Number mealNumber
            Console.WriteLine("Meal Number: ");
            var mealNumber = Console.ReadLine();

            //Meal Name mealName
            Console.WriteLine("Meal Name: ");
            string mealName = Console.ReadLine();

            //Meal Desctiption mealDescription
            Console.WriteLine("Meal Description: ");
            string mealDescription = Console.ReadLine();

            //Ingredients ingredients
            Console.WriteLine("Ingredients: ");
            var ingredients = Console.ReadLine();

            //Price price
            Console.WriteLine("Meal Price: ");
            var price = Console.ReadLine();

            try
            {
                var cafeMenuItem = new CafeMenuItem(Convert.ToInt32(mealNumber), mealName, mealDescription, ingredients, Convert.ToDecimal(price));
                var success = _repo.AddMenuItem(cafeMenuItem);

                Console.WriteLine($"Your menu item was{(success ? "" : " NOT")} added successfully. Press [enter] key to return to the main menu.");
                Console.ReadLine();
                CafeConsoleMenu();
            }
            catch
            {
                Console.WriteLine("There was a problem with your input. Please check that the meal number is unique, is a real number, and that the price contains no dollar signs. Press [enter] key to try again.");
                Console.ReadLine();
                CreateNewItem();
            }
            

        }
        public void AllMenuItems()
        {
            Console.Clear();            
            foreach (CafeMenuItem item in _repo.GetAllMenuItems())
            {
                Console.WriteLine($"Meal {item.MealNumber}: {item.MealName}\nPrice: {string.Format("{0:c}", item.Price)}\nIngredients: {item.Ingredients}.\nDescription: {item.MealDescription}\n\n");
            }

            Console.WriteLine("Menu listing complete. Press any [enter] to return to the main menu.");
            Console.ReadLine();
            CafeConsoleMenu();
        }

        public void RemoveMealFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter Meal Number of meal you would like to remove:");

            var mealNumber = Console.ReadLine();

            try
            {
                var success = _repo.RemoveMenuItemByMealNumber(Convert.ToInt32(mealNumber));
                Console.WriteLine($"The meal was{(success ? "" : " NOT")} successfully removed. Press [enter] key to return to the main menu");
            }
            catch
            {
                Console.WriteLine("The meal was NOT successfully removed. Press [enter] key to return to the main menu");
            }

            Console.ReadLine();
            CafeConsoleMenu();
        }
    }
}
