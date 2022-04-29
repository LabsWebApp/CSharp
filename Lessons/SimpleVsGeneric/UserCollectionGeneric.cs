namespace SimpleVsGeneric;

public class UserCollectionGeneric
{
    public static IEnumerable<int> Power()
    {
        for (var i = 0; i < UserCollection.Max; i++) yield return i;
    }
}