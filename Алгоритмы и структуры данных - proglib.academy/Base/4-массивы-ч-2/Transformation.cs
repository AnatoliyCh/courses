namespace Base.ArrayPart2;

/// <summary>
///     Трансформация.
///     1 6 1 1 4 4 -> 0
///     1 2         -> 0
///     1 1         -> 2
/// </summary>
public static class Transformation
{
    /// <summary>
    ///     Находит минимальный размер массива.
    /// </summary>
    /// <param name="arr">Массив над которым проводят операцию уменьшения.</param>
    /// <returns>Минимальный размер массива.</returns>
    public static int Execute(int[] arr)
    {
        var numbers = new Dictionary<int, int>(); // цифра: количество       

        // подсчет количества цифр 
        foreach (var number in arr)
        {
            if (numbers.TryGetValue(number, out int value))
            {
                numbers[number] = value + 1;

                continue;
            }

            numbers.Add(number, 1);
        }

        if (numbers.Count == 0)
        {
            return 0;
        }

        // отнимание количеств цифр друг от друга (по очереди), итоговый размер массива в current.value (количество одинаковых цифр, которые остались)
        (int key, int value) current = (0, 0);
        while (numbers.Count != 0)
        {
            if (current.value == 0 && numbers.Count > 0)
            {
                var newMax = numbers.MaxBy(item => item.Value);
                current = (newMax.Key, newMax.Value);
                numbers.Remove(newMax.Key);
            }

            if (numbers.Count == 0)
            {
                break;
            }

            var max = numbers.MaxBy(item => item.Value).Key;
            current.value--;
            numbers[max]--;
            if (numbers[max] == 0)
            {
                numbers.Remove(max);
            }
        }

        return current.value;
    }
}
