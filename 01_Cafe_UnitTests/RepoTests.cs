using _01_Cafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_Cafe_UnitTests
{
    [TestClass]
    public class RepoTests
    {
        CafeMenuRepo repo = new CafeMenuRepo();

        [TestMethod]
        public void TestThatWhenMenuItemAdded_ThenItemAddedSuccessfully()
        {            
            var menuItem = new CafeMenuItem();
            menuItem.MealNumber = 123;
            menuItem.MealName = "Test Meal";
            menuItem.Ingredients = "Doesn't Matter";
            menuItem.MealDescription = "Doesn't Matter";
            repo.AddMenuItem(menuItem);
            var meal = repo.GetMenuItemByMealNumber(123);

            Assert.IsNotNull(meal);
        }
        [TestMethod]
        public void TestThatWhenMenuItemRemoved_ThenItemCannotBeFound()
        {
            TestThatWhenMenuItemAdded_ThenItemAddedSuccessfully();
            repo.RemoveMenuItemByMealNumber(123);
            var meal = repo.GetMenuItemByMealNumber(123);

            Assert.IsNull(meal);
        }
        [TestMethod]
        public void TestThatWhenTwoMenuItemsAdded_ThenItemCountIsTwo()
        {
            CafeMenuItem menuItem;

            menuItem = new CafeMenuItem();
            menuItem.MealNumber = 123;
            menuItem.MealName = "Test Meal";
            menuItem.Ingredients = "Doesn't Matter";
            menuItem.MealDescription = "Doesn't Matter";
            repo.AddMenuItem(menuItem);

            menuItem = new CafeMenuItem();
            menuItem.MealNumber = 321;
            menuItem.MealName = "Test Meal";
            menuItem.Ingredients = "Doesn't Matter";
            menuItem.MealDescription = "Doesn't Matter";
            repo.AddMenuItem(menuItem);

            Assert.IsTrue(repo.GetAllMenuItems().Count == 2);
        }
    }
}
