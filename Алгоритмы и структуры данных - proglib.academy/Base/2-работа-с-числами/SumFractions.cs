namespace Base;

/// <summary>
///     Сумма дробей.
///     Ответ в виде несократимой дроби m / n.
///     3 10 5 18 -> 26 45
/// </summary>
public static class SumFractions
{
    public static int[] GetSumFractions(int[] values)
    {
        int n1 = values[0]; // numerator
        int d1 = values[1]; // denominator
        int n2 = values[2];
        int d2 = values[3];

        // 1. общий знаменатель через НОК
        int lcm = LCM(d1, d2);

        // 2. доп. множители (числитель)
        int nResult = (n1 * (lcm / d1)) + (n2 * (lcm / d2));

        // 3. приведение к несократимой дроби через НОД
        int gcd = GCD(lcm, nResult);

        return new int[] { nResult / gcd, lcm / gcd };
    }

    /// <summary>
    ///     НОД.
    /// </summary>
    /// <returns>НОД.</returns>
    public static int GCD(int x, int y)
    {
        while (y != 0)
        {
            int r = x % y;
            x = y;
            y = r;
        }

        return x;
    }

    /// <summary>
    ///     НОК.
    /// </summary>
    /// <returns>НОК.</returns>
    public static int LCM(int x, int y)
    {
        return x * y / GCD(x, y);
    }
}
