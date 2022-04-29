namespace Delegate.Events.Release.Handlers;

public interface IZeroHourReachedHandler
{
    void ZeroHourReached(object? sender, ZeroHourReachedEventArgs e);
}