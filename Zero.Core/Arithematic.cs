namespace Zero.Core
{
    public class Arithematic
    {
        public float GetProgress(string value, string tot)
        {
            Int32.TryParse(value, out int progress);
            Int32.TryParse(tot, out int total);

            float percentage = (float)progress / total;

            return percentage;
        }

        public string ParseInt(string str)
        {
            try
            {
                Int32.Parse(str);
            }
            catch (Exception)
            {
                return "0";
            }
            return str;
        }
    }
}
