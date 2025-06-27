// Паттерн Builder (Строитель)

// Тип: Порождающий паттерн

// Описание: Позволяет создавать сложные объекты шаг за шагом. Отделяет процесс конструирования объекта от его представления.

// Назначение: Когда создание объекта включает в себя множество этапов или различных конфигураций.

// Метафоры из реального мира:
// - Строительство дома (сначала фундамент, потом стены, потом крыша и т.д.)
// - Сборка автомобиля (сначала двигатель, потом кузов, потом колеса и т.д.)
// - Создание сложного документа (сначала заголовок, потом текст, потом таблицы и т.д.)

// 1. Продукт (объект, который нужно построить)
public class Computer
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Storage { get; set; }
    public string GraphicsCard { get; set; }

    public void DisplayConfiguration()
    {
        Console.WriteLine("Computer Configuration:");
        Console.WriteLine($"CPU: {CPU}");
        Console.WriteLine($"RAM: {RAM}");
        Console.WriteLine($"Storage: {Storage}");
        Console.WriteLine($"Graphics Card: {GraphicsCard}");
    }
}

// 2. Интерфейс Builder
public interface IComputerBuilder
{
    void BuildCPU();
    void BuildRAM();
    void BuildStorage();
    void BuildGraphicsCard();
    Computer GetComputer();
}

// 3. Конкретный Builder
public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildCPU()
    {
        computer.CPU = "Intel Core i9";
    }

    public void BuildRAM()
    {
        computer.RAM = "32GB DDR5";
    }

    public void BuildStorage()
    {
        computer.Storage = "2TB NVMe SSD";
    }

    public void BuildGraphicsCard()
    {
        computer.GraphicsCard = "Nvidia GeForce RTX 4090";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}

// 4. Director (управляет процессом построения)
public class ComputerAssembler
{
    private IComputerBuilder builder;

    public ComputerAssembler(IComputerBuilder builder)
    {
        this.builder = builder;
    }

    public void AssembleComputer()
    {
        builder.BuildCPU();
        builder.BuildRAM();
        builder.BuildStorage();
        builder.BuildGraphicsCard();
    }

    public Computer GetComputer()
    {
        return builder.GetComputer();
    }
}

// Пример использования:
// GamingComputerBuilder gamingBuilder = new GamingComputerBuilder();
// ComputerAssembler assembler = new ComputerAssembler(gamingBuilder);
// assembler.AssembleComputer();
// Computer gamingComputer = assembler.GetComputer();
// gamingComputer.DisplayConfiguration();

// Потенциальные проблемы:
// - Усложнение кода: Введение дополнительных классов (Builder, Director) может усложнить код, особенно для простых объектов.
// - Жесткая связь: Director может быть жестко связан с конкретными Builder-ами, что затрудняет добавление новых Builder-ов.
// - Изменения в продукте: При изменении структуры продукта (Computer) может потребоваться изменение всех Builder-ов.
// - Большое количество классов: Для каждого варианта сборки может потребоваться свой Builder, что приводит к увеличению количества классов.
