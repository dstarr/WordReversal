namespace WordReversal.Services;

public class WordReversalService : IWordReversalService
{
    public string ReverseWords(string wordsToReverse)
    {
        var origArray = wordsToReverse.Split(' ');

        var reversedArray = new string[origArray.Length];

        for (int i = origArray.Length - 1; i >= 0; i--)
        {
            reversedArray[origArray.Length - i - 1] = origArray[i];
        }

        return String.Join(' ', reversedArray);
    }
}