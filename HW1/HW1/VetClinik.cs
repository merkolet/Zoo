namespace HW1;

public class VetClinik
{
    public virtual bool CheckHealth(Animal animal)
    {
        return new Random().Next(0, 2) == 1; // Сделал рандомное решение о здоровье.
    }
}