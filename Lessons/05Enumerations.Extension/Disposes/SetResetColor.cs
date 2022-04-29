namespace Enumerations.Extension.Disposes;

public class SetResetColor : IDisposable
{
    public static void ForAction(ConsoleColor color, Action action)
    {
        using (var _ = new SetResetColor(color))
        {
            action.Invoke();
        }
    }

    private readonly ConsoleColor? _oldColor;
    public SetResetColor(ConsoleColor color)
    {
        if (ForegroundColor != color)
        {
            _oldColor = ForegroundColor;
            ForegroundColor = color;
        }
    }

    void IDisposable.Dispose()
    {
        if (_oldColor != null) ForegroundColor = _oldColor.Value;
    }
}