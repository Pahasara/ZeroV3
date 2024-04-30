// See https://aka.ms/new-console-template for more information
using System.Data.SQLite;
using Zero.CLI;

public class Program
{
    private static void Main(string[] args)
    {
        Dashboard dashboard = new Dashboard();
        SQLiteConnection conn = new SQLiteConnection("Data Source = database.db; version = 3; New = True; Compress = True;");
        
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to database: {ex.Message}");
        }

        while (true) 
        {
            dashboard.ShowDashboard();
        }
    }
}