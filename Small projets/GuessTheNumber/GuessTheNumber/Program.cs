namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, guest the number :)");
            //Console.WriteLine("For exit enter 0");

            //Console.Write("Enter your number [1, 10]: ");
            //int inputNumber = int.Parse(Console.ReadLine());


            //Random randomNumber = new Random();
            //List<int> randomNumbers = new List<int>();
            //int currentNumber = 0;

            //while (inputNumber != 0)
            //{
            //    currentNumber = randomNumber.Next(1, 11);
            //    if (inputNumber == currentNumber)
            //    {
            //        Console.WriteLine("You win!");
            //        break;
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Incorrect!");
            //        Console.WriteLine($"Your number is: {inputNumber}");
            //        Console.WriteLine($"The magic number was: {currentNumber}. Good luck next time :)");
            //    }

            //    Console.Write("Enter your number [1, 10]: ");
            //    inputNumber = int.Parse(Console.ReadLine());

            //    randomNumbers.Add(currentNumber);
            //}

            BinaryTree tree = new BinaryTree();

            // Примерни стойности за дървото
            tree.Insert(1);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(2);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(10);
            tree.Insert(9);
            tree.Insert(11);

            tree.CalculateSums(out int evenSum, out int oddSum);

            Console.WriteLine("Сума на четните стойности: " + evenSum);
            Console.WriteLine("Сума на нечетните стойности: " + oddSum);

            tree.PrintValues();
        }
    }

    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinaryTree
    {
        public TreeNode Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            Root = InsertRec(Root, value);
        }

        private TreeNode InsertRec(TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return root;
            }

            if (value < root.Value)
                root.Left = InsertRec(root.Left, value);
            else if (value > root.Value)
                root.Right = InsertRec(root.Right, value);

            return root;
        }

        public void CalculateSums(out int evenSum, out int oddSum)
        {
            evenSum = 0;
            oddSum = 0;
            CalculateSumsRec(Root, ref evenSum, ref oddSum);
        }

        private void CalculateSumsRec(TreeNode node, ref int evenSum, ref int oddSum)
        {
            if (node == null)
            {
                return;
            }

            if (node != null && node.Left == null && node.Right == null)
            {
                if (node.Value % 2 == 0)
                    evenSum += node.Value;
                else
                    oddSum += node.Value;

                return;
            }

            //if (node == null)
            //    return;

            //// Ако стойността на възела е четна
            //if (node.Value % 2 == 0)
            //    evenSum += node.Value;
            //else
            //    oddSum += node.Value;

            // Обхождаме левия и десния поддървета

            CalculateSumsRec(node.Left, ref evenSum, ref oddSum);
            CalculateSumsRec(node.Right, ref evenSum, ref oddSum);
        }

        public void PrintValues()
        {
            PrintValuesRec(Root);
            Console.WriteLine(); // Нов ред след всички стойности
        }

        private void PrintValuesRec(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (node != null && node.Left == null && node.Right == null)
            {
                Console.WriteLine(node.Value);
                return;
            }

            //if (node == null)
            //    return;

            // Обхождаме лявото поддърво
            PrintValuesRec(node.Left);

            // Принтираме стойността на текущия възел
            //Console.Write(node.Value + " ");

            // Обхождаме дясното поддърво
            PrintValuesRec(node.Right);
        }
    }
}