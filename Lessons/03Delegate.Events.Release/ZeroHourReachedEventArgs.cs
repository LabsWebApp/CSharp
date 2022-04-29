namespace Delegate.Events.Release;

public class ZeroHourReachedEventArgs : EventArgs
{
    /// <summary>
    /// это поле под вопросом!
    /// </summary>
    public int ZeroHour { get; init; } 

    public readonly DateTime ReachedTime = DateTime.Now;

    public ZeroHourReachedEventArgs(int zeroHour) => ZeroHour = zeroHour;
}