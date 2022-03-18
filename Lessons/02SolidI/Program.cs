//SOLID

//4. I - interface segregation
//Программные сущности не должны зависеть от методов, к-ые они не используют

//Не верно
/*
IPrinterTasks printer = new NoNamePrinter();
printer.Fax("gbghjkjhlk");


interface IPrinterTasks
{
    void Print(string printContent);
    void PrintDuplex(string printDuplexContent);
    void Scan(string scanContent);
    void Fax(string faxContent);
}

public class HpLaserJetPrinter : IPrinterTasks
{
    public void Print(string printContent)
    {
        //...
        Console.WriteLine("Print Done");
    }
    public void Scan(string scanContent)
    {
        //...
        Console.WriteLine("Scan content");
    }
    public void Fax(string faxContent)
    {
        //...
        Console.WriteLine("Fax content");
    }
    public void PrintDuplex(string printDuplexContent)
    {
        //...
        Console.WriteLine("Print Duplex content");
    }
}

class NoNamePrinter : IPrinterTasks
{
    public void Print(string printContent)
    {
        //...
        Console.WriteLine("Print Done");
    }
    public void Scan(string scanContent)
    {
        //...
        Console.WriteLine("Scan content");
    }

    public void PrintDuplex(string printDuplexContent)
    {
        throw new Exception("Не умею!");
    }

    public void Fax(string faxContent)
    {
        throw new Exception("Не умею!");
    }
}
*/ 
//Верно

/*
IPrinterTasks printer = new NoNamePrinter();
printer.Fax("gbghjkjhlk");

public interface IPrinterTasks
{
    void Print(string printContent);
    void Scan(string scanContent);
}

interface IFaxTasks
{
    void Fax(string content);
}
interface IPrintDuplexTasks
{
    void PrintDuplex(string content);
}

public class HpLaserJetPrinter : IPrinterTasks, IFaxTasks, IPrintDuplexTasks
{
    public void Print(string printContent)
    {
        //...
        Console.WriteLine("Print Done");
    }
    public void Scan(string scanContent)
    {
        //...
        Console.WriteLine("Scan content");
    }
    public void Fax(string faxContent)
    {
        //...
        Console.WriteLine("Fax content");
    }
    public void PrintDuplex(string printDuplexContent)
    {
        //...
        Console.WriteLine("Print Duplex content");
    }
}

class NoNamePrinter : IPrinterTasks
{
    public void Print(string printContent)
    {
        //...
        Console.WriteLine("Print Done");
    }
    public void Scan(string scanContent)
    {
        //...
        Console.WriteLine("Scan content");
    }
}
*/