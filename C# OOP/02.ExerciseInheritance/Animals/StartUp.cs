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

                if (string.IsNullOrEmpty(animalName) || 
                    animalAge < 0 || 
                    string.IsNullOrEmpty(animalGender))
                {
                    Console.WriteLine($"Invalid input!");
                }
                else
                {
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
                        animal = new Kitten(animalName, animalAge);
                    }
                    else if (animalType == "tomcat")
                    {
                        animal = new Tomcat(animalName, animalAge);
                    }

                    animals.Add(animal);
                }
                animalType = Console.ReadLine().ToLower().TrimEnd();
            }

            foreach (Animal currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal);
                Console.WriteLine(currentAnimal.ProduceSound());
            }
        }
    }
}
