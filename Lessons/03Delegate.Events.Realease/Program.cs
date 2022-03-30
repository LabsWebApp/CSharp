using Delegate.Events.Realease;
using Delegate.Events.Realease.Handlers;

Ticker ticker = new("MessagesTicker");
Vasja vasja = new();
Kolya kolya = new();

ticker.ThresholdReached += vasja.ThresholdReached;