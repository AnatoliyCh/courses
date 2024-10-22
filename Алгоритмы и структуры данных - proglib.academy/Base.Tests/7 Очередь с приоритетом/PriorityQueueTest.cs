namespace Base.Tests.PriorityQueue;

public static class PriorityQueueTest
{
    [Fact]
    public static void CreateTest()
    {
        // arrange

        // act
        var queue = new Base.PriorityQueue.PriorityQueue();

        // assert
        Assert.NotNull(queue);
        Assert.True(queue.LastIndex == -1);
    }

    [Theory]
    [MemberData(nameof(SimpleData))]
    public static void PushTest(int[] data)
    {
        // arrange
        var queue = new Base.PriorityQueue.PriorityQueue();

        // act
        foreach (var item in data)
        {
            queue.Push(item);
        }

        // assert
        Assert.True(queue.LastIndex == data.Length - 1);
    }

    [Theory]
    [MemberData(nameof(SimpleData))]
    public static void TopTest(int[] data)
    {
        // arrange
        var queue = new Base.PriorityQueue.PriorityQueue();

        // act
        int? max = data.Length != 0 ? data.MaxBy(item => item) : null;
        foreach (var item in data)
        {
            queue.Push(item);
        }

        // assert
        Assert.True(queue.Top() == max);
    }

    [Theory]
    [MemberData(nameof(PopData))]
    public static void PopTest(int[] data, int deleteCount, int? topElement)
    {
        // arrange
        var queue = new Base.PriorityQueue.PriorityQueue();
        var popElements = new List<int?>();

        // act
        foreach (var item in data)
        {
            queue.Push(item);
        }

        for (int i = 0; i < deleteCount; i++)
        {
            popElements.Add(queue.Pop());
        }

        // assert
        Assert.True(popElements.Count == deleteCount); // удалено нужное количество
        Assert.True(data.Length - deleteCount == queue.LastIndex + 1); // осталось == пришло - кол-во удалить
        Assert.True(queue.Top() == topElement);
    }

    public static IEnumerable<object[]> SimpleData()
    {
        yield return new object[] { Array.Empty<int>() };
        yield return new object[] { new int[] { 1 } };
        yield return new object[] { new int[] { 1, 2 } };
        yield return new object[] { new int[] { 1, 2, 3 } };
        yield return new object[] { new int[] { 1, 2, 3, 4 } };
        yield return new object[] { new int[] { 1, 2, 3, 4, 5 } };
        yield return new object[] { new int[] { 1, 1, 2, 2, 3, 3, 4, 5 } };
    }

    public static IEnumerable<object?[]> PopData()
    {
        yield return new object?[] { Array.Empty<int>(), 0, null };
        yield return new object[] { new int[] { 1 }, 0, 1 };
        yield return new object[] { new int[] { 1, 2 }, 1, 1 };
        yield return new object[] { new int[] { 1, 2, 3 }, 2, 1 };
        yield return new object[] { new int[] { 1, 2, 3, 4 }, 3, 1 };
        yield return new object[] { new int[] { 1, 2, 3, 4, 5 }, 4, 1 };
        yield return new object[] { new int[] { 6, 5, 4, 3, 2, 1 }, 4, 2 };
        yield return new object[] { new int[] { 100, 56, 34, 999 }, 2, 56 };
    }
}
