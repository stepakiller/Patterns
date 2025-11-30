using Patterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Prototype Pattern ===");
        TestPrototypePattern();

        Console.WriteLine("\n=== State Pattern ===");
        TestStatePattern();

        Console.WriteLine("\n=== Mediator Pattern ===");
        TestMediatorPattern();

        Console.WriteLine("\n=== Decorator Pattern ===");
        TestDecoratorPattern();

        Console.WriteLine("\n=== Proxy Pattern ===");
        TestProxyPattern();

        Console.ReadLine();
    }

    static void TestPrototypePattern()
    {
        var originalSphere = new Sphere(0, 0, 0, "Red", 5.0f);
        var originalCube = new Cube(10, 10, 10, "Blue", 3.0f);

        Console.WriteLine("Оригинальные объекты:");
        originalSphere.DisplayInfo();
        originalCube.DisplayInfo();

        var clonedSphere = (Sphere)originalSphere.Clone();
        var clonedCube = (Cube)originalCube.Clone();

        clonedSphere.SetPosition(5, 5, 5);
        clonedSphere.Color = "Green";

        clonedCube.SetPosition(20, 20, 20);
        clonedCube.Size = 6.0f;

        Console.WriteLine("\nПосле клонирования и изменения:");
        Console.WriteLine("Ориг:");
        originalSphere.DisplayInfo();
        originalCube.DisplayInfo();

        Console.WriteLine("Клоны:");
        clonedSphere.DisplayInfo();
        clonedCube.DisplayInfo();
    }

    static void TestStatePattern()
    {
        var coffeeMachine = new CoffeeMachine();

        Console.WriteLine("Сценарий работы кофейного автомата:");

        coffeeMachine.InsertCoin();
        coffeeMachine.SelectDrink("Капучино");
        coffeeMachine.DispenseDrink();
        coffeeMachine.InsertCoin();
    }

    static void TestMediatorPattern()
    {
        var chatRoom = new ChatRoom();

        var user1 = new ChatUser("Никита", chatRoom);
        var user2 = new ChatUser("Степа", chatRoom);
        var user3 = new ChatUser("Витя", chatRoom);

        Console.WriteLine("\nОбщение в чате:");
        user1.Send("Привет, ребята!");
        user2.Send("Привет, друзья!");
        user3.Send("Привет, одногруппники!");
    }

    static void TestDecoratorPattern()
    {
        IOrder order = new BaseOrder();
        Console.WriteLine($"Обычный заказ: {order.GetDescription()} - {order.GetPrice()} руб.");

        order = new ExpressDeliveryDecorator(order);
        order = new GiftWrapDecorator(order);
        order = new DrinksDecorator(order);

        Console.WriteLine($"Заказ с доп услугами: {order.GetDescription()} - {order.GetPrice()} руб.");
    }

    static void TestProxyPattern()
    {
        var proxy = new ProxyService();

        var result1 = proxy.GetData();
        Console.WriteLine($"Результат: {result1}");

        var result2 = proxy.GetData();
        Console.WriteLine($"Результат: {result2}");

        Console.WriteLine("\nОжидание 5 секунд...");
        Thread.Sleep(5000);

        var result3 = proxy.GetData();
        Console.WriteLine($"Результат: {result3}");
    }
}