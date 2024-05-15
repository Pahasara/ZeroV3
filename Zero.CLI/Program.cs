using System.Data.SQLite;
using Zero.CLI;

public class Program
{
    private static void Main(string[] args)
    {
        const string URL = "github.com/pahasara/ZeroV3";
        Dashboard dashboard = new Dashboard();
        SQLiteConnection conn = new SQLiteConnection("Data Source = database.db; version = 3; New = True; Compress = True;");
        
        try
        {
            conn.Open();
            while (true)
            {
                dashboard.ShowMenu();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to database: {ex.Message}");
            Console.WriteLine($"Report this issue on {URL}.");
            Console.ReadKey();
        }
    }
}