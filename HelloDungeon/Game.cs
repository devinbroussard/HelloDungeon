using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        Levels levels = new Levels();
        public Player player;

        //A constructor that sets the variables of the player object
        public Game()
        {
            player = new Player("", 40, 20, 100, true, 15);
        }

        public void Run()
        {
            StartGame();
        }

        //This function calls the welcome screen, and then progresses the game
        public void StartGame()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine()
            Utilities.WriteRead($"Okay, {player.name} press enter to start your adventure!\n");
            levels.StartLevelOne();
        }
    }
}