int n = int.Parse(Console.ReadLine()!);

Queue<int[]> petrolDistances = new Queue<int[]>();
int petrol = 0;
int distance = 0;
for (int i = 1; i <= n; i++)
{
    int[] input = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
    petrol = input[0];
    distance = input[1];

    petrolDistances.Enqueue(new int[] {petrol, distance});
}

bool isSuccessfully = true;
int sumOfPetrol = 0;
int sumOfDistance = 0;

for (int i = 0;i < n; i++)
{
    for (int j = 1; j <= n; j++)
    {
        int[] currentElement = petrolDistances.Dequeue();
        petrolDistances.Enqueue(currentElement);

        petrol = currentElement[0];
        distance = currentElement[1];

        sumOfPetrol += petrol;
        sumOfDistance += distance;

        if (sumOfPetrol < sumOfDistance)
        {
            isSuccessfully = false;
        }

    }

    if (isSuccessfully)
    {
        Console.WriteLine(i);
        break;
    }

    sumOfDistance = 0;
    sumOfPetrol = 0;
    isSuccessfully = true;
    petrolDistances.Enqueue(petrolDistances.Dequeue());
}