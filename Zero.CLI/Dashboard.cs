namespace Zero.CLI
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
            Console.WriteLine("1. Navigate through db");
            Console.WriteLine("2. Add a new show");
            Console.WriteLine("3. Search a show");
            Console.WriteLine("4. Update a show");
            Console.WriteLine("5. Delete a show");
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
                    NavigationCLI navigation = new NavigationCLI();
                    navigation.ShowMenu();
                    break;
                    
                case "2":
                    //.......................
                    break;
                case "3":
                    Console.Write("Enter the index to search: ");
                    choice = Console.ReadLine();
                    break; 
                case "4":
                    Console.Write("Enter the index to update: ");
                    //.......................
                    choice = Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Enter the index to delete: ");
                    //.......................
                    choice = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Choice is not valid!");
                    break;
            }
        }
    }
}
