using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    //A class that will contain different reoccuring scenes throughout the game, like GameOver, WinScreen, FightScene, etc.
    class Scenes
    {
        public bool gameOver;
        public Player player = new Player("", 60, 20, 100, true, 15);


        public void DisplayWelcomeScene()
        {
            Console.Clear();
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Utilities.WriteRead($"Okay, {player.name} press enter to start your adventure!\n");
        }

        public void DisplayWinScreen()
        {
            Console.Clear();
            Console.WriteLine("You won!");
            int input = Utilities.GetInput("Would you like to end the game, or try again?", "Try again", "End game");

            if (input == 1) gameOver = false;

            if (input == 2) Utilities.WriteRead("Okay, goodbye!");
        }

        //Function that can be called to end the game
        public void StartGameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            int input = Utilities.GetInput("Will you try again, or give up?", "Try again", "Give up");

            if (input == 1) gameOver = false;
            if (input == 2) Utilities.WriteRead("Goodbye, coward!");
        }

        //Reusable function that makes two BaseEntities fight
        public void FightScene(BaseEntity otherEntity)
        {
            Console.Clear();
            Utilities.WriteRead($"{otherEntity.name} appears!");

            while (player.IsAlive() && otherEntity.IsAlive())
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
