namespace _04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal animal = null;
            Food food = null;
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string[] animalInformation = Console.ReadLine().Split();

                if (animalInformation[0] == "End")
                {
                    break;
                }
                string animalType = animalInformation[0];
                string animalName = animalInformation[1];
                double weight = double.Parse(animalInformation[2]);


                string[] foodInformation = Console.ReadLine().Split();
                string foodType = foodInformation[0];
                int foodQuantity = int.Parse(foodInformation[1]);

                if (animalType == nameof(Owl) || animalType == nameof(Hen))
                {
                    double wingSize = double.Parse(animalInformation[2]);

                    if (animalType == nameof(Owl))
                    {
                        animal = new Owl(animalName, weight, foodQuantity, wingSize);
                    }
                    else if (animalType == nameof(Hen))
                    {
                        animal = new Hen(animalName, weight, foodQuantity, wingSize);
                    }
                    animals.Add(animal);
                   // animal.AddFoodEaten(foodQuantity);
                    AnimalFunctionality(animal, foodType);
                    continue;
                }

                string livingRegion = animalInformation[3];

                if (animalType == nameof(Mouse) || animalType ==  nameof(Dog))
                {
                    if (animalType == nameof(Mouse))
                    {
                        animal = new Mouse(animalName, weight, foodQuantity, livingRegion);
                    }
                    else if (animalType == nameof(Dog))
                    {
                        animal = new Dog(animalName, weight, foodQuantity, livingRegion);
                    }
                    animals.Add(animal);
                   // animal.AddFoodEaten(foodQuantity);
                    AnimalFunctionality(animal, foodType);
                    continue;
                }

                string breed = animalInformation[4];
                if (animalType == nameof(Cat))
                {
                    animal = new Cat(animalName, weight, foodQuantity, livingRegion, breed);
                }
                else if (animalType == nameof(Tiger))
                {
                    animal = new Tiger(animalName, weight, foodQuantity, livingRegion, breed);
                }

                animals.Add(animal);
                //animal.AddFoodEaten(foodQuantity);
                AnimalFunctionality(animal, foodType);
            }

            foreach (Animal currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
            }
        }

        public static void CanEat(Animal animal, string foodName)
        {
            if (animal.Foods.Contains(foodName))
            {
                Console.WriteLine(animal.Sound());
            }
            else
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {foodName}!");
            }


        }

        public static void AddWeight(Animal animal)
        {
            double weight = 0;

            if (animal.GetType().Name == nameof(Hen))
            {
                weight = GlobalConstants.HenAddWeight;
            }
            else if (animal.GetType().Name == nameof(Owl))
            {
                weight = GlobalConstants.OwlAddWeight;
            }
            else if (animal.GetType().Name == nameof(Cat))
            {
                weight = GlobalConstants.CatAddWeight;
            }
            else if (animal.GetType().Name == nameof(Tiger))
            {
                weight = GlobalConstants.TigerAddWeight;
            }
            else if (animal.GetType().Name == nameof(Dog))
            {
                weight = GlobalConstants.DogAddWeight;
            }
            else if (animal.GetType().Name == nameof(Mouse))
            {
                weight = GlobalConstants.MouseAddWeight;
            }
            weight = weight * animal.FoodEaten;
            animal.AddWeight(weight);
        }

        public static void AnimalFunctionality(Animal animal, string foodName)
        {
            CanEat(animal, foodName);
            AddWeight(animal);
        }
    }
}
