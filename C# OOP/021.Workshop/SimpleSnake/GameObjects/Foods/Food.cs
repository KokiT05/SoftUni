using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wallInformation;
        private ConsoleColor foodColor;

        protected Food(Wall wall, char foodSymbol, int foodPoints, ConsoleColor foodColor) : base(wall.LeftX, wall.TopY)
        {
            this.wallInformation = wall;
            this.FoodPoints = foodPoints;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
            this.foodColor = foodColor;
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wallInformation.LeftX - 2);
            this.TopY = this.random.Next(2, this.wallInformation.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wallInformation.LeftX - 2);
                this.TopY = this.random.Next(2, this.wallInformation.TopY - 2);

                isPointOfSnake = snakeElements.Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            }

            Console.BackgroundColor = this.foodColor;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;  
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.LeftX == this.LeftX && snakeHead.TopY == this.TopY;
        }
    }
}
