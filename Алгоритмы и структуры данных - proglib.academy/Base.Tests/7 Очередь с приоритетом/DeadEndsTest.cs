namespace Base.Tests.PriorityQueue;

public static class DeadEndsTest
{
    [Theory]
    [InlineData(new string[] { "10 20" }, 1)]
    [InlineData(new string[] { "10 20", "20 25" }, 2)]
    [InlineData(new string[] { "10 20", "20 25", "21 30" }, 2)]
    public static void ExecuteTest(string[] values, int expected)
    {
        // arrange
        var test = new Base.PriorityQueue.DeadEnds();
        var items = new List<(int start, int end)>();

        // act
        foreach (var item in values)
        {
            var str = item.Trim().Split(" ");
            items.Add((Convert.ToInt32(str[0]), Convert.ToInt32(str[1])));
        }

        var result = test.Execute(items.ToArray());

        // assert
        Assert.Equal(expected, result);
    }
}
