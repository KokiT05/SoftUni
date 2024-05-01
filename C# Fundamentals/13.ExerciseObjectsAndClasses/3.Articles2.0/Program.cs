namespace _3.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticle = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            for (int i = 1; i <= numberOfArticle; i++)
            {
                string[] currentData = Console.ReadLine()
                                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

                string title = currentData[0];
                string content = currentData[1];
                string author = currentData[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string orderType = Console.ReadLine();

            if (orderType.ToLower() == "title")
            {
                articles = articles.OrderBy(a => a.Title).ToList();
            }
            else if (orderType.ToLower() == "content")
            {
                articles = articles.OrderBy(a => a.Content).ToList();
            }
            else if (orderType.ToLower() == "author")
            {
                articles = articles.OrderBy(a => a.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}