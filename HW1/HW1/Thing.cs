namespace HW1;

public class Thing : IInventory
{
    public int Number { get; private set; }
    public string Name { get; private set; }

    public Thing(int number, string name)
    {
        Number = number;
        Name = name;
    }
}