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
            Console.WriteLine("r        Reset progress");
            Console.WriteLine("del      Delete current TVShow");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
