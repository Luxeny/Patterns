// Паттерн Abstract Factory (Абстрактная фабрика)

// Тип: Порождающий

// Описание: Предоставляет интерфейс для создания семейств связанных или зависимых объектов, не специфицируя их конкретные классы.

// Назначение: Когда нужно создавать семейства объектов, которые должны использоваться вместе.

// Метафора: Производство мебели разных стилей (модерн, классика) - каждая фабрика производит стулья, столы, диваны в определенном стиле.

// 1. Абстрактная фабрика
interface IAbstractFactory
{
    IAbstractProductA CreateProductA();
    IAbstractProductB CreateProductB();
}

// 2. Конкретные фабрики
class ConcreteFactory1 : IAbstractFactory
{
    public IAbstractProductA CreateProductA() { return new ConcreteProductA1(); }
    public IAbstractProductB CreateProductB() { return new ConcreteProductB1(); }
}

class ConcreteFactory2 : IAbstractFactory
{
    public IAbstractProductA CreateProductA() { return new ConcreteProductA2(); }
    public IAbstractProductB CreateProductB() { return new ConcreteProductB2(); }
}

// 3. Абстрактные продукты
interface IAbstractProductA { string UsefulFunctionA(); }
interface IAbstractProductB { string UsefulFunctionB(); }

// 4. Конкретные продукты
class ConcreteProductA1 : IAbstractProductA { public string UsefulFunctionA() { return "Product A1"; } }
class ConcreteProductB1 : IAbstractProductB { public string UsefulFunctionB() { return "Product B1"; } }
class ConcreteProductA2 : IAbstractProductA { public string UsefulFunctionA() { return "Product A2"; } }
class ConcreteProductB2 : IAbstractProductB { public string UsefulFunctionB() { return "Product B2"; } }

// Использование:
// IAbstractFactory factory1 = new ConcreteFactory1();
// IAbstractProductA productA1 = factory1.CreateProductA();
// Console.WriteLine(productA1.UsefulFunctionA()); // Product A1

// IAbstractFactory factory2 = new ConcreteFactory2();
// IAbstractProductB productB2 = factory2.CreateProductB();
// Console.WriteLine(productB2.UsefulFunctionB()); // Product B2
