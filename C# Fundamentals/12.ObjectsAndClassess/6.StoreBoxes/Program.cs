namespace _6.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] information = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string serialNumber = information[0];
                string itemName = information[1];
                double itemQuantity = double.Parse(information[2]);
                decimal itemPrice = decimal.Parse(information[3]);

                Box box = new Box(serialNumber, itemQuantity);
                box.Item = new Item();
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;
                box.PriceBox = (decimal)itemQuantity * itemPrice;
                boxes.Add(box);

                command = Console.ReadLine();
            }

            boxes = boxes.OrderByDescending(b => b.PriceBox).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class Box
    {
        public Box(string serialNumber, double itemQuantity)
        {
            this.SerialNumber = serialNumber;
            this.Item = new Item();
            this.ItemQuantity = itemQuantity;
        }

        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public double ItemQuantity { get; set; }

        public decimal PriceBox { get; set; }
    }
}