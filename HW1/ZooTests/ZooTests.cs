using HW1;

namespace ZooTests;

using Xunit;
using Moq;

public class ZooTests
{
    /// <summary>
    /// Тест на добавление здоровых животных.
    /// </summary>
    [Fact]
    public void AddAnimal_WhenHealthy_ShouldAddAnimal()
    {
        // Arrange
        var vetMock = new Mock<VetClinik>();
        vetMock.Setup(v => v.CheckHealth(It.IsAny<Animal>())).Returns(true);
        var zoo = new Zoo(vetMock.Object);
        var monkey = new Monkey(1, 5, 7);

        // Act
        zoo.AddAnimal(monkey);

        // Assert
        Assert.Contains(monkey, zoo.GetAnimals());
    }
    
    /// <summary>
    /// Тест на непрохождение больных животных.
    /// </summary>
    [Fact]
    public void AddAnimal_WhenUnhealthy_ShouldNotAddAnimal()
    {
        // Arrange
        var vetMock = new Mock<VetClinik>();
        vetMock.Setup(v => v.CheckHealth(It.IsAny<Animal>())).Returns(false);
        var zoo = new Zoo(vetMock.Object);
        var tiger = new Tiger(2, 10);

        // Act
        zoo.AddAnimal(tiger);

        // Assert
        Assert.DoesNotContain(tiger, zoo.GetAnimals());
    }
    
    /// <summary>
    /// Тест на добавление вещей в инвентарь.
    /// </summary>
    [Fact]
    public void AddThing_ShouldAddToInventory()
    {
        // Arrange
        var zoo = new Zoo(new VetClinik());
        var table = new Table(3);

        // Act
        zoo.AddThing(table);

        // Assert
        Assert.Contains(table, zoo.GetInventory());
    }
    
    /// <summary>
    /// Тест на отчет.
    /// </summary>
    [Fact]
    public void ShowReport_ShouldPrintCorrectValues()
    {
        // Arrange
        var vetMock = new Mock<VetClinik>();
        vetMock.Setup(v => v.CheckHealth(It.IsAny<Animal>())).Returns(true);
        var zoo = new Zoo(vetMock.Object);
        var monkey = new Monkey(1, 5, 7);
        var tiger = new Tiger(2, 10);
        zoo.AddAnimal(monkey);
        zoo.AddAnimal(tiger);
        zoo.AddThing(new Table(3));

        // Act
        var report = zoo.GenerateReport();

        // Assert
        Assert.Contains("Всего животных: 2", report);
        Assert.Contains("Общее потребление еды: 15", report);
        Assert.Contains("Животные в контактном зоопарке:\n - (#1) Monkey", report);
        Assert.Contains("Инвентарь зоопарка:\n - (#3) Table", report);
    }
}