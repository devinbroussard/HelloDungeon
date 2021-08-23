using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Scenes
    {

        Game game = new Game();
        public Player player;
        public Enemy enemy;
        public Scenes()
        {
            player = new Player("", 40, 20, 100, true, 15);
            enemy = new Enemy("Skeleton", 40, 20, 100, true, 15);
        }

        public void StartGame()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Console.WriteLine($"Okay, {player.name} press enter to start your adventure!");
            Console.ReadKey();
            FightScene();
        }

        public void GameOver()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press enter to give up, or type 'restart', to try again!");
            string gameOverChoice = Console.ReadLine().ToLower();
            if (gameOverChoice == "restart")
            {
                StartGame();
            }
        }

        public void FightScene()
        {
            Console.WriteLine($"A {enemy.name} appears!");

            while (player.isAlive() && enemy.isAlive())
            {


                if (player.isTurn == true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack!");
                    Console.WriteLine("2. Scavage for items.");
                    Console.WriteLine("3. Run Away!");
                    string choice = Console.ReadLine().ToLower();
                    switch (choice)
                    {
                        case "attack":
                        case "1":
                            player.Attack(enemy);
                                break;
                        case "2":
                        case "Scavage":
                            break;
                        case "run away":
                        case "run":
                        case "3":
                            Console.WriteLine("You aren't allowed to run away!");
                            Console.ReadLine();
                            break;
                    }

                }

                if (enemy.isTurn == true)
                {
                    enemy.Attack(player);
                }

            }

            GameOver();

        }

    }
}
