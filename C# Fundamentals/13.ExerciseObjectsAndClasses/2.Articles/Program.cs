namespace _2.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] currentData = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(currentData[0], currentData[1], currentData[2]);
            for (int i = 0; i < n; i++)
            {
                currentData = Console.ReadLine()
                                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string command = currentData[0];
                string inputData = currentData[1];
                Settings(article, command, inputData);
            }

            Console.WriteLine(article);
        }

        public  static void Settings(Article article, string command, string inputData)
        {
            if (command.ToLower() == "edit")
            {
                article.Edint(inputData);
            }
            else if (command.ToLower() == "changeauthor")
            {
                article.ChangeAuthor(inputData);
            }
            else if (command.ToLower() == "rename")
            {
                article.Rename(inputData);
            }
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edint(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string name)
        {
            this.Title = name;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}