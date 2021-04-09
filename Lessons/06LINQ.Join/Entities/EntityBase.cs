namespace LINQ.Join.Entities
{
    public abstract record EntityBase
    {
        public int Id { get; init;}
        public string Name { get; set; }
    }
}
