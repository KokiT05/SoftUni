namespace _07.SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] universe = new int[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            int[][] sets = new int[][]
            {
                new int[] { 20 },
                new int[] { 1, 5, 20, 30 },
                new int[] { 3, 7, 20, 30, 40 },
                new int[] { 9, 30 },
                new int[] { 11, 20, 30, 40 },
                new int[] { 3, 7, 40 },
            };

            List<int[]> selectSets = GreedySetCover(universe.ToList(), sets.ToList());
            Console.WriteLine($"Sets to take: ({selectSets.Count})");
            foreach (int[] set in selectSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> MyMethodSetCover(List<int> universe, List<int[]> sets)
        {
            sets = sets.OrderByDescending(s => s.Length).ToList();
            List<int[]> selectedSet = new List<int[]>();
            foreach (int[] set in sets)
            {
                bool contains = false;
                for (int i = 0; i < set.Length; i++)
                {
                    if (universe.Contains(set[i]))
                    {
                        contains = true;
                    }
                }

                if (contains)
                {
                    selectedSet.Add(set);
                }

                universe.RemoveAll(s => set.Contains(s));

                //universe.RemoveAll(x => set.Contains(x));
            }

            return selectedSet;
        }

        public static List<int[]> GreedySetCover(List<int> universe, List<int[]> sets)
        {
            List<int[]> selectSet = new List<int[]>();
            //int[] currentSet = sets.OrderByDescending(s => s.Count(universe.Contains)).First();
            while (universe.Count > 0)
            {
                int[] currentSet = sets.OrderByDescending(s => s.Count(universe.Contains)).First();

                selectSet.Add(currentSet);
                sets.Remove(currentSet);
                universe.RemoveAll(s => currentSet.Contains(s));
            }

            return selectSet;
        }
    }
}
