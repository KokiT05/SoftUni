namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> chemicalElementsSet = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] inputChemicalElements = Console.ReadLine().Split();

                for (int element = 0; element < inputChemicalElements.Length; element++)
                {
                    chemicalElementsSet.Add(inputChemicalElements[element]);
                }
            }

            Console.WriteLine(string.Join(' ', chemicalElementsSet));
        }
    }
}
