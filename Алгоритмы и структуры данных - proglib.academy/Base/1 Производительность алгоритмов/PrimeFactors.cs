namespace Base;

/// <summary>
///     Разложение натурального числа n на простые множители.
///     75 -> 3 5 5
///     20 -> 2 2 5
/// </summary>
public static class PrimeFactors
{
    public static int[] GetPrimeFactors(int number)
    {
        IList<int> factors = new List<int>();
        for (int i = 2; i <= MathF.Sqrt(number); i++)
        {
            while (number % i == 0)
            {
                factors.Add(i);
                number /= i;
            }
        }

        if (number != 1)
        {
            factors.Add(number);
        }

        return factors.ToArray();
    }
}
