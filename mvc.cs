// Паттерн MVC (Model-View-Controller)

// Описание: Разделяет приложение на три взаимосвязанные части: модель, представление и контроллер.

// Назначение: Разделение ответственности, упрощение тестирования и разработки.

// Модель (Model) - представляет данные приложения и бизнес-логику
public class Model
{
    public string Data { get; set; }
}

// Представление (View) - отображает данные пользователю
public class View
{
    public void Display(string data)
    {
        Console.WriteLine("View: " + data);
    }
}

// Контроллер (Controller) - обрабатывает действия пользователя и обновляет модель и представление
public class Controller
{
    private Model model;
    private View view;

    public Controller(Model model, View view)
    {
        this.model = model;
        this.view = view;
    }

    public void SetData(string data)
    {
        model.Data = data;
        UpdateView();
    }

    private void UpdateView()
    {
        view.Display(model.Data);
    }
}

// Использование:
// Model model = new Model();
// View view = new View();
// Controller controller = new Controller(model, view);

// controller.SetData("Hello MVC!"); // Обновляет модель и отображает данные через представление
