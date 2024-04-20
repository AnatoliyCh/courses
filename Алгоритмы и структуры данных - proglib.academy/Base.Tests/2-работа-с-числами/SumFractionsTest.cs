namespace Base.Tests;

public class SumFractionsTest
{
    [Theory]
    [InlineData(new int[] { 3, 10, 5, 18 }, new int[] { 26, 45 })]
    [InlineData(new int[] { 1, 2, 1, 3 }, new int[] { 5, 6 })]
    [InlineData(new int[] { 133, 234, 54, 567 }, new int[] { 1087, 1638 })]
    public void GetSumFractions(int[] values, int[] expected)
    {
        // arrange    

        // act
        int[] result = SumFractions.GetSumFractions(values);

        // assert
        Assert.Equal(expected, result);
    }
}
