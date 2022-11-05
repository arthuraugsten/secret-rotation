namespace KeyRotation.Database;

internal sealed class MyEntity
{
    public MyEntity(Guid id, string name, DateTime date)
    {
        Id = id;
        Name = name;
        Date = date;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime Date { get; private set; }
}
