namespace _06.ValidPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person personOne = new Person("PersonOne", "PersonOne", 21);
                //Person personTwo = new Person(string.Empty, "personTwo", 51);
                //Person personThree = new Person("personThree", null, 31);
                //Person personFour = new Person("personFour", "personFour", -1);
                //Person personFive = new Person("personFive", "personFive", 121);
            }
            catch (ArgumentNullException nullException)
            {
                Console.WriteLine($"Exception trown: {nullException.Message}");
                Console.WriteLine("Name exception");
            }
            catch (ArgumentOutOfRangeException outOfRangeException)
            {
                Console.WriteLine($"Exception trown: {outOfRangeException.Message}");
                Console.WriteLine("Age exception");
            }
        }
    }
}
