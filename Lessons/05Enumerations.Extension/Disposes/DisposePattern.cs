namespace Enumerations.Extension.Disposes;

public class DisposePattern : IDisposable
{
    private AutoResetEvent _event = new AutoResetEvent(true);

    public bool IsDisposed { get; private set; }

    // Для не-sealed классов
    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                // Освобождаем только управляемые ресурсы
                _event.Dispose();
            }
            IsDisposed = true;
        }
        // Освобождаем неуправляемые ресурсы
    }

    // Для sealed классов
    // private void Dispose(bool disposing)
    // {
    //      if (disposing)
    //      {
    //          _event.Dispose();
    //      }
    // }
    //

    public void Dispose()
    {
        Dispose(true /*called by user directly*/);
        GC.SuppressFinalize(this);
    }

    ~DisposePattern()
    {
        Dispose(false);
    }
}