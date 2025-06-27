// Паттерн Strategy (Стратегия)

// Тип: Поведенческий

// Описание: Определяет семейство алгоритмов, инкапсулирует каждый из них и делает их взаимозаменяемыми.

// Назначение: Позволяет выбирать алгоритм во время выполнения.

// Метафора: Разные способы оплаты (кредитной картой, PayPal, наличными).

// 1. Интерфейс стратегии
interface IStrategy
{
    int Execute(int a, int b); // Выполнение алгоритма
}

// 2. Конкретные стратегии
class ConcreteStrategyAdd : IStrategy
{
    public int Execute(int a, int b)
    {
        Console.WriteLine("Вызвана стратегия сложения");
        return a + b;
    }
}

class ConcreteStrategySubtract : IStrategy
{
    public int Execute(int a, int b)
    {
        Console.WriteLine("Вызвана стратегия вычитания");
        return a - b;
    }
}

// 3. Контекст (класс, использующий стратегию)
class Context
{
    private IStrategy strategy; // Ссылка на стратегию

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy; // Смена стратегии во время выполнения
    }

    public int ExecuteStrategy(int a, int b)
    {
        return strategy.Execute(a, b); // Выполнение стратегии
    }
}

// Использование:
// Context context = new Context(new ConcreteStrategyAdd()); // Изначально стратегия - сложение
// int result = context.ExecuteStrategy(5, 3); // 8 (Вызвана стратегия сложения)

// context.SetStrategy(new ConcreteStrategySubtract()); // Меняем стратегию на вычитание
// result = context.ExecuteStrategy(5, 3); // 2 (Вызвана стратегия вычитания)
