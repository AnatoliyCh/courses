namespace Base;

/// <summary>
///     Нужная сумма.
///     -5 0 3 18 | -10 -2 4 7 12 | sum: 7 -> 3
/// </summary>
public static class RequiredAmount
{
    public static int Amount(int[] arrA, int[] arrB, int amount)
    {
        int numberSum = 0;
        int lastI = arrB.Length - 1;
        foreach (var aItem in arrA)
        {
            for (int i = lastI; i >= 0; i--)
            {
                if (aItem + arrB[i] == amount)
                {
                    numberSum++;
                }

                if (i != 0 && aItem + arrB[i - 1] < amount)
                {
                    lastI = i;

                    break;
                }
            }
        }

        return numberSum;
    }
}
