namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            string color = string.Empty;


            for (int i = 0; i < n; i++)
            {
                string[] input = Console
                                .ReadLine()
                                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                color = input[0];

                string[] clothesCollection = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothesCollection.Length; j++)
                {

                    if (!wardrobe[color].ContainsKey(clothesCollection[j]))
                    {
                        wardrobe[color].Add(clothesCollection[j], 0);
                    }  

                    wardrobe[color][clothesCollection[j]]++;
                }
            }

            string[] wantedClothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            color = wantedClothes[0];
            string clothes = wantedClothes[1];

            foreach (KeyValuePair<string, Dictionary<string, int>> clothesColor in wardrobe)
            {
                Console.WriteLine($"{clothesColor.Key} clothes:");

                foreach (KeyValuePair<string, int> clothesFromWardrobe in clothesColor.Value)
                {
                    if (clothesColor.Key == color && clothesFromWardrobe.Key == clothes)
                    {   
                        Console.WriteLine($"* {clothesFromWardrobe.Key} - {clothesFromWardrobe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothesFromWardrobe.Key} - {clothesFromWardrobe.Value}");
                    }
                }
            }
        }
    }
}
