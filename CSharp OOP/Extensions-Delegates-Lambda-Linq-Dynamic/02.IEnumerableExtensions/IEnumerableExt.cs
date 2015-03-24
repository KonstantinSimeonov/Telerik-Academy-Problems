namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        /// <summary>
        /// Returns the minimal elements of a sequenece of comparable elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T MinElement<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            bool notEmpty = false;
            dynamic min = null;

            foreach (var item in collection)
            {
                notEmpty = true;
                min = item;
                break;
            }

            if (notEmpty)
            {
                foreach (var item in collection)
                {
                    if (min.CompareTo(item) > 0)
                    {
                        min = item;
                    }
                }

                return min;
            }
            else
            {
                throw new ArgumentException("Empty collection!");
            }


        }

        /// <summary>
        /// Returns the maximal element of a sequence of comparable elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T MaxElement<T>(this IEnumerable<T> collection)
            where T : IComparable
        {
            bool notEmpty = false;
            dynamic max = null;

            foreach (var item in collection)
            {
                notEmpty = true;
                max = item;
                break;
            }

            if (notEmpty)
            {
                foreach (var item in collection)
                {
                    if (max.CompareTo(item) < 0)
                    {
                        max = item;
                    }
                }

                return max;
            }
            else
            {
                throw new ArgumentException("Empty collection!");
            }

        }

        /// <summary>
        /// Returns the sum of a sequence of elements projected in a certain way by the caller.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="projectToNumber"></param>
        /// <returns></returns>
        public static T SumElements<T>(this IEnumerable<T> collection, Func<T, dynamic> projectToNumber) // the user decides how to project the sequence
        {
            dynamic sum = default(T);

            foreach (var item in collection)
            {
                sum += projectToNumber(item);
            }

            return (T)sum;
        }

        /// <summary>
        /// Returns the average of a sequence of elements projected as numbers in a certain ways by the user.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="projectToNumber"></param>
        /// <returns></returns>
        public static double AverageOf<T>(this IEnumerable<T> collection, Func<T, dynamic> projectToNumber) // the user decides how to project the sequence
        {
            double sum = 0;

            int elementsCount = 0;

            foreach (var item in collection)
            {
                sum += projectToNumber(item);
                elementsCount++;
            }

            return sum / elementsCount;
        }
    }

}