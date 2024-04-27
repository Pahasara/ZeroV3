// See https://aka.ms/new-console-template for more information
using System.Data.SQLite;
using Zero.Core;

public class Program
{
    private static void Main(string[] args)
    {
        Database database = new Database();
        Dashboard dashboard = new Dashboard();
        Navigation navigation = new Navigation();

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