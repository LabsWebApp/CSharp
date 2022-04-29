namespace Delegate.Events.Release.Handlers;

// ReSharper disable once IdentifierTypo
public class Vasja : IZeroHourReachedHandler
{
    public void ZeroHourReached(object? _, ZeroHourReachedEventArgs e) 
    {
        WriteLine("***********");
        WriteLine(" *********");
        WriteLine("  *******");
        WriteLine("   *****");
        WriteLine("    ***");
        WriteLine("     *");
        WriteLine("     *");
        WriteLine("     *");
        WriteLine("    ***");
        WriteLine("  *******");
        WriteLine(
            $"{nameof(Vasja)}: Надо остограмиться! Ведь уже {e.ZeroHour} (реальное время: {e.ReachedTime.ToLongTimeString()})\n");
    }
}