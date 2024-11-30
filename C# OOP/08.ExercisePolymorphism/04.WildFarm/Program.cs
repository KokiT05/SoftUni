using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Mammals;
using _04.WildFarm.Animals.Mammals.Felines;
using _04.WildFarm.Foods;

namespace _04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalInput = Console.ReadLine();
                if (animalInput == "End")
                {
                    break;
                }

                string[] animalInformation = animalInput.Split();
                Animal animal = CreateAnimal(animalInformation);
                animals.Add(animal);

                string[] foodInformation = Console.ReadLine().Split();
                Food food = CreateFood(foodInformation);

                Console.WriteLine(animal.Sound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException exceptionMessage)
                {
                    Console.WriteLine(exceptionMessage.Message);
                }
            }

            foreach (Animal currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }

        }

        private static Food CreateFood(string[] foodInformation)
        {
            Food food = null;
            string foodType = foodInformation[0];
            int foodQuantity = int.Parse(foodInformation[1]);

            if (foodType == nameof(Fruit))
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == nameof(Meat))
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(foodQuantity);
            }

            return food;
        }

        public static Animal CreateAnimal(string[] animalInformation)
        {
            Animal animal = null;
            string animalType = animalInformation[0];
            string animalName = animalInformation[1];
            double animalWeight = double.Parse(animalInformation[2]);

            if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(animalInformation[3]);
                animal = new Owl(animalName, animalWeight, wingSize);
            }
            else if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(animalInformation[3]);
                animal = new Hen(animalName, animalWeight, wingSize);
            }
            else if (animalType == nameof(Dog))
            {
                string livingRegion = animalInformation[3];
                animal = new Dog(animalName, animalWeight, livingRegion);
            }
            else if (animalType == nameof(Mouse))
            {
                string livingRegion = animalInformation[3];
                animal = new Mouse(animalName, animalWeight, livingRegion);
            }
            else if (animalType == nameof(Cat))
            {
                string livingRegion = animalInformation[3];
                string breed = animalInformation[4];
                animal = new Cat(animalName, animalWeight, livingRegion, breed);
            }
            else if (animalType == nameof(Tiger))
            {
                string livingRegion = animalInformation[3];
                string breed = animalInformation[4];
                animal = new Tiger(animalName, animalWeight, livingRegion, breed);
            }

            return animal;
        }
    }
}
