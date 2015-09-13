using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static T Sum<T>(this IEnumerable<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        return sum;
    }

    public static T Product<T>(this IEnumerable<T> list)
    {
        dynamic product = 1;
        foreach (var item in list)
        {
            product *= item;
        }
        return product;
    }

    public static T Min<T>(this IEnumerable<T> list)
    {
        dynamic min = int.MaxValue;
        foreach (var item in list)
        {
            if (item < min)
            {
                min = item; 
            }
        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> list)
    {
        dynamic max = int.MinValue;
        foreach (var item in list)
        {
            if (item < max)
            {
                max = item;
            }
        }
        return max;
    }

    public static T Average<T>(this IEnumerable<T> list)
    {
        dynamic sum = 0;
        int counter = 0;
        
        foreach (var item in list)
        {
            sum += item;
            counter++;
        }

        return sum / counter;
    }
}