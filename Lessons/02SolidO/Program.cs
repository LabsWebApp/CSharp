//SOLID

//2. S - open-closed

//Неправильно:

namespace SolidO;

public class Invoice
{
    //...
    public double GetInvoiceDiscount(double amount, InvoiceType invoiceType) => invoiceType switch
    {
        InvoiceType.FinalInvoice => amount - 100,
        InvoiceType.ProposedInvoice => amount - 50,
        InvoiceType.XInvoice => amount - 22,
        _ => 0
    };
}
public enum InvoiceType
{
    FinalInvoice,
    ProposedInvoice,
    XInvoice
}

//Правильно:
/*
public class Invoice
{
    public virtual double GetInvoiceDiscount(double amount)
    {
        return amount - 10;
    }
}

public class FinalInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 50;
    }
}
public class ProposedInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 40;
    }
}
public class RecurringInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 30;
    }
}

*/