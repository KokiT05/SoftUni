using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Animal animal = null;

            string animalType = Console.ReadLine().ToLower().TrimEnd();
            while (animalType != "beast!")
            {
                string[] animalInformation = Console.ReadLine().Split(' ');
                string animalName = animalInformation[0];
                int animalAge = int.Parse(animalInformation[1]);
                string animalGender = animalInformation[2];

                if (animalType == "dog")
                {
                    animal = new Dog(animalName, animalAge, animalGender);
                }
                else if (animalType == "frog")
                {
                    animal = new Frog(animalName, animalAge, animalGender);
                }
                else if (animalType == "cat")
                {
                    animal = new Cat(animalName, animalAge, animalGender);
                }
                else if (animalType == "kitten")
                {
                    animal = new Kitten(animalName, animalAge, animalGender);
                }
                else if (animalType == "tomcat")
                {
                    animal = new Tomcat(animalName, animalAge, animalGender);
                }

                animals.Add(animal);
                animalType = Console.ReadLine().ToLower().TrimEnd();
            }

            foreach (Animal currentAnimal in animals)
            {
                Console.WriteLine($"{currentAnimal.GetType().Name}");
                Console.
                WriteLine
                ($"{currentAnimal.Name} {currentAnimal.Age} {currentAnimal.Gender}");
                currentAnimal.ProduceSound();
            }
        }
    }
}
