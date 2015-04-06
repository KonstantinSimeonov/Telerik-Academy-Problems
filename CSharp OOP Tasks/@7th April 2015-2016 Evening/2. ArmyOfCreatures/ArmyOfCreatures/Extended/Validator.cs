namespace ArmyOfCreatures.Extended
{
    using System;

    public static class Validator
    {
        public static void ValidateRange(int value, int min, int max, string crashMessage = null)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(crashMessage);
            }
        }
    }
}
