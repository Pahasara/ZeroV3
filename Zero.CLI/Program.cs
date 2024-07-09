using System.Data.SQLite;
using Zero.CLI;
using Zero.Core;

public class Program
{
    private static void Main(string[] args)
    {
        const string URL = "github.com/pahasara/ZeroV3";

        try
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = database.db; version = 3; New = True; Compress = True;");
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to database: {ex.Message}");
            Console.WriteLine($"If this keep happening, report this issue on {URL}.");
            Console.ReadKey();
        }
        finally
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowMenu();
            dashboard.ShowDashboard();
        }
    }
}