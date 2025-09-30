string text = Console.ReadLine();

Stack<char> reverseText = new Stack<char>();

for (int i = 0; i < text.Length; i++)
{
    reverseText.Push(text[i]);
}

while (reverseText.Count > 0)
{
    Console.Write($"{reverseText.Pop()}");
}