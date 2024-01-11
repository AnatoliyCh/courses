namespace Base.Tests;

public class FactorialZerosTest
{
    [Theory]
    [InlineData(25, 6)]
    [InlineData(1, 0)]
    [InlineData(5, 1)]
    public void GetFactorialZeros(int number, int expected)
    {
        // arrange    

        // act
        int zeros = FactorialZeros.GetFactorialZeros(number);

        // assert
        Assert.Equal(expected, zeros);
    }

    [Theory]
    [InlineData(25, 6)]
    [InlineData(1, 0)]
    [InlineData(5, 1)]
    public void GetFactorialZerosRecursion(int number, int expected)
    {
        // arrange

        // act
        int zeros = FactorialZeros.GetFactorialZerosRecursion(number);

        // assert
        Assert.Equal(expected, zeros);
    }
}
