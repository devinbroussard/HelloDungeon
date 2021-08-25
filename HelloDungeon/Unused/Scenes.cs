using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    //A class that will contain different reoccuring scenes throughout the game, like GameOver, WinScreen, FightScene, etc.
    class Scenes
    {
        Game game = new Game();

        Player player;

        //Function that can be called to end the game
        public void StartGameOver()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press enter to give up, or type 'restart', to try again!");
            string gameOverChoice = Console.ReadLine().ToLower();
            if (gameOverChoice == "restart")
            {
                game.StartGame();
            }
        }

        //Reusable function that makes two BaseEntities fight
        public void FightScene(BaseEntity otherEntity)
        {
            Console.Clear();
            Console.WriteLine($"{otherEntity.name} appears!");

            while (player.isAlive() && otherEntity.isAlive())
            {

                if (player.isTurn == true)
                {
                    Console.Clear();
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack!");
                    Console.WriteLine("2. Scavage for items.");
                    Console.WriteLine("3. Run Away!");
                    string choice = Console.ReadLine().ToLower();
                    switch (choice)
                    {
                        case "attack":
                        case "1":
                            player.Attack(otherEntity);
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

                else if (otherEntity.isTurn == true)
                {
                    otherEntity.Attack(player);
                }

            }

            StartGameOver();

        }

    }
}
