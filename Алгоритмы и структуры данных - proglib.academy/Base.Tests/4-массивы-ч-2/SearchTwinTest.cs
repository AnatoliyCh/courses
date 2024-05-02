using Base.ArrayPart2;

namespace Base.Tests.ArrayPart2;

public class SearchTwinTest
{
    [Theory]
    [InlineData(new int[] { 1, 20, 20, 20, 30, 40, 50 }, new int[] { 25 }, new int[] { 1 })]
    [InlineData(new int[] { 10, 20, 30 }, new int[] { 9, 15, 35 }, new int[] { 0, 0, 2 })]
    [InlineData(new int[] { 10, 20, 30 }, new int[] { 8, 9, 10, 32 }, new int[] { 0, 0, 0, 2 })]
    [InlineData(new int[] { 22, 24, 28, 34, 35, 45, 47, 54, 60, 70 }, new int[] { 49 }, new int[] { 6 })]
    public void SearchTest(int[] arrA, int[] arrB, int[] expected)
    {
        // arrange    

        // act
        int[] result = SearchTwin.Search(arrA, arrB);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 0)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, 1)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6, 8)]
    [InlineData(new int[] { 21, 24, 27, 29, 33, 35, 41, 51, 53, 62 }, 29, 4)]
    [InlineData(new int[] { 23, 29, 37, 40, 50, 51, 53, 61, 64, 71 }, 48, 4)]
    public void TwinRangeSearchTest(int[] arrA, int element, int expected)
    {
        // arrange    

        // act
        int result = SearchTwin.RangeSearch(arrA, element);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 9, 8, 7)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 7, 7, 7, 7, 10 }, 0, 9, 7, 5)]
    [InlineData(new int[] { 1, 1, 1, 4, 5, 6, 7, 8, 9, 10 }, 0, 9, 1, 0)]
    [InlineData(new int[] { 21, 24, 27, 29, 33, 35, 41, 51, 53, 62 }, 2, 4, 29, 3)]
    [InlineData(new int[] { 23, 29, 37, 40, 50, 51, 53, 61, 64, 71 }, 2, 4, 48, 4)]
    public void TwinBinarySearchLowerBoundTest(int[] arrA, int start, int end, int element, int expected)
    {
        // arrange    

        // act
        int result = SearchTwin.LowerBound(arrA, (start, end), element);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 9, 8, 8)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 7, 7, 7, 7, 10 }, 0, 9, 7, 9)]
    [InlineData(new int[] { 1, 1, 1, 4, 5, 6, 7, 8, 9, 10 }, 0, 9, 1, 3)]
    public void TwinBinarySearchUpperBoundTest(int[] arrA, int start, int end, int element, int expected)
    {
        // arrange    

        // act
        int result = SearchTwin.UpperBound(arrA, (start, end), element);

        // assert
        Assert.Equal(expected, result);
    }
}
