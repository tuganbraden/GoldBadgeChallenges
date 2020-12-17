using System;
using System.Collections.Generic;
using MenuItem_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_MenuItem_Tests
{
    [TestClass]
    public class MenuRepoTests
    {
               
        [TestMethod]
        public void CreateItem_ShouldGetNotNull()
        {
            MenuItem item = new MenuItem();
            item.MealNumber = 2;
            MenuItemRepo repo = new MenuItemRepo();

            repo.CreateNewItem(item);
            MenuItem itemFromRepo = repo.GetItemByNumber(2);

            Assert.IsNotNull(itemFromRepo);
        }

        [TestMethod]
        public void ReadItem_ShouldGetNotNull()
        {
            MenuItemRepo repo = new MenuItemRepo();
            List<MenuItem> list = new List<MenuItem>();

            list = repo.GetMenu();

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void DeleteItem_ShouldGetTrue()
        {
            MenuItem item = new MenuItem();
            item.MealNumber = 5;
            MenuItemRepo repo = new MenuItemRepo();

            repo.CreateNewItem(item);
            bool deleteResult = repo.RemoveItem(5);

            Assert.IsTrue(deleteResult);
        }
    }
}
