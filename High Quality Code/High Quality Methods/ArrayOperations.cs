namespace Methods
{
    using System;

    public class ArrayOperations
    {
        private const string EMPTY_COLLECTION_MESSAGE = "The provided collection was null or empty!";

        public static T FindMaxInArray<T>(params T[] elements)
            where T : IComparable<T>
        {
            if (Validator.IsNullOrEmptyArray(elements))
            {
                throw new ArgumentNullException(EMPTY_COLLECTION_MESSAGE);
            }

            var maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i].CompareTo(maxElement) > 0)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
    }
}
