namespace HW1;

public class Rabbit : Herbo
{
    public Rabbit(int number, int food, int kindness) : base(number, "Rabbit")
    {
        Food = food;
        Kindness = kindness;
    }
}