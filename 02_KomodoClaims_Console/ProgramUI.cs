using _02_KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_KomodoClaims_Repository.Claim;

namespace _02_KomodoClaims_Console
{
    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
        public void run()
        {
            Seed();

            bool keepRunning = true;
            while (keepRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");

                bool validInput = false;
                while (validInput == false)
                {
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            SeeClaims();
                            validInput = true;
                            break;
                        case "2":
                            HandleNextClaim();
                            validInput = true;
                            break;
                        case "3":
                            NewClaim();
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

        private void SeeClaims()
        {
            Console.Clear();
            foreach(Claim item in _claimRepo.GetQueue())
            {
                Console.WriteLine($"ID: {item.ClaimID}\n" +
                $"Type: {item.TypeofClaim}\n" +
                $"Description: {item.Description}\n" +
                $"Amount: {item.ClaimAmount}\n" +
                $"Date of Incident: {item.DateOfIncident}\n" +
                $"Date of Claim: {item.DateOfClaim}");
                if(item.IsValid == true)
                {
                    Console.WriteLine("This claim is valid.\n");
                }
                else
                {
                    Console.WriteLine("This claim is not valid.\n");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void HandleNextClaim()
        {
            Console.Clear();

            Claim item = _claimRepo.GetQueue().Peek();

            Console.WriteLine($"ID: {item.ClaimID}\n" +
                $"Type: {item.TypeofClaim}\n" +
                $"Description: {item.Description}\n" +
                $"Amount: {item.ClaimAmount}\n" +
                $"Date of Incident: {item.DateOfIncident}\n" +
                $"Date of Claim: {item.DateOfClaim}");
            if (item.IsValid == true)
            {
                Console.WriteLine("This claim is valid.\n");
            }
            else
            {
                Console.WriteLine("This claim is not valid.\n");
            }

            Console.WriteLine("Do you want to take care of this claim?(y/n)");
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                _claimRepo.HandleClaim();
                Console.WriteLine("\nClaim handled");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void NewClaim()
        {
            Console.Clear();

            Console.WriteLine("Enter the claim ID: ");
            String id = Console.ReadLine();

            Console.WriteLine("\nEnter the claim type (Car, Home, or Theft): ");
            String typeAsString = Console.ReadLine();
            ClaimType type = ClaimType.Car;
            bool isValid = false;
            while (isValid == false)
            {
                if (typeAsString.ToLower() == "car")
                {
                    type = ClaimType.Car;
                    isValid = true;
                }
                else if (typeAsString.ToLower() == "home")
                {
                    type = ClaimType.Home;
                    isValid = true;
                }
                else if (typeAsString.ToLower() == "theft")
                {
                    type = ClaimType.Theft;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option (Car, Home, Theft): ");
                    typeAsString = Console.ReadLine();
                }
            }

            Console.WriteLine("\nEnter a claim description: ");
            String description = Console.ReadLine();

            Console.WriteLine("\nAmount of Damage: ");
            decimal damage = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nDate of incident: ");
            DateTime incident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nDate of claim: ");
            DateTime claim = DateTime.Parse(Console.ReadLine());

            Claim newClaim = new Claim(id, type, description, damage, incident, claim);
            if(newClaim.IsValid == true)
            {
                Console.WriteLine("\nThis claim is valid.");
            }
            else
            {
                Console.WriteLine("\nThis claim is not valid.");
            }

            _claimRepo.AddClaim(newClaim);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private void Seed()
        {
            //public Claim(String id, ClaimType type, String desc, decimal amount, DateTime incident, DateTime claim)
            DateTime incident1 = new DateTime(2020, 3, 15);
            DateTime claim1 = new DateTime(2020, 3, 17);
            Claim new1 = new Claim("1", ClaimType.Car, "Crash on 37", 250.00m, incident1, claim1);
            _claimRepo.AddClaim(new1);

            DateTime incident2 = new DateTime(2020, 3, 20);
            DateTime claim2 = new DateTime(2020, 5, 17);
            Claim new2 = new Claim("2", ClaimType.Home, "Tree fell onto shed", 2350.00m, incident2, claim2);
            _claimRepo.AddClaim(new2);

            DateTime incident3 = new DateTime(2020, 3, 20);
            DateTime claim3 = new DateTime(2020, 4, 19);
            Claim new3 = new Claim("3", ClaimType.Car, "Crash on 37", 250.00m, incident3, claim3);
            _claimRepo.AddClaim(new3);
        }
    }
}
