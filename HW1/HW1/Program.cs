using Microsoft.Extensions.DependencyInjection;

namespace HW1
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<VetClinik>();
            services.AddSingleton<Zoo>();
            
            var provider = services.BuildServiceProvider();
            var zoo = provider.GetRequiredService<Zoo>();
            
            zoo.AddAnimal(new Monkey(1, 4, 7));
            zoo.AddAnimal(new Rabbit(2, 2, 9));
            zoo.AddAnimal(new Tiger(3, 9));
            zoo.AddAnimal(new Wolf(4, 8));
            zoo.AddAnimal(new Monkey(5, 3, 8));
            zoo.AddAnimal(new Tiger(6, 10));
            zoo.AddAnimal(new Rabbit(7, 3, 8));
            
            zoo.AddThing(new Table(8));
            zoo.AddThing(new Computer(9));

            zoo.Report();
        }
    }   
}