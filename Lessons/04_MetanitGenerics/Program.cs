namespace MetanitGenerics;

internal delegate T MessageBuilder<out T>(string text);

internal delegate void MessageReceiver<in T>(T message);

internal delegate TResult MessageConverter<in TParam, out TResult>(TParam message);

internal delegate TResult FindSender<out TResult>();
internal delegate void Send<in T>(T param);

internal class Program
{
    static void Main()
    {
        // ковариантность
        EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);

        MessageBuilder<EmailMessage> eMessageBuilder = WriteEmailMessage;

        MessageBuilder<Message> messageBuilder = eMessageBuilder;     // ковариантность
        var message = messageBuilder("hello Tom"); // вызов делегата
        message.Print(); // Email: hello Tom

        // контравариантность
        void ReceiveMessage(Message m) => m.Print();

        MessageReceiver<Message> messageReceiver = ReceiveMessage;

        MessageReceiver<EmailMessage> eMessageReceiver = messageReceiver; // контравариантность
        eMessageReceiver(new EmailMessage("Hello World!"));

        // MIX
        EmailMessage ConvertToEmail(Message m) => 
            new EmailMessage(m.Text);

        MessageConverter<Message, EmailMessage> fConverter = ConvertToEmail;

        MessageConverter<SmsMessage, Message> converter = fConverter;
        var messageMix = converter(new SmsMessage("Delegates"));
        messageMix.Print();    // Email: Delegates


        ReadKey();



        // *********************
        var msg = new TextMsg("ПРИВЕТ");
        Send<TextMsg>? sendText;

        FindSender<Sender>? tool;
        FindSender<Pc> pc = Searcher.FindPc;

        tool = pc;
        var sender = tool.Invoke();
        Send<ContextMsg> send = sender.Send;

        sendText = send;

        sendText.Invoke(msg);

    }
}