using System.Data.SQLite;

namespace Zero.CLI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            const string URL = "github.com/pahasara/ZeroV3";

            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=.zero.db; Version=3; New=True; Compress=True;");
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
                Console.WriteLine($"If this keeps happening, report this issue on {URL}.");
                Console.ReadKey();
                return;
            }

            Dashboard dashboard = new Dashboard();
            dashboard.TryNavigate(); // Check if there are issues with the database
            dashboard.ShowDashboard(); // Start the dashboard for user interaction

        }
    }

}
