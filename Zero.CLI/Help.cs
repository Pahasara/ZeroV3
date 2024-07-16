namespace Zero.CLI
{
    public class Help
    {
        public static void Dashboard()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("           Zero TVSM - User Guide");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("[none]  Refresh console");
            Console.WriteLine("* a     Add a new TVShow");
            Console.WriteLine("* s     Search TVShow");
            Console.WriteLine("* k     Go to Next TVShow");
            Console.WriteLine("* j     Go to Previous TVShow");
            Console.WriteLine("* ]     Increase progress by 1");
            Console.WriteLine("* [     Decrease progress by 1");
            Console.WriteLine("* }     Finish progress");
            Console.WriteLine("* {     Reset current progress");
            Console.WriteLine("* r     Delete current TVShow");
            Console.WriteLine("* q     Exit from the program");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
