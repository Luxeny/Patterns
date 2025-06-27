// Паттерн Chain of Responsibility (Цепочка Обязанностей)

// Тип: Поведенческий

// Описание: Позволяет передавать запрос по цепочке обработчиков.

// Назначение: Избежать жесткой связи между отправителем и получателем.

// Метафора: Служба поддержки.

// 1. Абстрактный обработчик - определяет интерфейс для обработчиков
abstract class Handler
{
    protected Handler successor; // Следующий обработчик в цепочке
    public void SetSuccessor(Handler successor) { this.successor = successor; }
    public abstract void HandleRequest(int request); // Абстрактный метод обработки запроса
}

// 2. Конкретные обработчики - реализуют логику обработки запроса
class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        // Если запрос подходит для этого обработчика, обрабатываем его
        if (request >= 0 && request < 10)
        {
            Console.WriteLine($"{this.GetType().Name} обработал запрос {request}");
        }
        // Иначе передаем запрос следующему обработчику в цепочке
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine($"{this.GetType().Name} обработал запрос {request}");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

// Использование:
// Handler h1 = new ConcreteHandler1(); // Создаем обработчики
// Handler h2 = new ConcreteHandler2();
// h1.SetSuccessor(h2); // Создаем цепочку: h1 -> h2

// h1.HandleRequest(5);  // Отправляем запрос, который обработает h1
// h1.HandleRequest(15); // Отправляем запрос, который обработает h2
// h1.HandleRequest(25); // Отправляем запрос, который никто не обработает
