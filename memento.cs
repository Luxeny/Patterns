// Паттерн Memento (Снимок)

// Тип: Поведенческий паттерн

// Описание: Позволяет сохранять и восстанавливать внутреннее состояние объекта, не раскрывая его структуру.

// Назначение: Реализация механизма отмены операций (undo/redo), истории изменений объекта, транзакций.

// Метафоры из реального мира:
// - Сохранение игры (сохраняется состояние игры, чтобы можно было загрузить позже)
// - Резервная копия документа (позволяет вернуться к предыдущей версии)
// - Снимок виртуальной машины

// 1. Класс Memento (Снимок) - хранит состояние объекта
public class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

// 2. Класс Originator (Создатель) - объект, состояние которого нужно сохранять
public class Originator
{
    public string State { get; set; }

    public Memento CreateMemento()
    {
        Console.WriteLine("Saving to Memento: " + State);
        return new Memento(State);
    }

    public void RestoreMemento(Memento memento)
    {
        State = memento.State;
        Console.WriteLine("Originator state after restoring from Memento: " + State);
    }
}

// 3. Класс Caretaker (Хранитель) - хранит Memento
public class Caretaker
{
    private List<Memento> mementos = new List<Memento>();

    public void AddMemento(Memento m)
    {
        mementos.Add(m);
    }

    public Memento GetMemento(int index)
    {
        return mementos[index];
    }
}

// Пример использования:
// Originator originator = new Originator { State = "State #1" };
// Caretaker caretaker = new Caretaker();
// caretaker.AddMemento(originator.CreateMemento()); // Сохраняем состояние 1
// originator.State = "State #2";
// caretaker.AddMemento(originator.CreateMemento()); // Сохраняем состояние 2
// originator.State = "State #3";
// Console.WriteLine("Current State: " + originator.State); // Current State: State #3
// originator.RestoreMemento(caretaker.GetMemento(1)); // Восстанавливаем состояние 2
// Console.WriteLine("Current State: " + originator.State); // Current State: State #2
// originator.RestoreMemento(caretaker.GetMemento(0)); // Восстанавливаем состояние 1
// Console.WriteLine("Current State: " + originator.State); // Current State: State #1

// Потенциальные проблемы:
// - Разглашение информации: Если Memento хранит конфиденциальную информацию, необходимо обеспечить ее защиту.
// - Большой объем памяти: Хранение большого количества Memento может привести к увеличению потребления памяти.
// - Сложность реализации: Реализация Memento может быть сложной, особенно для объектов со сложной структурой.
// - Утечка ресурсов: Необходимо следить за освобождением ресурсов, связанных с Memento.
