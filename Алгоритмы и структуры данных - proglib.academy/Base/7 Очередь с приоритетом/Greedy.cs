using System;

namespace Base.PriorityQueue;

/// <summary>
/// Жадина.
/// </summary>
public sealed class Greedy
{
    public int Execute(int[] fruits, int maxWeight)
    {
        var queue = new PriorityQueue();
        var outFruits = new Stack<int>();
        int iterations = 0;
        foreach (var item in fruits)
        {
            queue.Push(item);
        }

        while (queue.Count != 0)
        {
            iterations++;
            // берем самые большие фрукты, сколько можем
            while (queue.Count != 0 && (outFruits.Sum() + queue.Top()) <= maxWeight)
            {
                outFruits.Push((int)queue.Pop()!);
            }

            // разделение и складывание назад
            while (outFruits.TryPop(out var fruit))
            {
                // если вес 1гр то "съедается"
                if (fruit == 1)
                {
                    continue;
                }

                // 19 / 2 = 9
                // 19 - 9 = 10
                // 19 = 10 и 9
                int left = fruit / 2;
                int right = fruit - left;

                queue.Push(left > right ? right : left);
            }
        }

        return iterations;
    }
}
