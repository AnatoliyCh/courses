namespace Base;

/// <summary>
///     Найти, на сколько нулей оканчивается n! = 1 * 2 * 3 * … * n. n ≤ 1000.
///     25 -> 6
///     1 -> 0
///     5 -> 1
/// </summary>
public static class FactorialZeros
{
    public static int GetFactorialZeros(int number)
    {
        int result = 0;
        while (number > 0)
        {
            result += number /= 5;
        }

        return result;
    }

    public static int GetFactorialZerosRecursion(int number)
    {
        int result = number /= 5;
        if (result == 0)
        {
            return 0;
        }

        return result += GetFactorialZerosRecursion(result);
    }
}
