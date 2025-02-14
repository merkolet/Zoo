namespace HW1;

public class Wolf : Predator
{
    public Wolf(int number, int food) : base(number, "Wolf")
    {
        Food = food;
    }
}