namespace Delegate.Events.Release.Handlers;

// ReSharper disable once IdentifierTypo
public class Kolya : IZeroHourReachedHandler
{
    public void ZeroHourReached(object? sender, ZeroHourReachedEventArgs e)
    {
        if (sender is not Ticker
            {
                Name: "MessagesTicker" or "messagesTicker" or "_messagesTicker"
            } ticker) return;

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
            $"{nameof(Kolya)}: Пора в качалку! Ведь уже {e.ZeroHour} (реальное время: {e.ReachedTime.ToLongTimeString()})\n");
    }
}