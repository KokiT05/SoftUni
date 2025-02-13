using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int SnakeStartLength = 6;
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySpaceSymbol = ' ';

        private readonly Queue<Point> snakeElements;
        private readonly Food[] foods;
        private readonly Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        private bool isFoodSpanwned;
        private int snakePoints;
        private int levelCounter;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];

            this.foodIndex = RandomFoodNumber;

            this.isFoodSpanwned = false;
            this.snakePoints = 6;
            this.levelCounter = 100;

            this.GetFoods();
            this.CreateSnake();
        }

        public int SnakePoints => this.snakePoints;

        public int SnakeLevel => this.levelCounter / 100;
        public bool IsMoving(Point direction)
        {
            Point snakeHead = this.snakeElements.Last();

            GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = this.snakeElements
                            .Any(p => p.LeftX == this.nextLeftX && p.TopY == this.nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (!isFoodSpanwned)
            {
                this.foods[foodIndex].SetRandomPosition(this.snakeElements);
                this.isFoodSpanwned = true;
            }

            if (this.foods[foodIndex].IsFoodPoint(newSnakeHead))
            {
                this.Eat(direction, snakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(EmptySpaceSymbol);

            this.levelCounter++;

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, currentSnakeHead);
            }

            this.snakePoints += length;

            this.foodIndex = RandomFoodNumber;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private int RandomFoodNumber => new Random().Next(0, this.foods.Length);
        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }
        private void CreateSnake()
        {
            for (int topY = 1; topY <= SnakeStartLength; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }
        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);

        }

        // Reflection for Food
        //private void GetFoods()
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    Type[] foodTypes = assembly.GetTypes().Where(f => f.Name.StartsWith("Food")).ToArray();
        //}
    }
}
