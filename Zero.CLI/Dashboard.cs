using Zero.Core;

namespace Zero.CLI
{
    public class Dashboard
    {
        Navigation navi = new Navigation();
        private string choice = "";

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"                Zero TVSM v{Info.Version}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Type help for for more information.");
            Console.WriteLine("Press enter to exit from Zero TVSM.\n");
        }

        public void ShowDashboard()
        {
            do
            {
                Console.WriteLine();
                Console.Write("Command: ");
                choice = Console.ReadLine();

                if (choice == "add")
                {
                    navi.AddShow();
                }
                else if (choice == "reset")
                {
                    navi.ResetProgress();
                }
                else if (choice == "del")
                {
                    navi.DeleteShow();
                }
                else if (choice == "help")
                {
                    Help.Dashboard();
                }
                else
                {
                    TryNavigate();
                }
            }
            while (choice != "");
        }

        private void TryNavigate()
        {
            int maxRow = navi.GetMaxRow();
            if (maxRow > 0)
            {
                Navigate();
            }
            else
            {
                Console.WriteLine("No TVShow has been saved. Pleas use 'add' command to add new entries.");
            }
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
            ShowMenu();
            ShowData();
            ShowRowNumber();
        }

        private void ChangeProgress()
        {
            if (choice == "++")
            {
                navi.Forward();
                navi.Navigate();
            }
            else if (choice == "--")
            {
                navi.Backward();
                navi.Navigate();
            }
            else if (choice == "r")
            {
                navi.ResetProgress();
                navi.Navigate();
            }
            else if (choice == "+++")
            {
                navi.FinishProgress();
                navi.Navigate();
            }
            else
            {
                navi.Search(choice);
            }
        }

        private void ShowData()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Index   : {navi.GetIndex()}");
            Console.WriteLine($"Show    : {navi.GetShow()}");
            Console.WriteLine($"Rating  : {navi.GetRating()}");
            Console.WriteLine($"Current : {navi.GetCurrent()}");
            Console.WriteLine($"Total   : {navi.GetTotal()}");
            Console.WriteLine($"Progress: {navi.GetCurrent()}/{navi.GetTotal()}");
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
