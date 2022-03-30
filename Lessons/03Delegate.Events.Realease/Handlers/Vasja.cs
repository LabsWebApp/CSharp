namespace Delegate.Events.Realease.Handlers;

// ReSharper disable once IdentifierTypo
public class Vasja : IThresholdReachedHandler
{
    public void ThresholdReached(object? _, ThresholdReachedEventArgs e) 
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
            $"{nameof(Vasja)}: Надо остограмиться! Ведь уже {e.TimeReached.ToShortTimeString()}\n");
    }
}