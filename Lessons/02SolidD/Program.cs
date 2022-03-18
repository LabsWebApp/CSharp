//SOLID

//5. D - dependency inversion
//Модули верхнего уровня не должны зависеть от модулей нижнего уровня.
//Абстракции не должны зависеть от деталей.
//Всё должно зависеть от абстракций 

//не верно
/*
class Book
{
    public string? Text { get; set; }
    public ConsolePrinter Printer { get; set; } = null!;

    public void Print()
    {
        Printer.Print(Text ?? "no data");
    }
}

class ConsolePrinter
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}
*/
//Верно

Book book = new Book(new ConsolePrinter());
book.Print();
book.Printer = new HtmlPrinter();
book.Print();

interface IPrinter
{
    void Print(string text);
}

class Book
{
    public string? Text { get; set; }
    public IPrinter Printer { get; set; }

    public Book(IPrinter printer)
    {
        Printer = printer;
    }

    public void Print()
    {
        Printer.Print(Text ?? "no data");
    }
}

class ConsolePrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine("Печать на консоли:" + "\n" +text);
    }
}

class HtmlPrinter : IPrinter
{
    public void Print(string text)
    {
        Console.WriteLine("Печать в html");
        //....
    }
}
