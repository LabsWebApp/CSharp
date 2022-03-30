namespace Delegate.Events.Realease.Handlers;

public interface IThresholdReachedHandler
{
    void ThresholdReached(object sender, ThresholdReachedEventArgs e) => WriteLine();
}