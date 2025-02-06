using _020.Workshop.Common;
using _020.Workshop.Contracts;
using _020.Workshop.DI;
using _020.Workshop.DI.Attributes;
using _020.Workshop.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _020.Workshop
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;
        private IMover mover;
        private List<IGameObject> gameObjects;
        private List<IGameObject> enemies;
        private Ball ball;

        //[Inject]
        public Engine(ILogger logger, IReader reader, IMover mover)
        {
            this.logger = logger;
            this.reader = reader;
            this.mover = mover;
            this.gameObjects = new List<IGameObject>();
            this.enemies = new List<IGameObject>();
            this.enemies.Add(InjectorSingleton.Instance.Inject<Enemy>());
            this.ball = InjectorSingleton.Instance.Inject<Ball>();
            this.gameObjects.Add(ball);
        }

        public void Start()
        {

            while (true)
            {
                foreach (IGameObject @object in gameObjects)
                {
                    @object.Draw();

                }

                foreach (IGameObject enemy in enemies)
                {
                    enemy.Draw();
                    mover.Move(enemy, new Position(1, 0));
                }

                Position position = reader.ReadKey();

                mover.Move(ball, position);
                Console.Clear();
                //Thread.Sleep(100);
            }
        }

        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
