using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_ClassLibrary
{
    public class CafeMenuRepo
    {
        public List<CafeMenuItem> _menuItems = new List<CafeMenuItem>();

        public List<CafeMenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        public CafeMenuItem GetMenuItemByMealNumber(int mealNumber)
        {
            return _menuItems.FindLast(m => m.MealNumber == mealNumber);
        }

        public bool AddMenuItem(CafeMenuItem menuItem)
        {
            try
            {
                var existingItem = GetMenuItemByMealNumber(menuItem.MealNumber);
                if (existingItem != null)
                {
                    Console.WriteLine("This meal number already exists.");
                    return false;
                }

                _menuItems.Add(menuItem);
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public bool RemoveMenuItemByMealNumber(int mealNumber)
        {
            try
            {
                var existingItem = GetMenuItemByMealNumber(mealNumber);
                if (existingItem == null)
                {
                    Console.WriteLine("There is no meal by the number.");
                    return false;
                }

                _menuItems.RemoveAll(m => m.MealNumber == mealNumber);
                return true;
            }
            catch
            {
                return false;
            }            
        }

    }
}
