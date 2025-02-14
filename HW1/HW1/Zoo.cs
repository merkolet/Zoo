namespace HW1;

using System;
using System.Linq;

/// <summary>
/// Класс зоопарк.
/// </summary>
public class Zoo
{
    private readonly List<Animal> _animals = new();
    private readonly List<Thing> _inventory = new();
    private readonly VetClinik _vetClinik;

    public Zoo(VetClinik vetClinik)
    {
        _vetClinik = vetClinik;
    }

    public void AddAnimal(Animal animal)
    {
        if (_vetClinik.CheckHealth(animal))
        {
            _animals.Add(animal);
            Console.WriteLine($"(#{animal.Number}) {animal.Name} прибыл в зоопарк!");
        }
        else
        {
            Console.WriteLine($"(#{animal.Number}) {animal.Name} не сможет жить в зоопарке из-за плохого здоровья!");
        }
    }

    public void AddThing(Thing thing)
    {
        _inventory.Add(thing);
    }

    public void Report()
    {
        Console.WriteLine("\nОтчет по зоопарку:");
        Console.WriteLine($"Всего животных: {_animals.Count}");
        Console.WriteLine($"Общее потребление еды: {_animals.Sum(a => a.Food)} кг в день");
        
        Console.WriteLine("Животные в контактном зоопарке:");
        foreach (var animal in _animals)
        {
            Console.WriteLine($" - (#{animal.Number}) {animal.Name}");
        }

        Console.WriteLine("Животные, с которыми можно взаимодействовать:");
        foreach (var animal in _animals.OfType<Herbo>().Where(a => a.Kindness > 5))
        {
            Console.WriteLine($" - (#{animal.Number}) {animal.Name}, доброта: {animal.Kindness}");
        }
        
        Console.WriteLine("Инвентарь зоопарка:");
        foreach (var thing in _inventory)
        {
            Console.WriteLine($" - (#{thing.Number}) {thing.Name}");
        }
    }
    
    public List<Animal> GetAnimals() => _animals; // Для тестов.
    public List<Thing> GetInventory() => _inventory; // Для тестов.
    
    /// <summary>
    /// Для тестов.
    /// </summary>
    /// <returns></returns>
    public string GenerateReport()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);
        Report();
        return sw.ToString();
    }
}