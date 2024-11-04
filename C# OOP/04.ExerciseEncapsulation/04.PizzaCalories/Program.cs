namespace _04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInputData = Console.ReadLine().Split();
            Pizza pizza = new Pizza(pizzaInputData[1]);

            string[] doughInputData = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dough dough = new Dough
                            (doughInputData[1].ToLower(),
                            doughInputData[2].ToLower(),
                            double.Parse(doughInputData[3]));

            pizza.Dough = dough;

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] toppingInputData = input
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Topping topping = new Topping
                                    (toppingInputData[1].ToLower(),
                                    double.Parse(toppingInputData[2]));

                pizza.AddTopping(topping);

                input = Console.ReadLine();
            }
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories");
        }
    }
}
