using ServiceLocatorIdea.Services;

namespace ServiceLocatorIdeaTest.Services;

public class ArrayReversalServiceTest
{
    private readonly WordReversalService _service;

    public ArrayReversalServiceTest()
    {
        _service = new WordReversalService();
    }

    [Fact]
    public void ReturnsSameLength()
    {
        var toReverse = "David Starr";
        var reversed = _service.ReverseWords(toReverse);

        Assert.Equal(toReverse.Length, reversed.Length);
    }


}