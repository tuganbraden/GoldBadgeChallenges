using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    public class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Seed();

            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:\n" +
                    "1. Make a new badge\n" +
                    "2. Edit a badge\n" +
                    "3. Remove a badge\n" +
                    "4. List all badges\n" +
                    "5. Exit\n");

                bool validInput = false;
                while (validInput == false)
                {
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            NewBadge();
                            validInput = true;
                            break;
                        case "2":
                            UpdateBadge();
                            validInput = true;
                            break;
                        case "3":
                            DeleteBadge();
                            validInput = true;
                            break;
                        case "4":
                            ListAllBadges();
                            validInput = true;
                            break;
                        case "5":
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

        private void NewBadge()
        {
            Console.Clear();

            Console.WriteLine("What is the number on the badge? ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that  it needs access to: ");
            String door = Console.ReadLine();
            bool keepRunning = true;
            List<String> doors = new List<String>();
            while(keepRunning == true)
            {
                doors.Add(door);

                Console.WriteLine("Any other doors?(y/n)");
                string input = Console.ReadLine();

                if(input.ToLower() == "y")
                {
                    Console.WriteLine("List a door:");
                    door = Console.ReadLine();
                }
                else
                {
                    keepRunning = false;
                }
            }

            Badge newBadge = new Badge(num, doors);
            _badgeRepo.AddBadge(newBadge);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ListAllBadges()
        {
            Console.Clear();

            foreach(KeyValuePair<int, List<String>> item in _badgeRepo.GetBadgeDict())
            {
                Console.WriteLine($"ID: {item.Key}\n" +
                $"Doors: ");

                foreach(String door in item.Value)
                {
                    Console.Write($"{door}, ");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateBadge()
        {
            Console.Clear();

            Console.WriteLine("What is the badge number to update?");
            int num = int.Parse(Console.ReadLine());

            Dictionary<int, List<String>> badgeDict = _badgeRepo.GetBadgeDict();
            Badge updatedBadge = new Badge(num, badgeDict[num]);

            bool keepGoing = true;
            while (keepGoing == true)
            {
                Console.WriteLine($"\n{updatedBadge.BadgeID} has access to the below doors");
                foreach (String item in updatedBadge.Doors)
                {
                    Console.Write($"{item}, ");
                }

                Console.WriteLine("\nWhat would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Go back");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Console.WriteLine("Which door do you want to remove");
                        updatedBadge.Doors.Remove(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Enter a door to be added");
                        updatedBadge.Doors.Add(Console.ReadLine());
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                }
            }

            _badgeRepo.UpdateBadge(updatedBadge);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteBadge()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the badge you want to remove: ");
            int input = int.Parse(Console.ReadLine());

            bool check = _badgeRepo.RemoveBadge(input);

            if(check == true)
            {
                Console.WriteLine($"Badge {input} was removed");
            }
            else
            {
                Console.WriteLine($"Badge {input} could not be removed");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void Seed()
        {
            List<String> doors1 = new List<String>();
            doors1.Add("A1");
            doors1.Add("A2");
            doors1.Add("A3");
            Badge new1 = new Badge(12345, doors1);
            _badgeRepo.AddBadge(new1);

            List<String> doors2 = new List<String>();
            doors2.Add("B1");
            doors2.Add("B2");
            doors2.Add("B3");
            Badge new2 = new Badge(51234, doors2);
            _badgeRepo.AddBadge(new2);

            List<String> doors3 = new List<String>();
            doors3.Add("C1");
            doors3.Add("C2");
            doors3.Add("C3");
            Badge new3 = new Badge(45123, doors3);
            _badgeRepo.AddBadge(new3);
        }
    }
}
