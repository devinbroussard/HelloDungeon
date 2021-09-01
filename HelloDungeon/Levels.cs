using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Levels
    {
        public int currentScene = 0;

        //initiates new scenes object from the scenes class
        Scenes scenes = new Scenes();

        //Initiates a skeleton object from the SimpleEnemy class
        public SimpleEnemy theSkeleton;

        //A constructor used to assign variables to the skeleton object
        public Levels()
        {
            theSkeleton = new SimpleEnemy("The Skeleton", 40, 20, 100, false, 15);
        }

        public void DisplayCurrentScene()
        {
            if (currentScene == 0) scenes.DisplayWelcomeScene();
            if (currentScene == 1) StartLevelOne();
        }

        //Level One function that can be called to start Level One
        public void StartLevelOne()
        {
            //Functions that give the player different scenarios based on the decision given
            void GoRightPath()
            {
                scenes.FightScene(theSkeleton);
            }
            void GoLeftPath()
            {
                Console.Clear();
               Console.WriteLine("You head down the path to your left, until you reach a rushing river.\n" +
                    "The water is moving far too fast for you to swim through it.\n" +
                    "You see a fallen tree laid across the river. You might be able to cross it.\n");

                int input = Utilities.GetInput("Will you turn back, or cross the tree?", "Cross the tree", "Turn around");
                if (input == 1)
                {
                    Console.Clear();
                    Utilities.WriteRead("You attempt to cross the tree.\n" +
                        "Unfortunately, you only make it half way before the tree breaks, leaving you to drown in the rushing water.\n" +
                        "You die a sad death.");
                    scenes.player.InstantKill();
                }

            }

            Console.Clear();
            Console.WriteLine("You awaken in a forest...\n" +
                "You are disoriented and your head is pounding...\n" +
                "Upon examining your surrounding, you notice that the sun is setting.\n" +
                "You begin walking towards a dirt path in the distance.\n" +
                "You reach the path, and are now faced with a question.\n");

            //GetInput function used to get player input on the route they want to take
            int input = Utilities.GetInput("Will you walk down the path to your right, or to your left?", "Right", "Left");
            if (input == 1)
            {
                GoRightPath();
            }
            if (input == 2)
            {
                GoLeftPath();
            }


        }
    }
}
