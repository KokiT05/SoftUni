namespace _01.Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich
                                        ("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
            sandwichMenu["ThreeMeatCombo"] = new Sandwich
                                    ("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            sandwichMenu["Vegetarian"] = new Sandwich
                                    ("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spanach");

            Sandwich firstSandwich = sandwichMenu["BLT"].Clone() as Sandwich;
            Sandwich secondSandwich = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich thirdSandwich = sandwichMenu["Vegetarian"].Clone() as Sandwich;
        }
    }
}
