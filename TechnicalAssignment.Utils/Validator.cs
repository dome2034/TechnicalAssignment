namespace TechnicalAssignment.Utils
{
    public class Validator
    {

        public static bool IsInRange(long input, int range)
        {
            return IsInRange(input.ToString(), range);
        }

        public static bool IsInRange(string input, int range)
        {
            return input.Length <= range;
        }
    }
}
