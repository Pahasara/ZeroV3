using System;

namespace Zero.Core
{
    public class Dashboard
    {
        private const string app = "Zero V3 BUILD 2427"; // app name
        private const string ver = "24.04"; // release date
        private string choice = "1";

        public void ShowDashboard()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("                " +  app);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Search a show");
            Console.WriteLine("2. Add a new show");
            Console.WriteLine("3. Delete a show");
            Console.WriteLine("4. Update a show");
            Console.WriteLine("5. Navigate through db");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            SelectChoice(choice);
        }

        public void SelectChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the index to search: ");
                    choice = Console.ReadLine();
                    break;
                case "2":
                    //.......................
                    break;
                case "3":
                    Console.Write("Enter the index to delete: ");
                    //.......................
                    choice = Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Enter the index to update: ");
                    //.......................
                    choice = Console.ReadLine();
                    break;
                case "5":
                    Navigation navigation = new Navigation();
                    navigation.ShowMenu();
                    break;
                default:
                    Console.WriteLine("Choice is not valid!");
                    break;
            }
        }
    }
}
