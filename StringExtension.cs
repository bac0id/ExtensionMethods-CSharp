using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// String extensions
/// </summary>
public static class StringExtension
{
    public static int WordCount(this string str) {
        return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int ToInt(this string str) {
        return int.Parse(str);
    }
   
    /// <summary>
	/// Read all integer numbers in a given <see cref="string"/>.
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
    public static int[] ReadInts(this string str) {
        return str.ReadInts(0, str.Length);
    }

    /// <summary>
	/// Read all integer numbers in a given <see cref="string"/>.
	/// </summary>
	/// <param name="str"></param>
	/// <param name="inclusiveLeft"></param>
	/// <param name="exclusiveRight"></param>
	/// <returns></returns>
    public static int[] ReadInts(this string str, int inclusiveLeft, int exclusiveRight) {
        IList<int> list = new List<int>();
        int p = inclusiveLeft;
        int a = 0;
        while (p < exclusiveRight) {
            if (str[p] == '-') {
                int q = p + 1;
                while (q < exclusiveRight && str[q] >= '0' && str[q] <= '9') {
                    a = a * 10 + str[q++] - '0';
                }
                list.Add(-a);
                a = 0;
                p = q;
            } else if (str[p] >= '0' && str[p] <= '9') {
                int q = p;
                a = str[q++] - '0';
                while (q < exclusiveRight && str[q] >= '0' && str[q] <= '9') {
                    a = a * 10 + str[q++] - '0';
                }
                list.Add(a);
                a = 0;
                p = q;
            } else {
                ++p;
            }
        }
        return list.ToArray();
    }
}
