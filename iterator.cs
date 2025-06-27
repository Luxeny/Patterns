// Паттерн Iterator (Итератор)

// Тип: Поведенческий паттерн

// Описание: Предоставляет способ последовательного доступа к элементам объекта-контейнера, не раскрывая его внутреннее представление.

// Назначение: Облегчает обход элементов коллекции, скрывая детали реализации коллекции.

// Метафоры из реального мира:
// - CD-проигрыватель (позволяет последовательно воспроизводить треки на CD, не раскрывая формат CD)
// - Пульт дистанционного управления телевизором (позволяет переключать каналы, не зная, как они хранятся)
// - Курсор в базе данных (позволяет последовательно получать записи из таблицы)

// 1. Интерфейс Iterator
public interface IIterator
{
    bool HasNext();
    object Next();
}

// 2. Интерфейс Aggregate (Контейнер)
public interface IAggregate
{
    IIterator CreateIterator();
}

// 3. Конкретный Iterator
public class ConcreteIterator : IIterator
{
    private ConcreteAggregate aggregate;
    private int current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }

    public bool HasNext()
    {
        return current < aggregate.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            return aggregate.GetItem(current++);
        }
        return null;
    }
}

// 4. Конкретный Aggregate (Контейнер)
public class ConcreteAggregate : IAggregate
{
    private List<object> items = new List<object>();

    public int Count
    {
        get { return items.Count; }
    }

    public void AddItem(object item)
    {
        items.Add(item);
    }

    public object GetItem(int index)
    {
        return items[index];
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
}

// Пример использования:
// ConcreteAggregate aggregate = new ConcreteAggregate();
// aggregate.AddItem("Item A");
// aggregate.AddItem("Item B");
// aggregate.AddItem("Item C");

// IIterator iterator = aggregate.CreateIterator();
// while (iterator.HasNext())
// {
//     object item = iterator.Next();
//     Console.WriteLine(item); // Выведет Item A, Item B, Item C
// }

// Потенциальные проблемы:
// - Сложность реализации: Для сложных коллекций реализация итератора может быть достаточно сложной.
// - Невозможность изменения коллекции во время итерации:  Изменение коллекции во время итерации может привести к непредсказуемым результатам или исключениям.
// - Накладные расходы: Создание и использование итератора может создавать небольшие накладные расходы по сравнению с прямым доступом к элементам коллекции.
// - Внутреннее состояние: Итератор хранит внутреннее состояние (например, текущий индекс), что может усложнить его использование в многопоточной среде.
