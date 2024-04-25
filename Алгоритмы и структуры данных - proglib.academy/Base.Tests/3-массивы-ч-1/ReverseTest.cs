namespace Base.Tests;

public class ReverseTest
{
    [Theory]
    [InlineData(new int[] { 3, 9, -5, 2 }, new int[] { 2, -5, 9, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
    public void Reverse(int[] values, int[] expected)
    {
        // arrange    

        // act
        int[] result = ReverseOrder.Reverse(values);

        // assert
        Assert.Equal(expected, result);
    }
}
