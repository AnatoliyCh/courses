using System;

namespace Base.SortPart_1;

/// <summary>
/// Ящики.
/// </summary>
public sealed class Boxes
{
    public string Execute(int size, string[] data)
    {
        var boxes = new Box[size];
        for (int i = 0; i < data.Length; i++)
        {
            int[] items = Array.ConvertAll(data[i].Trim().Split(" "), int.Parse);
            boxes[i] = new Box(i, SortBubble(items, DefaultComparer)!);
        }

        return string.Join(" ", SortBubble(boxes, BoxComparer)!.Select(item => item.Number));
    }

    public static T[]? SortBubble<T>(T[]? data, Func<T, T, bool> comparer)
    {
        if (data is null || data.Length == 0)
        {
            return data;
        }

        for (int i = data.Length - 1; i > 0; i--)
        {
            for (int k = 0; k < i; k++)
            {
                if (comparer?.Invoke(data[k + 1], data[k]) == true)
                {
                    (data[k], data[k + 1]) = (data[k + 1], data[k]);
                }
            }
        }

        return data;
    }

    public static bool DefaultComparer(int a, int b)
    {
        return a < b;
    }

    public static bool BoxComparer(Box a, Box b)
    {
        return a.Axes[0] <= b.Axes[0] && a.Axes[1] <= b.Axes[1] && a.Axes[2] <= b.Axes[2];
    }

    public struct Box
    {
        public int Number;
        public int[] Axes;

        public Box(int number, int[] axes)
        {
            Number = number;
            Axes = axes;
        }
    }
}
