namespace Base.Tests;

public class AmountTest
{
    [Theory]
    [InlineData(new int[] { -5, 0, 3, 18 }, new int[] { -10, -2, 4, 7, 12 }, 7, 3)]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 4, 3)]
    public void Amount(int[] arrA, int[] arrB, int amount, int expected)
    {
        // arrange    

        // act
        int result = RequiredAmount.Amount(arrA, arrB, amount);

        // assert
        Assert.Equal(expected, result);
    }
}
