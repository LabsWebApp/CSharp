namespace MetanitGenerics;

internal abstract class Message
{
    public string Text { get; }
    protected Message(string text) => Text = text;
    public abstract void Print();
}

internal class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
    public override void Print() => WriteLine($"Email: {Text}");
}

internal class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
    public override void Print() => WriteLine($"Sms: {Text}");
}