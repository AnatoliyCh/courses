namespace Base.Tests.PriorityQueue;

public static class GreedyTest
{
    [Theory]
    [InlineData(new int[] { 1, 2, 2 }, 2, 4)]
    [InlineData(new int[] { 4, 3, 5 }, 6, 5)]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 3, 3)]
    public static void ExecuteTest(int[] values, int maxWeight, int expected)
    {
        // arrange
        var executor = new Base.PriorityQueue.Greedy();

        // act
        var result = executor.Execute(values, maxWeight);

        // assert
        Assert.Equal(expected, result);
    }
}
