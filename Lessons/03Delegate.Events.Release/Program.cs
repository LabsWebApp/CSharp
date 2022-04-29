using Delegate.Events.Release;
using Delegate.Events.Release.Handlers;


Ticker messagesTicker = new(nameof(messagesTicker));
Vasja vasja = new();
Kolya kolya = new();

messagesTicker.ZeroHourReached += vasja.ZeroHourReached;
messagesTicker.ZeroHourReached += kolya.ZeroHourReached;

messagesTicker.Tick();