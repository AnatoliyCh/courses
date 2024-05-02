namespace Base.ArrayPart2;

/// <summary>
///     Поиск близнеца.
///     10 20 30 | 9 15 35 -> 0 0 2
/// </summary>
public static class SearchTwin
{
    public static int[] Search(int[] arrA, int[] arrB)
    {
        var result = new int[arrB.Length];
        for (int i = 0; i < arrB.Length; i++)
        {
            int elementB = arrB[i];
            int maxIndex = RangeSearch(arrA, elementB);
            int lowerBound = LowerBound(arrA, (maxIndex / 2, maxIndex), elementB);

            // если найденный index искомое число 
            // ИЛИ просто первый index 
            // ИЛИ разница с тек. элементом меньше, чем с пред.
            if (elementB == arrA[lowerBound] ||
                lowerBound == 0 ||
                (Math.Abs(elementB - arrA[lowerBound]) < Math.Abs(elementB - arrA[lowerBound - 1])))
            {
                result[i] = lowerBound;

                continue;
            }

            // проходка влево, чтобы найти минимальный (по индексу и значению) элемент 
            for (int j = lowerBound - 1; j >= (maxIndex / 2) - 1; j--)
            {
                if (j != 0 && Math.Abs(elementB - arrA[j]) >= Math.Abs(elementB - arrA[j - 1]))
                {
                    continue;
                }

                result[i] = j;

                break;
            }
        }

        return result;
    }

    /// <summary>
    ///     Поиск диапазона, методом удвоения.
    ///     Срезает зону поиска.
    /// </summary>
    /// <param name="arr">Массив по которому пробегаем.</param>
    /// <param name="element">Значение для сравнения.</param>
    public static int RangeSearch(int[] arr, int element)
    {
        if (arr[0] >= element)
        {
            return 0;
        }

        int find = 1;
        while (arr[find] < element)
        {
            find *= 2;

            if (find >= arr.Length)
            {
                find = arr.Length - 1;

                break;
            }
        }

        return find;
    }

    // * бинарный поиск

    /// <summary>
    ///     Поиск левой (нижней) границы.
    ///     Находит минимальный индекс arr[i] >= X.
    /// </summary>
    /// <param name="arr">Массив по которому пробегаем.</param>    
    /// <param name="bound">Диапазон, с которым работаем (от index/2 до index). Чтобы не пересоздавать новые массивы.</param>
    /// <param name="element">Значение для сравнения.</param>
    /// <returns>Минимальный индекс arr[i] >= X</returns>
    public static int LowerBound(int[] arr, (int start, int end) bound, int element)
    {
        int first = bound.start; // левый край
        int last = bound.end; // правый край
        while (first < last)
        {
            int mid = (first + last) / 2;
            if (arr[mid] < element)
            {
                first = mid + 1;
            }
            else
            {
                last = mid;
            }
        }

        return first;
    }

    /// <summary>
    ///     Поиск правой (верхней) границы.
    ///     Находит минимальный индекс arr[i] > X. 
    /// </summary>
    /// <param name="arr">Массив по которому пробегаем.</param>    
    /// <param name="bound">Диапазон, с которым работаем (от index/2 до index). Чтобы не пересоздавать новые массивы.</param>
    /// <param name="element">Значение для сравнения.</param>
    /// <returns>минимальный индекс arr[i] > X</returns>
    public static int UpperBound(int[] arr, (int start, int end) bound, int element)
    {
        int first = bound.start; // левый край
        int last = bound.end; // правый край
        while (first < last)
        {
            int mid = (first + last) / 2;
            if (arr[mid] <= element)
            {
                first = mid + 1;
            }
            else
            {
                last = mid;
            }
        }

        return first;
    }
}
