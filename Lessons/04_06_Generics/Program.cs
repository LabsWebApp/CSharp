// Контравариантность обобщений.
var circle = new Circle();

IContainer<Circle> container = new Container<Shape>(circle);
//IContainer<Circle> container = new Container<Circle>(circle);

Console.WriteLine(container);


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

    public override string ToString() => _figure!.GetType().ToString();
}