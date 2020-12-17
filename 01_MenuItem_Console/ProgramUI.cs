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
            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:\n" +
                    "1. Create New Meal\n" +
                    "2. View All Meals\n" +
                    "3. View Meal By Number\n" +
                    "5. Remove Meal from Menu\n" +
                    "6. Exit\n\n");

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
                            
                            validInput = true;
                            break;
                        case "3":

                            validInput = true;
                            break;
                        case "4":
                            
                            validInput = true;
                            break;
                        case "5":

                            validInput = true;
                            break;
                        case "6":

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


            Console.WriteLine("");
        }

        // READ
        public void ViewMenu()
        {
            
        }

        public void ViewMealByNumber()
        {
            
        }

        // DELETE


    }
}
