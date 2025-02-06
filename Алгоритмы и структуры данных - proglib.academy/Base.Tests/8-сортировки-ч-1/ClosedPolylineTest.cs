using Base.SortPart_1;
using static Base.SortPart_1.ClosedPolyline;

namespace Base.Tests.SortPart_1;


public static class ClosedPolylineTest
{
    private static readonly string pathResults = @"E:\repositories\courses\Алгоритмы и структуры данных - proglib.academy\Base.Tests\8-сортировки-ч-1\result.txt";

    [Theory]
    [MemberData(nameof(ExecuteTestData))]
    public static void ExecuteTest(string[] data, string[] expected)
    {
        // arrange
        var test = new ClosedPolyline();

        // act
        var result = test.Execute(data);

        if (data.Length == 10000)
        {
            File.WriteAllLines(pathResults, result);
        }

        // assert
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> ExecuteTestData()
    {
        yield return new object[] { new string[] { "0 0", "1 1", "1 0", "0 1" }, new string[] { "0 0", "0 1", "1 1", "1 0" } };
        yield return new object[] { new string[] { "1 0", "1 2", "0 0", "1 1", "0 2", "2 3" }, new string[] { "0 0", "0 2", "1 2", "2 3", "1 1", "1 0" } };
        yield return new object[] { new string[] { "1 6", "9 5", "0 4", "7 6", "2 5", "3 5", "-1 0", "0 -2", "1 1", "-1 -1" }, new string[] { "-1 -1", "-1 0", "0 4", "1 6", "2 5", "3 5", "1 1", "7 6", "9 5", "0 -2" } };
        yield return new object[] { new string[] { "4 7", "3 6", "5 4", "2 6", "3 7", "3 10", "7 6", "2 5", "4 4", "1 1" }, new string[] { "1 1", "2 6", "3 10", "2 5", "3 7", "3 6", "4 7", "4 4", "7 6", "5 4", } };

        var inputData = ReadFileData(@"../../../8-сортировки-ч-1/input.txt").ToArray();
        var expectedData = ReadFileData(@"../../../8-сортировки-ч-1/output.txt").ToArray();

        yield return new object[] { inputData, expectedData };
    }

    private static IEnumerable<string> ReadFileData(string fileName)
    {
        var lines = File.ReadLines(fileName);

        return lines;
    }
}
