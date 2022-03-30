// Ковариантность обобщений.

Circle circle = new Circle();

IContainer<Shape> container = new Container<Shape>(circle);
//IContainer<Circle> container = new Container<Circle>(circle);

Console.WriteLine(container.Figure.GetType().FullName);


public abstract class Shape { }
public class Circle : Shape { }

public interface IContainer<T>
{
    T Figure { get; set; }
}

public class Container<T> : IContainer<T>
{
    public T Figure { get; set; }

    public Container(T figure)
    {
        this.Figure = figure;
    }
}