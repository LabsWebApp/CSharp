namespace Enumerations.UserCollections;

public class Element
{
    public Element(string name, int property1, int property2)
    {
        Name = name;
        Property1 = property1;
        Property2 = property2;
    }

    public string Name { get; set; }
    public int Property1 { get; set; }
    public int Property2 { get; set; }

    public override string ToString() => $"Name = {Name}; Property1 = {Property1}; Property2 = {Property2}";
}