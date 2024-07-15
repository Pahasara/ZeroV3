using Zero.Core;

namespace Zero.CLI
{
    public class Dashboard
    {
        Navigation navi = new Navigation();
        private string choice = "b";

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"            Zero TVSM v{Info.Version}");
            Console.WriteLine("--------------------------------------------");
        }

        public void ShowDashboard()
        {
            while (choice != "exit")
            {
                Console.WriteLine();
                Console.Write("Command: ");
                choice = Console.ReadLine();
                CheckChoice(choice);
            }
        }

        public void CheckChoice(string choice)
        {
            if (string.IsNullOrWhiteSpace(choice))
            {
                choice = "exit";
            }
            switch (choice.ToLower())
            {
                case "add":
                    navi.AddShow();
                    break;
                case "reset":
                    navi.ResetProgress();
                    break;
                case "del":
                    navi.DeleteShow();
                    break;
                case "help":
                    Help.Dashboard();
                    break;
                default:
                    TryNavigate();
                    break;
            }
        }

        public void TryNavigate()
        {
            int maxRow = navi.GetMaxRow();
            if (maxRow > 0)
            {
                Navigate();
            }
            else
            {
                Console.WriteLine("No TVShow has been saved. Please use 'add' command to add new entries.");
            }
        }

        private void Navigate()
        {
            switch (choice.ToLower())
            {
                case "n":
                    navi.Navigate("next");
                    break;
                case "b":
                    navi.Navigate("back");
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "++":
                    navi.Forward();
                    navi.Navigate();
                    break;
                case "--":
                    navi.Backward();
                    navi.Navigate();
                    break;
                case "r":
                    navi.ResetProgress();
                    navi.Navigate();
                    break;
                case "+++":
                    navi.FinishProgress();
                    navi.Navigate();
                    break;
                default:
                    navi.Search(choice);
                    break;
            }
            ShowMenu();
            ShowData();
            ShowRowNumber();
        }

        private void ShowData()
        {
            Console.WriteLine($"Index   : {navi.GetIndex()}");
            Console.WriteLine($"Show    : {navi.GetShow()}");
            Console.WriteLine($"Current : {navi.GetCurrent()}");
            Console.WriteLine($"Total   : {navi.GetTotal()}");
            Console.WriteLine($"Progress: {navi.GetCurrent()}/ {navi.GetTotal()} ({navi.GetProgress()}%)");
        }

        private void ShowRowNumber()
        {
            int currentRow = navi.currentRow + 1; // To show virtual indexes: from 1 to ..
            if (currentRow == 0)
                currentRow = 1;
            int maxRows = navi.maxRow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"                   {currentRow}/ {maxRows}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
