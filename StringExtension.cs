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

    public static bool IsInteger(this string str) {
        if (str.Length <= 0)
            return false;
        bool r = true;
        int i = 0;
        if (str[i] != '-' && str[i] < '0' || str[i] > '9') {
            r = false;
        }
        if (r) {
            for (++i; i < length; ++i) {
                if (str[i] < '0' || str[i] > '9') {
                    r = false;
                    break;
                }
            }
        }
        return r;
    }

    public static bool IsFloat(this string str) {
        if (str.Length <= 0)
            return false;
        bool r = true;
        bool hasPoint = false;
        int i = 0;
        if (str[i] != '-' && str[i] < '0' || str[i] > '9') {
            r = false;
        } else if (str[i] == '.') {
            hasPoint = true;
        }
        if (r) {
            for (++i; i < length; ++i) {
                if (str[i] < '0' || str[i] > '9') {
                    r = false;
                    break;
                } else if (str[i] == '.') {
                    if (hasPoint) {
                        r = false;
                        break;
                    } else {
                        hasPoint = true;
                    }
                }
            }
        }
        return r;
    }
}
