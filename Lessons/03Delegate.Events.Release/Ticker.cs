namespace Delegate.Events.Release;

public class Ticker
{
    public event EventHandler<ZeroHourReachedEventArgs>? ZeroHourReached;

    public string Name { get; }

    private int _count;
    private readonly int _zeroHour;

    public Ticker(string name, int zeroHour = 3)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException(nameof(name));
        if (zeroHour <= 0)
            throw new ArgumentException(nameof(zeroHour));
        Name = name.Trim();
        _zeroHour = zeroHour;
    }

    public void Tick()
    {
        while (true)
        {
            Thread.Sleep(1000);
            if (_zeroHour != _count++) continue;

            OnZeroHourReached(new ZeroHourReachedEventArgs(_zeroHour));
            _count = 0;
        }
        // ReSharper disable once FunctionNeverReturns
    }

    protected virtual void OnZeroHourReached(ZeroHourReachedEventArgs e) =>
        ZeroHourReached?.Invoke(this, e);
}