using Base.ArithmeticExpressionsQueueDec;

namespace Base.Tests.ArithmeticExpressionsQueueDec;

public static class DynamicBufferQueueTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(5)]
    public static void QueueInitBySizeTest(int size)
    {
        // arrange

        // act
        var result = new DynamicBufferQueue.Queue<int>(size);

        // assert
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData(0, new int[0]),]
    [InlineData(3, new[] { 1, 2, 3 })]
    [InlineData(5, new[] { 1, 2, 3, 4, 5 })]
    public static void QueueIsEmptyTest(int size, int[] items)
    {
        // arrange
        var queue = new DynamicBufferQueue.Queue<int>(size);

        // act
        foreach (var item in items)
        {
            queue.Enqueue(item);
        }

        while (!queue.IsEmpty)
        {
            queue.Dequeue();
        }

        // assert
        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public static void QueueEnqueueDequeueTest()
    {
        // arrange
        var queue = new DynamicBufferQueue.Queue<int>(2);

        // act
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue();

        // assert
        Assert.False(queue.IsEmpty);
    }

    [Fact]
    public static void QueueCircularTest()
    {
        // arrange
        var queue = new DynamicBufferQueue.Queue<int>(2);

        // act
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue();
        queue.Enqueue(3);

        // assert
        Assert.False(queue.IsEmpty);
    }

    [Theory]
    [InlineData("1", new[] { "3 44", "3 50", "2 44" }, "YES")]
    [InlineData("2", new[] { "2 -1", "3 10" }, "YES")]
    [InlineData("3", new[] { "3 44", "2 66" }, "NO")]
    public static void ExecuteTest(string count, string[] commands, string expected)
    {
        // arrange

        // act
        var result = DynamicBufferQueue.Execute(Convert.ToInt32(count), commands);

        // assert
        Assert.Equal(expected, result);
    }

}
