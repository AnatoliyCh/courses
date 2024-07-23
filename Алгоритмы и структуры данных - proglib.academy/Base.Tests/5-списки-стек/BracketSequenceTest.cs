namespace Base.Tests.ListStack;

public class BracketSequenceTest
{
    [Theory]
    [InlineData("{}[[[[{}[]", "{}[[[[{}[]]]]]")]
    [InlineData("{][[[[{}[]", "IMPOSSIBLE")]
    [InlineData("]()}[](({}", "{[]()}[](({}))")]
    [InlineData("{[[[[{}]]])[]", "IMPOSSIBLE")]
    [InlineData(")([(())[]]({{{}}()[]}{}[()()", "()([(())[]]({{{}}()[]}{}[()()]))")]
    public void BracketSequence(string sequence, string expected)
    {
        // arrange    

        // act
        string result = Base.ListStack.BracketSequence.Execute(sequence);

        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("{}[[[[{}[]]]]]", false)]
    [InlineData("{][[[[{}[]", true)]
    [InlineData("{[]()}[](({}))", false)]
    [InlineData("{[[[[{}]]])[]", true)]
    public void HasWrongSequence(string sequence, bool expected)
    {
        // arrange    

        // act
        bool result = Base.ListStack.BracketSequence.HasWrongSequence(sequence);

        // assert
        Assert.Equal(expected, result);
    }
}