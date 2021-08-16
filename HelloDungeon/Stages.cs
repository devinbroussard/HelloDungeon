using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Stages
    {
        Entity player = new Entity("", 100, 40, true);
        Entity enemy = new Entity("Skeleton", 100, 20, false);

        public void StartUp()
        {
            Console.WriteLine("Hello, what is your name?");
            player.name = Console.ReadLine();
            Console.WriteLine($"Okay, {player.name} press enter to start your adventure!");
            Console.ReadLine();
            Fight();
        }

        public void Fight()
        {
            Console.WriteLine($"A {enemy.name} appears!");

            while (player.isAlive() && enemy.isAlive())
            {


                if (player.isTurn == true)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Run Away");
                    string choice = Console.ReadLine().ToLower();
                    switch (choice)
                    {
                        case "attack":
                        case "1":
                            enemy.takeDamage(player.attack);
                            Console.WriteLine($"{player.name} attacks the {enemy.name} for {player.attack} damage!");
                            Console.WriteLine($"The {enemy.name}'s new Hp: {enemy.Health}");
                            Console.ReadLine();
                            player.isTurn = false;
                            enemy.isTurn = true;
                                break;
                        case "run away":
                        case "run":
                        case "2":
                            Console.WriteLine("You aren't allowed to run away!");
                            Console.ReadLine();
                            break;
                    }

                }

                if (enemy.isTurn == true)
                {
                    player.takeDamage(enemy.attack);
                    Console.WriteLine($"The {enemy.name} attacks {player.name} for {enemy.attack} damage!");

                    Console.WriteLine($"{player.name}'s new Hp: {player.Health}");
                    Console.ReadLine();
                    player.isTurn = true;
                    enemy.isTurn = false;
                }

            }

            Console.WriteLine("Game over!");
            Console.ReadLine();
        }
    }
}
