// Паттерн Visitor (Посетитель)

// Тип: Поведенческий

// Описание: Добавляет операции к классам без изменения их структуры.

// Назначение: Разные операции над разными типами объектов.

// Метафора: Турист в разных местах.

// 1. Visitor Interface
interface IVisitor { void Visit(ElementA element); void Visit(ElementB element); }

// 2. Concrete Visitors
class Visitor1 : IVisitor { public void Visit(ElementA a) { Console.WriteLine("V1 visits A"); } public void Visit(ElementB b) { Console.WriteLine("V1 visits B"); } }

// 3. Element Interface
interface IElement { void Accept(IVisitor visitor); }

// 4. Concrete Elements
class ElementA : IElement { public void Accept(IVisitor visitor) { visitor.Visit(this); } }
class ElementB : IElement { public void Accept(IVisitor visitor) { visitor.Visit(this); } }

// Использование:
// IElement a = new ElementA();
// IVisitor v1 = new Visitor1();
// a.Accept(v1);
