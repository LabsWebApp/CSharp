namespace Delegate.Events.Realease;

public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; init; } 
    public readonly DateTime TimeReached = DateTime.Now;
    public ThresholdReachedEventArgs(int threshold) => Threshold = threshold;
}