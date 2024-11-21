

namespace GuessTheNumber
{
    public class BinaryTree
    {
        private const int Count = 4;
        public BinaryTree(Node root)
        {
            this.Root = root;
        }
        public Node Root { get; set; }

        public Node InsertNode(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                Node curr = q.Dequeue();

                if (curr.Left != null)
                    q.Enqueue(curr.Left);
                else
                {
                    curr.Left = new Node(data);
                    return root;
                }

                if (curr.Right != null)
                    q.Enqueue(curr.Right);
                else
                {
                    curr.Right = new Node(data);
                    return root;
                }
            }
            return root;
        }

        public void PrintBinaryTree(Node root, int space)
        {
            if (root == null)
                return;

            space += Count;

            PrintBinaryTree(root.Right, space);

            Console.Write("\n");
            for (int i = Count; i < space; i++)
                Console.Write(" ");
            Console.Write(root.Value + "\n");

            PrintBinaryTree(root.Left, space);
        }

        public int CalculationEvenNumbers(Node root)
        {
            Node currentNode = root;

            if (currentNode == null)
            {
                return 0;
            }

            int sum = 0;

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode.Value % 2 == 0)
                {
                    return currentNode.Value;
                }

                //return currentNode.Value;
            }

            sum += CalculationEvenNumbers(currentNode.Left);
            sum += CalculationEvenNumbers(currentNode.Right);

            return sum;
        }

        public int CalculationOddNumbers(Node root)
        {
            Node currentNode = root;

            if (currentNode == null)
            {
                return 0;
            }

            int sum = 0;

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode.Value % 2 != 0)
                {
                    return currentNode.Value;
                }

                //return currentNode.Value;
            }

            sum += CalculationOddNumbers(currentNode.Left);
            sum += CalculationOddNumbers(currentNode.Right);

            return sum;
        }
    }
}
