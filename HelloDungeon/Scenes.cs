﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    //A class that will contain different reoccuring scenes throughout the game, like GameOver, WinScreen, FightScene, etc.
    class Scenes
    {
        //Creating instances of classes used in file
        Levels levels = new Levels();
        Game game = new Game();
        public Player player;
        public Enemy enemy;

        //A constructor that creates two new objects of the player and enemy classes
        public Scenes()
        {
            player = new Player("", 40, 20, 100, true, 15);
            enemy = new Enemy("Skeleton", 40, 20, 100, false, 15);
        }

        //This function calls the welcome screen, and then progresses the game
        public void StartGame()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Console.WriteLine($"Okay, {player.name} press enter to start your adventure!\n");
            Console.ReadKey();

            levels.LevelOne();
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
            Console.Clear();
            Console.WriteLine($"A {enemy.name} appears!");

            while (player.isAlive() && enemy.isAlive())
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

                else if (enemy.isTurn == true)
                {
                    enemy.Attack(player);
                }

            }

            GameOver();

        }

    }
}
