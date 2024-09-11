using System.Text;

namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var filterList = new List<string>();

            string filter = Console.ReadLine();

            while (filter != "Print")
            {
                string[] filterInfo = filter
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                string operation = filterInfo[0];

                if (operation == "Add filter")
                {
                    filterList.Add($"{filterInfo[1]};{filterInfo[2]}");
                }
                else if (operation == "Remove filter")
                {
                    if (filterList.Contains($"{filterInfo[1]};{filterInfo[2]}"))
                    {
                        filterList.Remove($"{filterInfo[1]};{filterInfo[2]}");
                    }
                }

                filter = Console.ReadLine();
            }

            Func<string, int, bool> lengthFilter = (name, length)
                => name.Length == length;
            Func<string, string, bool> startsFilter = (name, letter)
                => name.StartsWith(letter);
            Func<string, string, bool> endsFilter = (name, letter)
                => name.EndsWith(letter);
            Func<string, string, bool> containsFilter = (name, letter)
                => name.Contains(letter);

            foreach (var currentFilter in filterList)
            {
                string[] currentFilterInfo = currentFilter
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string action = currentFilterInfo[0];
                string parameter = currentFilterInfo[1];

                if (action == "Starts with")
                {
                    names = names
                        .Where(name => !startsFilter(name, parameter))
                        .ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names
                        .Where(name => !endsFilter(name, parameter))
                        .ToArray();
                }
                else if (action == "Length")
                {
                    names = names
                        .Where(name => !lengthFilter(name, int.Parse(parameter)))
                        .ToArray();
                }
                else if (action == "Contains")
                {
                    names = names
                        .Where(name => !containsFilter(name, parameter))
                        .ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));

            //string[] reservation = Console.ReadLine().Split(" ");
            //Stack<string> reservationTime = new Stack<string>();

            //Func<string, string, bool> func;
            //string[] modifyReservation = reservation;

            //reservationTime.Push(GetReservation(reservation));

            //string input = Console.ReadLine();
            //while (input != "Print")
            //{
            //    string[] splitInput = input.Split(";");
            //    string command = splitInput[0].ToLower();
            //    string filterType = splitInput[1].ToLower();
            //    string filterParameter = splitInput[2];

            //    func = GetFunc(filterType, filterParameter);

            //    if (command == "add filter")
            //    {
            //        modifyReservation = modifyReservation
            //                .Where(r => !func(r, filterParameter))
            //                .ToArray();
            //        reservationTime
            //        .Push(GetReservation(modifyReservation));
            //    }
            //    else if (command == "remove filter" && reservationTime.Count > 1)
            //    {
            //        reservationTime.Pop();
            //    }


            //    input = Console.ReadLine();
            //}

            //Console.WriteLine(reservationTime.Peek());
        }

        //static Func<string, string, bool>
        //GetFunc(string filterType, string filterParameter)
        //{
        //    if (filterType.ToLower() == "starts with")
        //    {
        //        return (name, filterParameter) => name.StartsWith(filterParameter);
        //    }
        //    else if (filterType.ToLower() == "ends with")
        //    {
        //        return (name, filterParameter) => name.EndsWith(filterParameter);
        //    }
        //    else if (filterType.ToLower() == "length")
        //    {
        //        return (name, filterParameter) => name.Length == int.Parse(filterParameter);
        //    }
        //    else if (filterType.ToLower() == "contains")
        //    {
        //        return (name, filterParameter) => name.Contains(filterParameter);
        //    }

        //    return (name, filter) => true;
        //}

        //static string GetReservation(string[] reservation)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();

        //    foreach (string name in reservation)
        //    {
        //        stringBuilder.Append(name);
        //        stringBuilder.Append(' ');
        //    }

        //    return stringBuilder.ToString();
        //}
    }
}
