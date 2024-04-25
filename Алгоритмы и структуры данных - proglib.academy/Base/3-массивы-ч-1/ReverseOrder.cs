namespace Base;

/// <summary>
///     Обратный порядок.
///     3 9 -5 2 -> 2 -5 9 3
/// </summary>
public static class ReverseOrder
{
    public static int[] Reverse(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            int temp = array[i];
            array[i] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = temp;
        }

        return array;
    }
}
