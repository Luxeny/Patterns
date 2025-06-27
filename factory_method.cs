// Паттерн Factory Method (Фабричный метод)

// Тип: Порождающий

// Описание: Определяет интерфейс для создания объекта, но оставляет решение о том, какой класс инстанцировать, подклассам.

// Назначение: Делегирование ответственности за создание объектов подклассам.

// Метафора: Создание документов разных форматов (Word, PDF, Excel) в приложении.

// 1. Интерфейс продукта
interface IProduct { string Operation(); }

// 2. Конкретные продукты
class ConcreteProductA : IProduct { public string Operation() { return "Product A"; } }
class ConcreteProductB : IProduct { public string Operation() { return "Product B"; } }

// 3. Интерфейс создателя (фабрики)
interface ICreator
{
    IProduct FactoryMethod(); // Фабричный метод
}

// 4. Конкретные создатели
class ConcreteCreatorA : ICreator
{
    public IProduct FactoryMethod() { return new ConcreteProductA(); }
}

class ConcreteCreatorB : ICreator
{
    public IProduct FactoryMethod() { return new ConcreteProductB(); }
}

// Использование:
// ICreator creatorA = new ConcreteCreatorA();
// IProduct productA = creatorA.FactoryMethod();
// Console.WriteLine(productA.Operation()); // Product A

// ICreator creatorB = new ConcreteCreatorB();
// IProduct productB = creatorB.FactoryMethod();
// Console.WriteLine(productB.Operation()); // Product B
