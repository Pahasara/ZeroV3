namespace Zero.Core
{
    public class Arithmetic
    {
        public float GetProgress(string value, string tot)
        {
            Int32.TryParse(value, out int progress);
            Int32.TryParse(tot, out int total);

            float percentage = (float)progress / total;

            return percentage;
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
