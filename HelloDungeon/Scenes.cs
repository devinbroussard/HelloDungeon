using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Scenes
    {

        Game game = new Game();
        public Player player;
        public Entity enemy;
        public Scenes()
        {
            player = new Player("", 40, 20, 100, true, 15);
            enemy = new Entity("Skeleton", 100, 20, false, 10, 10);
        }

        public void StartGame()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Console.WriteLine($"Okay, {player.name} press enter to start your adventure!");
            Console.ReadLine();
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
                    player.takeDamage(enemy.attack, enemy.critHit, enemy.defense);
                    Console.WriteLine($"The {enemy.name} attacks {player.name} for {enemy.attack} damage!");
                    Console.WriteLine($"{player.name}'s new Hp: {player.Health}");
                    Console.ReadLine();
                    player.isTurn = true;
                    enemy.isTurn = false;
                }

            }

            gameOver();

        }

    }
}
