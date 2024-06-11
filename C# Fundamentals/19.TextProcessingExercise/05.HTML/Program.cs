using System.Text;

namespace _05.HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<h1>");

            string title = Console.ReadLine();
            html.AppendLine($"    {title}");
            html.AppendLine("</h1>");

            html.AppendLine("<article>");
            string content = Console.ReadLine();
            html.AppendLine($"    {content}");
            html.AppendLine("</article>");


            string comment = Console.ReadLine();
            while (comment != "end of comments") 
            {
                html.AppendLine("<div>");
                html.AppendLine($"    {comment}");
                html.AppendLine("</div>");

                comment = Console.ReadLine();
            }

            Console.WriteLine(html.ToString());
        }
    }
}