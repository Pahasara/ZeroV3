using Zero.Core;

namespace Zero.CLI
{
    public class NavigationCLI
    {
        Navigation navi = new Navigation();
        private string choice = "";

        public void ShowMenu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("                Navigation Manager");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type 'next' / 'n' for next show.");
            Console.WriteLine("Type 'back' / 'b' for previous show.");
            Console.WriteLine("Enter to exit from navigation manager.");
            Navigate();
        }

        private void Navigate()
        {
            do
            {
                bool isNext = false;
                Console.WriteLine();
                Console.Write("Navigate: ");
                choice = Console.ReadLine();
                if (choice == "n")
                {
                    isNext = true;
                }
                navi.Navigate(isNext);
                ShowData();
            }
            while (choice != "");
            navi.currentRow = 0;
        }

        private void ShowData()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Index   : {navi.GetIndex()}");
            Console.WriteLine($"Show    : {navi.GetShow()}");
            Console.WriteLine($"Progress: {navi.GetCurrent()}");
            Console.WriteLine($"Total   : {navi.GetTotal()}");
            Console.WriteLine($"Rating  : {navi.GetRating()}");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
