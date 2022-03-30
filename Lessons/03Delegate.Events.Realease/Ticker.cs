namespace Delegate.Events.Realease;

public class Ticker
{
    public string Name { get; }

    public event EventHandler<ThresholdReachedEventArgs>? ThresholdReached;
    private int _count;
    private readonly int _threshold;

    public Ticker(string name, int threshold = 8)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentException(nameof(name));
        if (threshold < 1)
            throw new ArgumentException(nameof(threshold));
        Name = name;
        _threshold = threshold;
    }

    public void Tick()
    {
        while (true)
        {
            Thread.Sleep(1000);
            if (_threshold != _count++) continue;
            OnThresholdReached(new ThresholdReachedEventArgs(_threshold));
            _count = 0;
        }
        // ReSharper disable once FunctionNeverReturns
    }

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e) =>
        ThresholdReached?.Invoke(this, e);
}