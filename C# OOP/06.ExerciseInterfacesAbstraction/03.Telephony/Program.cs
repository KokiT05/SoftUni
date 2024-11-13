namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            ISmartphone smartphone = new Smartphone();
            IStationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
                if (!IsValidNumber(phoneNumber))
                {
                    Console.WriteLine($"Invalid number!");
                    continue;
                }

                if (phoneNumber.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(phoneNumber));

                }
                else if (phoneNumber.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(phoneNumber));
                }
            }

            foreach (string site in sites)
            {
                if (!IsValidUrl(site))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine(smartphone.Browse(site));
                //smartphone.Browse(site);
            }
        }

        public static bool IsValidNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsValidUrl(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
