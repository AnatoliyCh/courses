using Base.SortPart_1;

namespace Base.Tests.SortPart_1;

public static class BoxesTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public static void ExecuteTest(int size, string[] data, string expected)
    {
        // arrange
        var test = new Boxes();

        // act
        var result = test.Execute(size, data);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(new int[] { }, new int[] { })]
    [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
    public static void SortBubbleTest(int[]? data, int[]? expected)
    {
        // arrange

        // act
        var result = Boxes.SortBubble(data, Boxes.DefaultComparer);

        // assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { 3, new string[] { "2 3 5", "1 1 1", "10 4 10" }, "1 0 2" };
    }
}
