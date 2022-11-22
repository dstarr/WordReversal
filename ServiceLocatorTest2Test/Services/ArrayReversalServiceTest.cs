using ServiceLocatorIdea.Services;

namespace ServiceLocatorIdeaTest.Services;

public class ArrayReversalServiceTest
{
    private readonly ArrayReversalService _service;

    public ArrayReversalServiceTest()
    {
        _service = new ArrayReversalService();
    }

    [Fact]
    public void ReturnsSameLength()
    {
        var toReverse = "David Starr";
        var reversed = _service.ReverseArray(toReverse);

        Assert.Equal(toReverse.Length, reversed.Length);
    }


}