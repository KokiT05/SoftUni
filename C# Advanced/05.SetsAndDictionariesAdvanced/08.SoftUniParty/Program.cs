namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reservation = Console.ReadLine();

            HashSet<string> vipReservations = new HashSet<string>();
            HashSet<string> regularReservations = new HashSet<string>();
            while (reservation != "PARTY")
            {
                if (char.IsDigit(reservation[0]))
                {
                    vipReservations.Add(reservation);
                }
                else
                {
                    regularReservations.Add(reservation);
                }

                reservation = Console.ReadLine();
            }

            reservation = Console.ReadLine();
            while (reservation != "END" && (vipReservations.Count > 0 || regularReservations.Count > 0))
            {
                if (vipReservations.Contains(reservation))
                {
                    vipReservations.Remove(reservation);
                }
                else if (regularReservations.Contains(reservation))
                {
                    regularReservations.Remove(reservation);
                }

                reservation = Console.ReadLine();
            }

            Console.WriteLine(vipReservations.Count + regularReservations.Count);
            foreach (string vipReservation in vipReservations)
            {
                Console.WriteLine(vipReservation);
            }

            foreach (string regularReservation in regularReservations)
            {
                Console.WriteLine(regularReservation);
            }
        }
    }
}
