using _04.CommandPatternLectureExample.Components;

namespace _04.CommandPatternLectureExample
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Position position = new Position(50, 10);
            Componen componen = new Componen(new Position(0, 0));

            IComponent firstRectangle = BuildRectangle(position);
            IComponent secondRetangle = BuildRectangle(new Position(0, 0));

            componen.Add(firstRectangle);
            componen.Add(secondRetangle);

            secondRetangle.Draw();

            while (true)
            {
                Position movePosition = new Position(1, 1);

                Console.Clear();

                //firstRectangle.Move(new Position(1, -1));
                componen.Move(movePosition);

                componen.Draw();

                Thread.Sleep(200);
            }
        }

        public static IComponent BuildRectangle(Position position)
        {
            IComponent rectangle = new Rectangle(new Position(15 + position.X, 5 + position.Y), 10);
            rectangle.Add(new Text(new Position(25 + position.X, 5 + position.Y), "Composite is cool"));
            rectangle.Add(new Text(new Position(35 + position.X, 2 + position.Y), "Something"));

            return rectangle;
        }
    }
}
