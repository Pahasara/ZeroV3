namespace Zero.Core
{
    public class Arithmetic
    {
        public static double GetProgress(string value, string tot)
        {
            Int32.TryParse(value, out int progress);
            Int32.TryParse(tot, out int total);

            float percentage = (float)progress / total;
            double decPercentage = Math.Round((double)percentage, 2) * 100;

            return decPercentage;
        }

        public static int ParseInt(string str)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(str);
            }
            catch (Exception)
            {
                return 0;
            }
            return num;
        }
    }
}
