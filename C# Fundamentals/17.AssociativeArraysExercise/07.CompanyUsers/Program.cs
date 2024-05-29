namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> companiesWorkers = new Dictionary<string, List<string>>();
            while (input != "End")
            {
                string[] cmdArg = input.Split(" -> ");
                string company = cmdArg[0];
                string employeeId = cmdArg[1];

                if (companiesWorkers.ContainsKey(company) == false)
                {
                    companiesWorkers.Add(company, new List<string> { employeeId });
                }
                else if (companiesWorkers[company].Contains(employeeId) == false)
                {
                    companiesWorkers[company].Add(employeeId);
                }

                input = Console.ReadLine();
            }

            companiesWorkers = companiesWorkers.OrderBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (string company in companiesWorkers.Keys)
            {
                Console.WriteLine($"{company}");
                Console.WriteLine($"-- {string.Join("\n--", companiesWorkers[company])}");
            }
        }
    }
}