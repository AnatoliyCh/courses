namespace Base.Tests.ArrayPart2;

public class TransformationTest
{
    [Theory]
    [InlineData(new int[] { 1, 6, 1, 1, 4, 4 }, 0)]
    [InlineData(new int[] { 1, 2 }, 0)]
    [InlineData(new int[] { 1, 1 }, 2)]
    [InlineData(new int[] { 4, 5, 4, 5, 4 }, 1)]
    [InlineData(new int[] { 2, 3, 2, 1, 3, 1 }, 0)]
    [InlineData(new int[] { 2, 2, 3, 3, 3, 4, 4, 4, 4, 4, 4 }, 1)]
    [InlineData(new int[] { 7, 7, 7, 9, 9, 9, 3, 3, 3, 2, 2, 2, 1, 1, 1, 5, 5, 5, 6, 6 }, 0)]
    public void Transformation(int[] arr, int expected)
    {
        // arrange    

        // act
        int result = Base.ArrayPart2.Transformation.Execute(arr);

        // assert
        Assert.Equal(expected, result);
    }
}
