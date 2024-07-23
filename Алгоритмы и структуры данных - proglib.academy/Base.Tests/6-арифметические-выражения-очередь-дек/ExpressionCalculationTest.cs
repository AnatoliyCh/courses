using Base.ArithmeticExpressionsQueueDec;

namespace Base.Tests.ArithmeticExpressionsQueueDec;

public static class ExpressionCalculationTest
{
    [Theory]
    [InlineData("3+4", new[] { "3", "+", "4", })]
    [InlineData("1*2+5", new[] { "1", "*", "2", "+", "5", })]
    [InlineData("1+8/4", new[] { "1", "+", "8", "/", "4" })]
    [InlineData("3+7/(4*5-6)", new[] { "3", "+", "7", "/", "(", "4", "*", "5", "-", "6", ")" })]
    [InlineData("3+7/(4*5-6)+8*9", new[] { "3", "+", "7", "/", "(", "4", "*", "5", "-", "6", ")", "+", "8", "*", "9", })]
    [InlineData("200-(123+34*2)+(48-2)", new[] { "200", "-", "(", "123", "+", "34", "*", "2", ")", "+", "(", "48", "-", "2", ")" })]
    public static void ParseTest(string expression, string[] expected)
    {
        // arrange

        // act
        var result = ExpressionCalculation.Parse(expression);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3+4", new[] { "3", "4", "+", })]
    [InlineData("1*2+5", new[] { "1", "2", "*", "5", "+", })]
    [InlineData("1+8/4", new[] { "1", "8", "4", "/", "+" })]
    [InlineData("3+7/(4*5-6)", new[] { "3", "7", "4", "5", "*", "6", "-", "/", "+", })]
    [InlineData("3+7/(4*5-6)+8*9", new[] { "3", "7", "4", "5", "*", "6", "-", "/", "+", "8", "9", "*", "+" })]
    public static void ConvertToOpzTest(string expression, string[] expected)
    {
        // arrange
        string[] arrExpression = ExpressionCalculation.Parse(expression.Trim());

        // act
        var result = ExpressionCalculation.ConvertToOpz(arrExpression);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3+4", 7)]
    [InlineData("1*2+5", 7)]
    [InlineData("1+8/4", 3)]
    [InlineData("3+7/(4*5-6)", 3.5)]
    [InlineData("3+7/(4*5-6)+8*9", 75.5)]
    [InlineData("200-(123+34*2)+(48-2)", 55)]
    public static void CalculationTest(string expression, float expected)
    {
        // arrange
        string[] arrExpression = ExpressionCalculation.Parse(expression.Trim());

        // act
        var result = ExpressionCalculation.Calculation(arrExpression);

        // assert
        Assert.Equal(expected, result);
    }
}
