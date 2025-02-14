namespace HW1;

public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; }
    public int Number { get; private set; }
    public string Name { get; protected set; }

    protected Animal(int number, string name)
    {
        Number = number;
        Name = name;
    }
}