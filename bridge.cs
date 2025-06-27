// Паттерн Bridge (Мост)

// Тип: Структурный

// Описание: Разделяет абстракцию и реализацию.

// Назначение: Независимое изменение абстракции и реализации.

// Метафора: Автомобиль и двигатель.

// 1. Implementor (Реализация) - определяет интерфейс для конкретных реализаций.
interface IDevice { void Enable(); }

// 2. Concrete Implementor - конкретная реализация, например, телевизор.
class TV : IDevice { public void Enable() { Console.WriteLine("TV Enabled"); } }

// 3. Abstraction - определяет абстрактный интерфейс, использует Implementor.
abstract class RemoteControl
{
    protected IDevice device;
    public RemoteControl(IDevice device) { this.device = device; }
    public abstract void TogglePower();
}

// 4. Refined Abstraction - расширяет интерфейс Abstraction.
class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device) { }
    public override void TogglePower() { device.Enable(); }
}

// Использование:
// IDevice tv = new TV();  // Создаем конкретную реализацию
// RemoteControl remote = new AdvancedRemote(tv); // Создаем абстракцию, привязанную к реализации
// remote.TogglePower(); // Вызываем метод абстракции, который использует реализацию
