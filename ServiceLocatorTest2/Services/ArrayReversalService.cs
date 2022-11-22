namespace ServiceLocatorTest2.Services;

public class ArrayReversalService : IArrayReversalService
{
    public string ReverseArray(string arrayToReverse)
    {
        var origArray = arrayToReverse.Split(' ');

        var reversedArray = new string[origArray.Length];

        for (int i = origArray.Length - 1; i >= 0; i--)
        {
            reversedArray[origArray.Length - i - 1] = origArray[i];
        }

        return String.Join(' ', reversedArray);
    }
}