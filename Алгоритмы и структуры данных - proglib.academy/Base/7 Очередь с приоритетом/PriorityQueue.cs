namespace Base.PriorityQueue;

public sealed class PriorityQueue
{
    private readonly IList<int> items;

    public PriorityQueue()
    {
        items = new List<int>();
    }

    public int LastIndex { get => items is null ? -1 : items.Count - 1; }

    public int Count { get => items.Count; }

    /// <summary>
    /// Добавить в очередь элемент по приоритету (сравнение).
    /// </summary>
    /// <param name="item">Новый элемент.</param>
    public void Push(int item)
    {
        items.Add(item);
        SiftUp(LastIndex);
    }

    /// <summary>
    /// Извлечь из очереди и вернуть элемент с наивысшим приоритетом.
    /// </summary>
    /// <returns>Элемент с вершины кучи.</returns>
    public int? Pop()
    {
        if (items.Count == 0)
        {
            return null;
        }

        var result = items[0];
        if (items.Count == 1)
        {
            items.RemoveAt(0);
            return result;
        }

        items[0] = items[^1];
        items.RemoveAt(LastIndex);
        SiftDown(0);

        return result;
    }

    /// <summary>
    /// Просмотреть элемент с наивысшим приоритетом без извлечения.
    /// </summary>
    /// <returns>Элемент с вершины кучи.</returns>
    public int? Top()
    {
        return items.Count > 0 ? items[0] : null;
    }

    /// <summary>
    /// Элемент стал больше, чем родительский и его нужно "просеять" наверх.
    /// </summary>
    /// <param name="index">Индекс элемента, который нужно протолкнуть.</param>
    private void SiftUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (!(items[parent] < items[index]))
            {
                return;
            }

            (items[index], items[parent]) = (items[parent], items[index]);
            index = parent;
        }
    }

    /// <summary>
    /// Элемент стал меньше, чем дочерний и его нужно "просеять" вниз.
    /// проталкивание элемента вниз.
    /// </summary>
    private void SiftDown(int index)
    {
        while (true)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            // ищем наибольший элемент из трех: i, left, right
            int largest = index;

            // left < items.Count - это значит есть дочерний элемент (принадлежит массиву)
            if (left < items.Count && items[index] < items[left])
            {
                largest = left;
            }
            if (right < items.Count && items[largest] < items[right])
            {
                largest = right;
            }
            if (largest == index)
            {
                return;
            }

            (items[largest], items[index]) = (items[index], items[largest]);
            index = largest;
        }
    }
}