namespace MetanitGenerics;

internal abstract class Sender
{
    public abstract void Send(ContextMsg context);
}

internal class Pc : Sender
{
    public override void Send(ContextMsg context) => WriteLine($"Email: {context}");
}

internal class Phone : Sender
{
    public override void Send(ContextMsg context) => WriteLine($"SMS: {context}");
}

internal abstract class ContextMsg
{
    protected string Context { get; init; } = null!;

    public override string ToString() => Context;
}

internal class TextMsg : ContextMsg
{
    internal TextMsg(string text) => Context = text;
}


internal class Image
{
    internal string GetBytesToString => "[ готовим картину к посылу ]";
}

internal class ImageMsg : ContextMsg
{
    public ImageMsg(Image image) => Context = image.GetBytesToString;
}

internal static class Searcher
{
    internal static Pc FindPc() => new();
    internal static Phone FindPhone() => new();
}