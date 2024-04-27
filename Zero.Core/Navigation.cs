using System;
using System.Data.SQLite;

namespace Zero.Core
{
    public class Navigation
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source = database.db; version = 3; New = True; Compress = True;");
        Database database = new Database();
        
        private static int currentRow = 0, maxRow = 0;
        private static string index;

        private string choice = "n", show, current, total, rating;

        public Navigation()
        {
            try
            {
                conn.Open();
                
            }
            catch (Exception ex)
            {

            }
        }

        private void Navigate()
        {
            if (choice == "n")
            {
                NextShow();
            }
            else
            {
                PreviousShow();
            }

            Refresh(); // Fetch new data columns
            ShowData();
        }

        private void ShowData()
        {   
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"          {index}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"SHOW: {show}");
            Console.WriteLine($"Progress: {current}");
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Rating: {rating}");
            Console.WriteLine("----------------------------------------------------");
        }

        private void Refresh()
        {
            maxRow = database.GetNumberOfRows(conn);
            string[] indexes = database.GetIndexArray(conn);
            string[] data = database.Search(conn, indexes[currentRow]);

            index = data[0];
            show = data[1];
            current = data[2];
            total = data[3];
            rating = data[4];
        }

        public void ShowMenu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("                Navigation Manager");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Type 'next' / 'n' for next show.");
            Console.WriteLine("Type 'back' / 'b' for previous show.");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            Navigate();
        }

        public void NextShow()
        {
            if (currentRow < maxRow)
            {
                currentRow++;
            }
        }

        public void PreviousShow()
        {
            if (currentRow > 1)
            {
                currentRow--;
            }
        }
    }
}
