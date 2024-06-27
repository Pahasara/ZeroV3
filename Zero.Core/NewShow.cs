using System;

namespace Zero.Core
{
    public class NewShow
    {
        private string[] data = new string[5];
        public void ShowMenu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("                ADDING A NEW SHOW");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Do not enter empty data.");
            Console.WriteLine();
            Console.Write("Index: ");
            data[0] = Console.ReadLine();
            Console.Write("Show: ");
            data[1] = Console.ReadLine();
            Console.Write("Current: ");
            data[2]  = Console.ReadLine();
            Console.Write("Total: ");
            data[3] = Console.ReadLine();
            // Console.Write("Rating: ");
            data[4] = "0";
        }
        public string[] GetData()
        {
            return data;
        }
        public void Complete()
        {
            Console.WriteLine("New Show added successfully!");
        }
    }
}
