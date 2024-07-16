using Zero.Core;

namespace Zero.CLI
{
    public class Dashboard
    {
        Navigation navi = new Navigation();
        private char command = 'b';
        private bool isEmptyData = false;

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" [h] help      Zero TVSM v3.0     [q] quit");
            Console.WriteLine("--------------------------------------------");
        }

        public void ShowDashboard()
        {
            while (true)
            {
                if (isEmptyData)
                {
                    navi.AddShow();
                    isEmptyData = false;
                }
                else
                {
                    command = Console.ReadKey().KeyChar;
                    if (command == 'q')
                    {
                        Console.CursorVisible = true;
                        break;
                    }
                }
                TryNavigate();
            }
            Console.Clear();
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
                isEmptyData = true;
                ShowMenu();
                Console.WriteLine("No TVShow has been saved.");
                Console.WriteLine("Press any key to add new entries.");
                Console.ReadKey();
            }
        }

        private void Navigate()
        {
            switch (command)
            {
                case 'a':
                    navi.AddShow();
                    break;
                case 'r':
                    navi.DeleteShow();
                    break;
                case 'h':
                    Help.Dashboard();
                    break;
                case 'k':
                    navi.Navigate("next");
                    break;
                case 'j':
                    navi.Navigate("back");
                    break;
                case ']':
                    navi.Forward();
                    navi.Navigate();
                    break;
                case '[':
                    navi.Backward();
                    navi.Navigate();
                    break;
                case '{':
                    navi.ResetProgress();
                    navi.Navigate();
                    break;
                case '}':
                    navi.FinishProgress();
                    navi.Navigate();
                    break;
                case 's':
                    Search();
                    break;
            }
            if (command != 'h')
            {
                ShowMenu();
                ShowData();
                ShowRowNumber();
            }
        }

        private void ShowData()
        {
            Console.WriteLine($"* Index   : {navi.GetIndex()}");
            Console.WriteLine($"* Show    : {navi.GetShow()}");
            Console.WriteLine($"* Current : {navi.GetCurrent()}");
            Console.WriteLine($"* Total   : {navi.GetTotal()}");
            Console.WriteLine($"* Progress: {navi.GetCurrent()}/ {navi.GetTotal()} ({navi.GetProgress()}%)");
        }

        private void ShowRowNumber()
        {
            int currentRow = navi.currentRow + 1; // To show virtual indexes: from 1 to ..
            if (currentRow == 0)
                currentRow = 1;
            int maxRows = navi.maxRow;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($" [j] back           {currentRow}/ {maxRows}          [k] next");
            Console.WriteLine("--------------------------------------------");
        }

        private void Search()
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("         Zero TVSM - Search");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
            Console.Write("Index: ");
            string searchFor = Console.ReadLine();
            navi.Search(searchFor);
            Console.CursorVisible = false;
        }
    }
}
