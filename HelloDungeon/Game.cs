using System;
using System.Collections.Generic;
using System.Text;

namespace HelloDungeon
{
    class Game
    {
        Levels levels = new Levels();
        Scenes scenes = new Scenes();

        public void Run()
        {
            while (!scenes.gameOver)
            {
                levels.DisplayCurrentScene();

                if (!scenes.player.IsAlive()) scenes.StartGameOver();
                levels.currentScene++;
                //if (levels.currentScene == 3
                //{
                //    scenes.DisplayWinScreen();
                //    levels.currentScene = 0;
                //}
            }
        }

    }
}