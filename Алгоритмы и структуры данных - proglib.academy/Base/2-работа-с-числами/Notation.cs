namespace Base;

/// <summary>
///     Системы счисления.
///     123 -> 27
/// </summary>
public static class Notation
{
    /// <summary>
    ///     Возвращает входящее число в 10 СС.
    ///     Входящая строка как число: длина <= 7, используется только 0..9
    /// </summary>
    /// <param name="number">Входящая число в виде строки.</param>
    /// <returns>Число.</returns>
    public static int GetAsDecimal(string number)
    {
        int[] numbers = new int[number.Length];

        // надо найти наибольшее число, N+1 это минимальная СС
        int max = 0;
        for (int i = 0; i < number.Length; i++)
        {
            numbers[i] = number[i] - '0';
            max = Math.Max(max, numbers[i]);
        }

        // тут СС 10
        if (max == 9)
        {
            return Convert.ToInt32(number);
        }

        return HornerCircuit(numbers, max + 1);
    }

    // схема Горнера
    public static int HornerCircuit(int[] numbers, int @base = 10)
    {
        int result = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            result = result * @base + numbers[i];
        }

        return result;
    }
}
