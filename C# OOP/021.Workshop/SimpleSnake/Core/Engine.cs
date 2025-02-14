using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private readonly Point[] pointsOfDirection;
        private Direction direction;
        private readonly Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;

            this.sleepTime = 180;

            this.pointsOfDirection = new Point[4];
            this.CreateDirections();
        }
        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.snake.IsMoving(this.pointsOfDirection[(int)this.direction]);

                if (!isMoving)
                {
                    this.AskUserForRestart();
                }

                this.PrintStatisticsInfo();

                sleepTime -= 0.1;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 6;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write("Your choise: ");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void CreateDirections()
        {
            //this.pointsOfDirection[(int)Direction.Right];
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down; 
                }
            }

            Console.CursorVisible = false;
        }

        private void StopGame()
        {
            Console.SetCursorPosition(10, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }

        private void PrintStatisticsInfo()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 1;


            Console.SetCursorPosition(leftX, topY - 1);
            Console.Write(new string('-', 20));

            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Player points: {this.snake.SnakePoints}");

            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write($"Player level: {this.snake.SnakeLevel}");


            Console.SetCursorPosition(leftX, topY + 2);
            Console.Write(new string('-', 20));
        }
    }
}
