using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        Stages stages = new Stages();
        public void Run()
        {
            Stages stages = new Stages();
            startGame();
        }

        public void startGame()
        {
            Console.WriteLine("Hello, what is your name?");
            stages.player.name = Console.ReadLine();
            Console.WriteLine($"Okay, {player.name} press enter to start your adventure!");
            Console.ReadLine();
            stages.FightScene();
        }

        public void gameOver()
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine("Press enter to give up, or type 'restart', to try again!");
            string gameOverChoice = Console.ReadLine().ToLower();
            if (gameOverChoice == "restart")
            {
                StartUp();
            }
        }

    }
}