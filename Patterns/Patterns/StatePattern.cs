namespace Patterns
{
    public interface ICoffeeMachineState
    {
        void InsertCoin(CoffeeMachine machine);
        void SelectDrink(CoffeeMachine machine, string drink);
        void DispenseDrink(CoffeeMachine machine);
        void Reset(CoffeeMachine machine);
    }
    public class WaitingForCoinState : ICoffeeMachineState
    {
        public void InsertCoin(CoffeeMachine machine)
        {
            Console.WriteLine("Монета принята, выберите напиток:");
            machine.SetState(new DrinkSelectionState());
        }

        public void SelectDrink(CoffeeMachine machine, string drink) => Console.WriteLine("Пожалуйста, сначала внесите монету.");

        public void DispenseDrink(CoffeeMachine machine) => Console.WriteLine("Пожалуйста, сначала внесите монету и выберите напиток.");

        public void Reset(CoffeeMachine machine) => Console.WriteLine("Автомат уже в состоянии ожидания.");
    }

    public class DrinkSelectionState : ICoffeeMachineState
    {
        public void InsertCoin(CoffeeMachine machine) => Console.WriteLine("Монета уже внесена, выберите напиток:");

        public void SelectDrink(CoffeeMachine machine, string drink)
        {
            Console.WriteLine($"Выбран напиток: {drink}");
            machine.SelectedDrink = drink;
            machine.SetState(new DispensingState());
        }

        public void DispenseDrink(CoffeeMachine machine) => Console.WriteLine("Пожалуйста, сначала выберите напиток:");

        public void Reset(CoffeeMachine machine)
        {
            Console.WriteLine("Отмена. Возврат монеты.");
            machine.SetState(new WaitingForCoinState());
        }
    }

    public class DispensingState : ICoffeeMachineState
    {
        public void InsertCoin(CoffeeMachine machine) => Console.WriteLine("Подождите, выдача напитка уже началась.");

        public void SelectDrink(CoffeeMachine machine, string drink) => Console.WriteLine("Подождите, выдача напитка уже началась.");

        public void DispenseDrink(CoffeeMachine machine)
        {
            Console.WriteLine($"Выдаём напиток: {machine.SelectedDrink}");
            Console.WriteLine("Напиток выдан. Автомат готов к следующему клиенту.");
            machine.SetState(new ReadyState());
        }

        public void Reset(CoffeeMachine machine) => Console.WriteLine("Невозможно отменить во время выдачи напитка.");
    }

    public class ReadyState : ICoffeeMachineState
    {
        public void InsertCoin(CoffeeMachine machine)
        {
            Console.WriteLine("Автомат готов к работе. Пожалуйста, внесите монету.");
            machine.SetState(new WaitingForCoinState());
        }

        public void SelectDrink(CoffeeMachine machine, string drink) => Console.WriteLine("Пожалуйста, сначала внесите монету.");

        public void DispenseDrink(CoffeeMachine machine) => Console.WriteLine("Пожалуйста, сначала внесите монету и выберите напиток.");

        public void Reset(CoffeeMachine machine) => Console.WriteLine("Автомат уже готов к работе.");
    }

    public class CoffeeMachine
    {
        private ICoffeeMachineState _currentState;
        public string SelectedDrink { get; set; }

        public CoffeeMachine() => _currentState = new ReadyState();

        public void SetState(ICoffeeMachineState state) => _currentState = state;

        public void InsertCoin() => _currentState.InsertCoin(this);

        public void SelectDrink(string drink) => _currentState.SelectDrink(this, drink);

        public void DispenseDrink() => _currentState.DispenseDrink(this);

        public void Reset() => _currentState.Reset(this);
    }
}
