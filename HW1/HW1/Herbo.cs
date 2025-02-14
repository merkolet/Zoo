namespace HW1;

/// <summary>
/// Травоядные.
/// </summary>
public abstract class Herbo : Animal
{
    public int Kindness { get; set; }

    protected Herbo(int number, string name) : base(number, name) { }
}