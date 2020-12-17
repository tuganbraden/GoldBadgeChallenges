using MenuItem_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MenuItem_Console
{
    public class ProgramUI
    {
        private MenuItemRepo _menuRepo = new MenuItemRepo();
        public void run()
        {
            Seed();
            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. Remove Meal from Menu\n" +
                    "4. Exit\n\n");

                bool validInput = false;
                while (validInput == false)
                {
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddItem();
                            validInput = true;
                            break;
                        case "2":
                            ViewMenu();
                            validInput = true;
                            break;
                        case "3":
                            DeleteItem();
                            validInput = true;
                            break;
                        case "4":
                            keepRunning = false;
                            validInput = true;
                            break;
                        default:
                            Console.WriteLine("Enter a valid number: ");
                            break;
                    }
                }
            }

        }

        // CREATE
        private void AddItem()
        {
            Console.Clear();

            Console.WriteLine("Enter the name of the new item: ");
            String name = Console.ReadLine();

            Console.WriteLine("Enter a brief description of the new item");
            String description = Console.ReadLine();

            bool keepGoing = true;
            List<String> ingredients = new List<String>();
            Console.WriteLine("Enter an ingredient: ");
            while (keepGoing == true)
            {
                string input = Console.ReadLine();
                if(input.ToLower() == "next")
                {
                    keepGoing = false;
                }
                else
                {
                    ingredients.Add(input);
                    Console.WriteLine("Enter a new ingredient, or enter the word \"NEXT\" to continue: ");
                }
            }

            Console.WriteLine("Enter the meal number for the new item: ");
            int mealNumber = int.Parse(Console.ReadLine());
            keepGoing = true;
            while (keepGoing == true)
            {
                if (_menuRepo.GetItemByNumber(mealNumber) != null)
                {
                    Console.WriteLine("This number is already taken, please enter a new one");
                    mealNumber = int.Parse(Console.ReadLine());
                }
                else
                {
                    keepGoing = false;
                }
            }

            Console.WriteLine("Enter a price for the new item (ex. \"2.40\"): ");
            decimal price = decimal.Parse(Console.ReadLine());

            MenuItem newItem = new MenuItem(mealNumber, name, description, ingredients, price);

            _menuRepo.CreateNewItem(newItem);
        }

        // READ
        public void ViewMenu()
        {
            Console.Clear();

            List<MenuItem> listOfItems = _menuRepo.GetMenu();
            foreach(MenuItem item in listOfItems)
            {
                Console.WriteLine($"{item.MealNumber}\n" +
                $"{item.Name}\n" +
                $"{item.Description}");
                foreach(string ingredient in item.Ingredients)
                {
                    Console.Write(ingredient + ", ");
                }
                Console.WriteLine($"\n{item.Price}\n\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // DELETE
        public void DeleteItem()
        {
            Console.Clear();

            Console.WriteLine("Enter the number of the item you want to delete: ");
            int input = int.Parse(Console.ReadLine());

            bool deleted = _menuRepo.RemoveItem(input);
            if(deleted == false)
            {
                Console.WriteLine("Menu item could not be deleted");
            }
            else
            {
                Console.WriteLine("Menu item deleted");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void Seed()
        {
            List<String> ingredients1 = new List<string>();
            ingredients1.Add("Bread");
            ingredients1.Add("Bacon");
            ingredients1.Add("Lettuce");
            ingredients1.Add("Tomato");
            var item1 = new MenuItem(1, "BLT", "Classic BLT Sandwich", ingredients1, 3.45m);
            _menuRepo.CreateNewItem(item1);

            List<String> ingredients2 = new List<string>();
            ingredients2.Add("Bread");
            ingredients2.Add("Butter");
            ingredients2.Add("Cheese");
            var item2 = new MenuItem(2, "Grilled Cheese", "Can't go wrong with a grilled cheese!", ingredients2, 2.75m);
            _menuRepo.CreateNewItem(item2);

            List<String> ingredients3 = new List<string>();
            ingredients3.Add("Buns");
            ingredients3.Add("Chicken");
            ingredients3.Add("Lettuce");
            ingredients3.Add("Tomato");
            var item3 = new MenuItem(3, "Grilled Chicken Sandwich", "Made with chicken straight off the grill", ingredients3, 4.25m);
            _menuRepo.CreateNewItem(item3);
        }
    }
}
