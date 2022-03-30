namespace Delegate.Events.Realease.Handlers;

// ReSharper disable once IdentifierTypo
public class Kolya : IThresholdReachedHandler
{
    public void ThresholdReached(object sender, ThresholdReachedEventArgs e)
    {
        if (sender is not Ticker { Name: "MessagesTicker" } ticker) return;
        WriteLine($"[{ticker.Name}:]");
        WriteLine("    0                        0");
        WriteLine("   00                        00");
        WriteLine("   00                        00");
        WriteLine("  000                        000");
        WriteLine("**000************************000**");
        WriteLine("  000                        000");
        WriteLine("   00                        00");
        WriteLine("   00                        00");
        WriteLine("    0                        0");
        WriteLine(
            $"{nameof(Vasja)}: Пора в качалку! Ведь уже {e.TimeReached.ToShortTimeString()}\n");
    }
}