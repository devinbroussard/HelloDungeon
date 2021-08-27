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
            scenes.StartGame();
            levels.StartLevelOne();
        }

    }
}