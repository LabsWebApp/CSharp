// Контравариантность обобщений.

public abstract class Shape { }
public class Circle : Shape { }

public interface IContainer<in T>
{
    T Figure { set; }
}

public class Container<T> : IContainer<T>
{
    private T _figure;

    public Container(T figure)
    {
        this._figure = figure;
    }

    public T Figure
    {
        get => _figure;
        set => _figure = value;
    }

    public override string ToString()
    {
        return _figure.GetType().ToString();
    }
}