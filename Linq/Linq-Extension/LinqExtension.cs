﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.Linq_Extension
{
    public static class LINQExtension
    {
        public static double Median(this IEnumerable<double> source)
        {
            if (source.Count() == 0)
            {
                throw new InvalidOperationException("Cannot compute median for an empty set.");
            }

            var sortedList = from number in source
                             orderby number
                             select number;

            int itemIndex = (int)sortedList.Count() / 2;

            if (sortedList.Count() % 2 == 0)
            {
                // Even number of items.  
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
            }
            else
            {
                // Odd number of items.  
                return sortedList.ElementAt(itemIndex);
            }
        }

        //Int Overload
        public static double Median(this IEnumerable<int> source)
        {
            return (from num in source select (double)num).Median();
        }

        // Generic overload.  
        public static double Median<T>(this IEnumerable<T> numbers,
                               Func<T, double> selector)
        {
            return (from num in numbers select selector(num)).Median();
        }
    }
}

