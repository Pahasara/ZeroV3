using Zero.Core;

namespace Zero.CLI
{
    public class Dashboard
    {
        Navigation navi = new Navigation();
        private string choice = "";

        public void ShowMenu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"                Zero TVSM v{Info.Version}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Type help for for more information.");
            Console.WriteLine("Enter to exit from navigation manager.");
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            do
            {
                Console.WriteLine();
                Console.Write("Command: ");
                choice = Console.ReadLine();

                if (choice == "help")
                {
                    Help.Dashboard();
                }
                else
                {
                    Navigate();
                }
            }
            while (choice != "");
            navi.currentRow = 0;
        }

        private void Navigate()
        {
            if (choice == "n")
            {
                navi.Navigate("next");
            }
            else if (choice == "b")
            {
                navi.Navigate("back");
            }
            else if (choice == "del")
            {
                navi.DeleteShow();
            }
            else
            {
                ChangeProgress();
            }
            ShowData();
            ShowRowNumber();
        }

        private void ChangeProgress()
        {
            if (choice == "++")
            {
                navi.Forward();
            }
            else if (choice == "--")
            {
                navi.Backward();
            }
            else if (choice == "r")
            {
                navi.ResetProgress();
            }
            else if (choice == "+++")
            {
                navi.FinishProgress();
            }
            navi.Navigate();
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

        private void ShowRowNumber()
        {
            int currentRow = navi.currentRow + 1;
            int maxRows = navi.maxRow;
            Console.WriteLine($"                       {currentRow}/ {maxRows}");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
