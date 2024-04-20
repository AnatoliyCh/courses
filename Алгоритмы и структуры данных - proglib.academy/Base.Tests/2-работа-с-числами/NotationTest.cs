namespace Base.Tests;

public class NotationTest
{
    [Theory]
    [InlineData(new int[] { 1, 0, 6 }, 10, 106)]
    [InlineData(new int[] { 1, 0, 6, 4, 4 }, 10, 10644)]
    [InlineData(new int[] { 1, 0, 1, 1, 0 }, 2, 22)]
    public void HornerCircuit(int[] values, int @base, int expected)
    {
        // arrange    

        // act
        int result = Notation.HornerCircuit(values, @base);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123", 27)]
    [InlineData("99", 99)]
    [InlineData("10110", 22)]
    public void GetAsDecimal(string number, int expected)
    {
        // arrange    

        // act
        int result = Notation.GetAsDecimal(number);

        // assert
        Assert.Equal(expected, result);
    }
}
