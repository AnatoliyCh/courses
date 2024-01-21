namespace Base.Tests;

public class PrimeFactorsTest
{
    [Theory]
    [InlineData(75, new int[] { 3, 5, 5 })]
    [InlineData(20, new int[] { 2, 2, 5 })]
    public void GetPrimeFactors(int number, int[] expected)
    {
        // arrange    

        // act
        var factors = PrimeFactors.GetPrimeFactors(number);

        // assert
        Assert.Equal(expected, factors);
    }
}
