using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    //A class that will contain different reoccuring scenes throughout the game, like GameOver, WinScreen, FightScene, etc.
    class Scenes
    {

        //Creating instances of classes used in file
        public Player player;
        Levels levels = new Levels();

        //A constructor that creates two new objects of the player and enemy classes
        public Scenes()
        {
            player = new Player("", 40, 20, 100, true, 15);
        }

        //This function calls the welcome screen, and then progresses the game
        public void StartGame()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Utilities.WriteRead($"Okay, {player.name} press enter to start your adventure!\n");
            levels.StartLevelOne();
        }

        //Function that can be called to end the game
        public void StartGameOver()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press enter to give up, or type 'restart', to try again!");
            string gameOverChoice = Console.ReadLine().ToLower();
            if (gameOverChoice == "restart")
            {
                StartGame();
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
