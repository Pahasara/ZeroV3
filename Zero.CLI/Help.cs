namespace Zero.Core
{
    public class Help
    {
        public static void Dashboard()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("                  Help: Dashboard");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("n        Go to Next TVShow");
            Console.WriteLine("b        Go to Previous TVShow");
            Console.WriteLine("++       Forward progress");
            Console.WriteLine("--       Backward progress");
            Console.WriteLine("+++      Finish progress");
            Console.WriteLine("add      Add a new TVShow");
            Console.WriteLine("del      Delete current TVShow");
            Console.WriteLine("reset    Reset current progress");
            Console.WriteLine("clear    Clear the console");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
